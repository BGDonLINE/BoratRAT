// Server.Helper.DingDing
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

internal class DingDing
{
    public static void Send(string WebHook, string secret, string content)
    {
        _ = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long num = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000L) / 10000;
        string s = num + "\n" + secret;
        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
        byte[] bytes = aSCIIEncoding.GetBytes(secret);
        byte[] bytes2 = aSCIIEncoding.GetBytes(s);
        string text;
        using (HMACSHA256 hMACSHA = new HMACSHA256(bytes))
        {
            text = HttpUtility.UrlEncode(Convert.ToBase64String(hMACSHA.ComputeHash(bytes2)), Encoding.UTF8);
        }
        string text2 = WebHook + "&timestamp=" + num + "&sign=" + text;
        string s2 = JsonConvert.SerializeObject(new
        {
            msgtype = "text",
            text = new { content }
        });
        Console.WriteLine(text2);
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentType = "application/json;charset=utf-8";
        byte[] bytes3 = Encoding.UTF8.GetBytes(s2);
        httpWebRequest.ContentLength = bytes3.Length;
        using (Stream stream = httpWebRequest.GetRequestStream())
        {
            stream.Write(bytes3, 0, bytes3.Length);
        }
        using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream(), Encoding.UTF8);
        streamReader.ReadToEnd();
    }
}