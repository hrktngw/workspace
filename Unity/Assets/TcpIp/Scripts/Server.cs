using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TcpIp
{
	public class Server
	{
		bool _isListen;

		IPAddress _ipAdd;

		int _port = -1;

		int _readTimeout;

		int _writeTimeout;

		Socket _listener;

		public int Port {
			set {
				_port = value;
			}
		}

		public System.Func<string> AcceptedSendMsg { set; private get; }

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
				return (_ipAdd != null && _listener == null && _port > 0);
			}
		}

		public event System.Action<string> onReveiveMsg;

		public Server ()
		{
			_isListen = false;
			_port = -1;
		}

		~Server ()
		{
			Stop ();
		}

		public void Start ()
		{
			if (_isListen) {
				return;
			}
			if (!SanityCheck) {
				Debug.LogError ("invalid !!");
				return;
			}
			_isListen = true;
			IPEndPoint localEndPoint = new IPEndPoint (_ipAdd, _port);

			_listener = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try {
				_listener.Bind (localEndPoint);
				_listener.Listen (100);
				_listener.BeginAccept (new System.AsyncCallback (AcceptCallback), _listener);
				Debug.LogError ("待機スタート");
			} catch (System.Exception e) {
				Debug.LogError ("error");
			}
		}

		private void AcceptCallback (System.IAsyncResult ar)
		{
			Debug.LogError ("接続要求が来たよ");
			// クライアントからの接続を承認
			Socket thiListener = (Socket)ar.AsyncState;
			Socket handler = thiListener.EndAccept (ar);

			StateObject state = new StateObject ();
			state.socket = handler;

			string msg = string.Empty;
			if (AcceptedSendMsg != null) {
				msg = AcceptedSendMsg ();
			}
			state.buffer = System.Text.Encoding.UTF8.GetBytes (msg);
			handler.BeginReceive (state.buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None, new System.AsyncCallback (ReceiveDataCallBack), state);
		}

		private void ReceiveDataCallBack (System.IAsyncResult ar)
		{
			Debug.LogError ("Clientから文字列が来たよ");
//
//			StateObject state = (StateObject)ar.AsyncState;
//			Socket socket = state.socket;
//
//			int bytesRead = socket.EndAccept (ar);
//
//			if (bytesRead > 0) {
//				string msg = System.Text.Encoding.UTF8.GetString (state.buffer, 0, bytesRead);
//			}

		}

		public void Stop ()
		{
			if (!_isListen) {
				return;
			}

			_isListen = false;
			_listener = null;
		}
	}
}