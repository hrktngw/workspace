using UnityEngine;
using System.Collections;

namespace TcpIp
{
	public class ServerListener : MonoBehaviourSingleton<ServerListener>
	{
		public Server _server;

		private void Start ()
		{
			_server = new Server ();
		}
	}
}
