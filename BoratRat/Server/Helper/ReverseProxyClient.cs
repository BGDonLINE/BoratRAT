using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Server.Connection;

namespace Server.Helper
{
	// Token: 0x0200002F RID: 47
	public class ReverseProxyClient
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000FFD4 File Offset: 0x0000FFD4
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000FFDC File Offset: 0x0000FFDC
		public Socket Handle { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000FFE8 File Offset: 0x0000FFE8
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000FFF0 File Offset: 0x0000FFF0
		public Clients Client { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000FFFC File Offset: 0x0000FFFC
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00010004 File Offset: 0x00010004
		public long PacketsReceived { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00010010 File Offset: 0x00010010
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00010018 File Offset: 0x00010018
		public long PacketsSended { get; private set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00010024 File Offset: 0x00010024
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x0001002C File Offset: 0x0001002C
		public long LengthReceived { get; private set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00010038 File Offset: 0x00010038
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x00010040 File Offset: 0x00010040
		public long LengthSent { get; private set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0001004C File Offset: 0x0001004C
		public int ConnectionId
		{
			get
			{
				return this.Handle.Handle.ToInt32();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00010070 File Offset: 0x00010070
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00010078 File Offset: 0x00010078
		public string TargetServer { get; private set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00010084 File Offset: 0x00010084
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0001008C File Offset: 0x0001008C
		public ushort TargetPort { get; private set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00010098 File Offset: 0x00010098
		// (set) Token: 0x060001EF RID: 495 RVA: 0x000100A0 File Offset: 0x000100A0
		public bool IsConnected { get; private set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000100AC File Offset: 0x000100AC
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000100B4 File Offset: 0x000100B4
		public ReverseProxyClient.ProxyType Type { get; private set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000100C0 File Offset: 0x000100C0
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000100C8 File Offset: 0x000100C8
		public string HostName { get; private set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000100D4 File Offset: 0x000100D4
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x000100DC File Offset: 0x000100DC
		public bool ProxySuccessful { get; private set; }

		// Token: 0x060001F6 RID: 502 RVA: 0x000100E8 File Offset: 0x000100E8
		public ReverseProxyClient(Clients client, Socket socket, ReverseProxyServer server)
		{
			this.Handle = socket;
			this.Client = client;
			this._handshakeStream = new MemoryStream();
			this._buffer = new byte[8192];
			this.IsConnected = true;
			this.TargetServer = "";
			this.Type = ReverseProxyClient.ProxyType.Unknown;
			this.Server = server;
			try
			{
				socket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceive), null);
			}
			catch
			{
				this.Disconnect();
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0001018C File Offset: 0x0001018C
		private void AsyncReceive(IAsyncResult ar)
		{
			try
			{
				int num = this.Handle.EndReceive(ar);
				if (num <= 0)
				{
					this.Disconnect();
					return;
				}
				if (num > 5000 || this._handshakeStream.Length + (long)num > 5000L)
				{
					this.Disconnect();
					return;
				}
				this.LengthReceived += (long)num;
				this._handshakeStream.Write(this._buffer, 0, num);
			}
			catch
			{
				this.Disconnect();
				return;
			}
			byte[] array = this._handshakeStream.ToArray();
			long packetsReceived = this.PacketsReceived;
			if (packetsReceived != 0L)
			{
				if (packetsReceived == 1L)
				{
					int num2 = 6;
					if (array.Length >= num2)
					{
						if (!this.CheckProxyVersion(array))
						{
							return;
						}
						this._isConnectCommand = array[1] == 1;
						this._isBindCommand = array[1] == 2;
						this._isUdpCommand = array[1] == 3;
						this._isIpType = array[3] == 1;
						this._isDomainNameType = array[3] == 3;
						this._isIPv6NameType = array[3] == 4;
						Array.Reverse(array, array.Length - 2, 2);
						this.TargetPort = BitConverter.ToUInt16(array, array.Length - 2);
						if (this._isConnectCommand)
						{
							if (this._isIpType)
							{
								this.TargetServer = string.Concat(new string[]
								{
									array[4].ToString(),
									".",
									array[5].ToString(),
									".",
									array[6].ToString(),
									".",
									array[7].ToString()
								});
							}
							else if (this._isDomainNameType)
							{
								int num3 = (int)array[4];
								if (num2 + num3 < array.Length)
								{
									this.TargetServer = Encoding.ASCII.GetString(array, 5, num3);
								}
							}
							if (this.TargetServer.Length > 0)
							{
							}
							this.Server.CallonUpdateConnection(this);
							return;
						}
						this.SendFailToClient();
						return;
					}
				}
			}
			else if (array.Length >= 3)
			{
				string @string = Encoding.ASCII.GetString(array);
				if (array[0] == 5)
				{
					this.Type = ReverseProxyClient.ProxyType.SOCKS5;
				}
				else
				{
					if (!@string.StartsWith("CONNECT") || !@string.Contains(":"))
					{
						goto IL_361;
					}
					this.Type = ReverseProxyClient.ProxyType.HTTPS;
					using (StreamReader streamReader = new StreamReader(new MemoryStream(array)))
					{
						string text = streamReader.ReadLine();
						if (text == null)
						{
							goto IL_361;
						}
						string[] array2 = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
						if (array2.Length != 0)
						{
							try
							{
								string text2 = array2[1];
								this.TargetServer = text2.Split(new char[] { ':' })[0];
								this.TargetPort = ushort.Parse(text2.Split(new char[] { ':' })[1]);
								this._isConnectCommand = true;
								this._isDomainNameType = true;
								this.Server.CallonConnectionEstablished(this);
								return;
							}
							catch
							{
								this.Disconnect();
							}
						}
					}
				}
				if (this.CheckProxyVersion(array))
				{
					this.SendSuccessToClient();
					long packetsReceived2 = this.PacketsReceived;
					this.PacketsReceived = packetsReceived2 + 1L;
					this._handshakeStream.SetLength(0L);
					this.Server.CallonConnectionEstablished(this);
				}
			}
			IL_361:
			try
			{
				this.Handle.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceive), null);
			}
			catch
			{
				this.Disconnect();
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0001056C File Offset: 0x0001056C
		public void Disconnect()
		{
			if (!this._disconnectIsSend)
			{
				this._disconnectIsSend = true;
			}
			try
			{
				this.Handle.Close();
			}
			catch
			{
			}
			this.IsConnected = false;
			this.Server.CallonUpdateConnection(this);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000105C8 File Offset: 0x000105C8
		public void SendToClient(byte[] payload)
		{
			Socket handle = this.Handle;
			lock (handle)
			{
				try
				{
					this.LengthSent += (long)payload.Length;
					this.Handle.Send(payload);
				}
				catch
				{
					this.Disconnect();
				}
			}
			this.Server.CallonUpdateConnection(this);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001064C File Offset: 0x0001064C
		private void SendFailToClient()
		{
			if (this.Type == ReverseProxyClient.ProxyType.HTTPS)
			{
				this.Disconnect();
			}
			if (this.Type == ReverseProxyClient.ProxyType.SOCKS5)
			{
				this.SendToClient(new byte[] { 5, byte.MaxValue });
				this.Disconnect();
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0001069C File Offset: 0x0001069C
		private void SendSuccessToClient()
		{
			if (this.Type == ReverseProxyClient.ProxyType.SOCKS5)
			{
				byte[] array = new byte[2];
				array[0] = 5;
				this.SendToClient(array);
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000106BC File Offset: 0x000106BC
		private bool CheckProxyVersion(byte[] payload)
		{
			if (this.Type == ReverseProxyClient.ProxyType.HTTPS)
			{
				return true;
			}
			if (payload.Length != 0 && payload[0] != 5)
			{
				this.SendFailToClient();
				this.Disconnect();
				return false;
			}
			return true;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000106EC File Offset: 0x000106EC
		private void AsyncReceiveProxy(IAsyncResult ar)
		{
			long num2;
			try
			{
				int num = this.Handle.EndReceive(ar);
				if (num <= 0)
				{
					this.Disconnect();
					return;
				}
				this.LengthReceived += (long)num;
				byte[] array = new byte[num];
				Array.Copy(this._buffer, array, num);
				this.LengthSent += (long)array.Length;
				num2 = this.PacketsSended;
				this.PacketsSended = num2 + 1L;
			}
			catch
			{
				this.Disconnect();
				return;
			}
			num2 = this.PacketsReceived;
			this.PacketsReceived = num2 + 1L;
			this.Server.CallonUpdateConnection(this);
			try
			{
				this.Handle.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceiveProxy), null);
			}
			catch
			{
			}
		}

		// Token: 0x040000FC RID: 252
		public const int SOCKS5_DEFAULT_PORT = 3218;

		// Token: 0x040000FD RID: 253
		public const byte SOCKS5_VERSION_NUMBER = 5;

		// Token: 0x040000FE RID: 254
		public const byte SOCKS5_RESERVED = 0;

		// Token: 0x040000FF RID: 255
		public const byte SOCKS5_AUTH_NUMBER_OF_AUTH_METHODS_SUPPORTED = 2;

		// Token: 0x04000100 RID: 256
		public const byte SOCKS5_AUTH_METHOD_NO_AUTHENTICATION_REQUIRED = 0;

		// Token: 0x04000101 RID: 257
		public const byte SOCKS5_AUTH_METHOD_GSSAPI = 1;

		// Token: 0x04000102 RID: 258
		public const byte SOCKS5_AUTH_METHOD_USERNAME_PASSWORD = 2;

		// Token: 0x04000103 RID: 259
		public const byte SOCKS5_AUTH_METHOD_IANA_ASSIGNED_RANGE_BEGIN = 3;

		// Token: 0x04000104 RID: 260
		public const byte SOCKS5_AUTH_METHOD_IANA_ASSIGNED_RANGE_END = 127;

		// Token: 0x04000105 RID: 261
		public const byte SOCKS5_AUTH_METHOD_RESERVED_RANGE_BEGIN = 128;

		// Token: 0x04000106 RID: 262
		public const byte SOCKS5_AUTH_METHOD_RESERVED_RANGE_END = 254;

		// Token: 0x04000107 RID: 263
		public const byte SOCKS5_AUTH_METHOD_REPLY_NO_ACCEPTABLE_METHODS = 255;

		// Token: 0x04000108 RID: 264
		public const byte SOCKS5_CMD_REPLY_SUCCEEDED = 0;

		// Token: 0x04000109 RID: 265
		public const byte SOCKS5_CMD_REPLY_GENERAL_SOCKS_SERVER_FAILURE = 1;

		// Token: 0x0400010A RID: 266
		public const byte SOCKS5_CMD_REPLY_CONNECTION_NOT_ALLOWED_BY_RULESET = 2;

		// Token: 0x0400010B RID: 267
		public const byte SOCKS5_CMD_REPLY_NETWORK_UNREACHABLE = 3;

		// Token: 0x0400010C RID: 268
		public const byte SOCKS5_CMD_REPLY_HOST_UNREACHABLE = 4;

		// Token: 0x0400010D RID: 269
		public const byte SOCKS5_CMD_REPLY_CONNECTION_REFUSED = 5;

		// Token: 0x0400010E RID: 270
		public const byte SOCKS5_CMD_REPLY_TTL_EXPIRED = 6;

		// Token: 0x0400010F RID: 271
		public const byte SOCKS5_CMD_REPLY_COMMAND_NOT_SUPPORTED = 7;

		// Token: 0x04000110 RID: 272
		public const byte SOCKS5_CMD_REPLY_ADDRESS_TYPE_NOT_SUPPORTED = 8;

		// Token: 0x04000111 RID: 273
		public const byte SOCKS5_ADDRTYPE_IPV4 = 1;

		// Token: 0x04000112 RID: 274
		public const byte SOCKS5_ADDRTYPE_DOMAIN_NAME = 3;

		// Token: 0x04000113 RID: 275
		public const byte SOCKS5_ADDRTYPE_IPV6 = 4;

		// Token: 0x04000114 RID: 276
		public const int BUFFER_SIZE = 8192;

		// Token: 0x04000117 RID: 279
		private bool _receivedConnResponse;

		// Token: 0x04000118 RID: 280
		private MemoryStream _handshakeStream;

		// Token: 0x0400011D RID: 285
		private byte[] _buffer;

		// Token: 0x04000121 RID: 289
		private bool _isBindCommand;

		// Token: 0x04000122 RID: 290
		private bool _isUdpCommand;

		// Token: 0x04000123 RID: 291
		private bool _isConnectCommand;

		// Token: 0x04000124 RID: 292
		private bool _isIpType;

		// Token: 0x04000125 RID: 293
		private bool _isIPv6NameType;

		// Token: 0x04000126 RID: 294
		private bool _isDomainNameType;

		// Token: 0x04000127 RID: 295
		private bool _disconnectIsSend;

		// Token: 0x04000129 RID: 297
		private ReverseProxyServer Server;

		// Token: 0x02000D5D RID: 3421
		public enum ProxyType
		{
			// Token: 0x04003F5B RID: 16219
			Unknown,
			// Token: 0x04003F5C RID: 16220
			SOCKS5,
			// Token: 0x04003F5D RID: 16221
			HTTPS
		}
	}
}
