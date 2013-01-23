using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PRI.ProductivityExtensions.UdpClientExtensions
{
	public partial class UdpClientable
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="dgram"></param>
		/// <param name="endPoint"></param>
		/// <returns></returns>
		public static int Send(this UdpClient udpClient, byte[] dgram, IPEndPoint endPoint)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.Send(dgram, dgram.Length, endPoint);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="dgram"></param>
		/// <returns></returns>
		public static int Send(this UdpClient udpClient, byte[] dgram)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.Send(dgram, dgram.Length);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="dgram"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <returns></returns>
		public static int Send(this UdpClient udpClient, byte[] dgram, string hostname, int port)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.Send(dgram, dgram.Length, hostname, port);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="asyncCallback"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, string hostname, int port, AsyncCallback asyncCallback)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, hostname, port, asyncCallback, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, string hostname, int port, AsyncCallback asyncCallback, object state)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, hostname, port, asyncCallback, state);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="bytes"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, int bytes, string hostname, int port, AsyncCallback asyncCallback, object state)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, bytes, hostname, port, asyncCallback, state);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, AsyncCallback asyncCallback, object state)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, asyncCallback, state);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="bytes"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, int bytes, AsyncCallback asyncCallback, object state)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, bytes, asyncCallback, state);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="bytes"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, IPEndPoint endPoint, AsyncCallback asyncCallback)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, endPoint, asyncCallback, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="bytes"></param>
		/// <param name="asyncCallback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, IPEndPoint endPoint, AsyncCallback asyncCallback, object state)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, endPoint, asyncCallback, state);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="udpClient"></param>
		/// <param name="datagram"></param>
		/// <param name="asyncCallback"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static IAsyncResult BeginSend(this UdpClient udpClient, byte[] datagram, AsyncCallback asyncCallback)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.BeginSend(datagram, datagram.Length, asyncCallback);
		}
#if NET_4_5
		public static Task<int> SendAsync(this UdpClient udpClient, byte[] datagram)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.SendAsync(datagram, datagram.Length);
		}

		public static Task<int> SendAsync(this UdpClient udpClient, byte[] datagram, IPEndPoint endPoint)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.SendAsync(datagram, datagram.Length, endPoint);
		}

		public static Task<int> SendAsync(this UdpClient udpClient, byte[] datagram, string hostname, int port)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			return udpClient.SendAsync(datagram, datagram.Length, hostname, port);
		}

		public static Task<int> SendAsync(this UdpClient udpClient, byte[] datagram, DnsEndPoint dnsEndPoint)
		{
			if (udpClient == null) throw new ArgumentNullException("udpClient");
			if (dnsEndPoint == null) throw new ArgumentNullException("dnsEndPoint");
			return udpClient.SendAsync(datagram, datagram.Length, dnsEndPoint.Host, dnsEndPoint.Port);
		}
#endif
	}
}
