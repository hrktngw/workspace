using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace TcpIp
{
	public class Client
	{
		bool _isListen;

		IPAddress _ipAdd;

		int _port = -1;

		int _readTimeout;

		int _writeTimeout;

		Socket _sender;

		System.IO.MemoryStream _memory;

		public System.Action<string> AcceptedReceiveMsg { set; private get; }
		public System.Action<string> ReceivedAction { set; private get; }

		public int Port {
			set {
				_port = value;
			}
		}

		public int ReadTimeout {
			set {
				_readTimeout = value;
			}
		}

		public int WriteTimeout {
			set {
				_writeTimeout = value;
			}
		}

		public string IpAddress {
			set {
				_ipAdd = IPAddress.Parse (value);
			}
		}

		public string HostName {
			set {
				_ipAdd = Dns.GetHostEntry (value).AddressList [0];
			}
		}

		private bool SanityCheck {
			get {
				return (_ipAdd != null && _sender == null && _port > 0);
			}
		}

		public Client () 
		{
		}

		~Client() {
			Close ();
		}

		public void Start ()
		{
			_sender = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint endPoint = new IPEndPoint (_ipAdd, _port);
			_sender.BeginConnect (endPoint, new System.AsyncCallback (ConnectCallBack), _sender);
		}

		private void ConnectCallBack (System.IAsyncResult ar)
		{
			Debug.LogError ("接続したよ。挨拶を送るね");
			Socket thisSender = (Socket)ar.AsyncState;
			thisSender.EndConnect (ar);
//
			StateObject state = new StateObject ();
			state.socket = thisSender;
//
//			if (AcceptedReceiveMsg != null) {
//				string msg = System.Text.Encoding.UTF8.GetString (state.buffer);
//				AcceptedReceiveMsg (msg);
//			}

			// 非同期データ受信開始
			thisSender.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None, new System.AsyncCallback(ReceiveDataCallBack), state);
		}

		public void Send (Socket thisSender)
		{
			byte[] byteData = System.Text.Encoding.UTF8.GetBytes ("こんにちは");
			_sender.BeginSend (byteData, 0, byteData.Length, 0, new System.AsyncCallback (SendCallBack), null);
		}

		private void ReceiveDataCallBack (System.IAsyncResult ar)
		{
			Socket thisSender = (Socket)ar.AsyncState;
			thisSender.EndConnect (ar);

			StateObject state = new StateObject ();
			state.socket = thisSender;

			if (AcceptedReceiveMsg != null) {
				string msg = System.Text.Encoding.UTF8.GetString (state.buffer);
				AcceptedReceiveMsg (msg);
			}
		}

		private void SendCallBack (System.IAsyncResult ar) {
			Debug.LogError ("送ったよ");
		}

		public void Close ()
		{
			if (_sender != null) {
				_sender.Close ();
			}
			_sender = null;
		}
	}
}