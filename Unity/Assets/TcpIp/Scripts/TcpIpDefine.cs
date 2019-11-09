using UnityEngine;
using System;
using System.Collections;

namespace TcpIp
{
	[Serializable]
	public class TcpIpDefine : MonoBehaviourSingleton<TcpIpDefine>
	{
		public string domain;

		public int port;

		//		protected TcpIpDefine () : base()
		//		{
		//			Debug.LogError ("Start");
		//			domain = PlayerPrefs.GetString ("domain");
		//			port = PlayerPrefs.GetInt ("port");
		//		}
		//
		private void Awake ()
		{
			domain = PlayerPrefs.GetString ("domain");
			port = PlayerPrefs.GetInt ("port");
		}

		private void OnDestroy ()
		{
			PlayerPrefs.SetString ("domain", domain);
			PlayerPrefs.SetInt ("port", port);
		}

		//		~TcpIpDefine ()
		//		{
		//			Debug.LogError ("Destroy");
		//			PlayerPrefs.SetString ("domain", domain);
		//			PlayerPrefs.SetInt ("port", port);
		//		}
	}

	public class StateObject
	{

		public const int BUFFER_SIZE = 1024;

		public System.Net.Sockets.Socket socket = null;

		public byte[] buffer = new byte[BUFFER_SIZE];
	}
}