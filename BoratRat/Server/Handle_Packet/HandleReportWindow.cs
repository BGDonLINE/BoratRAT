// Server.Handle_Packet.HandleReportWindow
using System.Drawing;
using Server;
using Server.Connection;
using Server.Handle_Packet;
using Server.Properties;

public class HandleReportWindow
{
    public HandleReportWindow(Clients client, string title)
    {
        new HandleLogs().Addmsg("Client " + client.Ip + " opened [" + title + "]", Color.Blue);
        if (Server.Properties.Settings.Default.Notification)
        {
            Program.form1.notifyIcon1.BalloonTipText = "Client " + client.Ip + " opened [" + title + "]";
            Program.form1.notifyIcon1.ShowBalloonTip(100);
        }
    }
}