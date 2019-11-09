using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;

namespace TcpIp
{
	public class Chat : MonoBehaviour
	{
		public string _logs;
		private Client _client;
		private Server _server;
		public Button _infoBtn;
		public Text _log;
		[SerializeField]
		InputField _sendMsg;

		[SerializeField]
		Button _connectBtn;

		[SerializeField]
		Button _sendBtn;

		private void Start ()
		{
			this.ObserveEveryValueChanged (_ => _._logs)
				.Subscribe (_ => _log.text = _);
			
			_connectBtn.onClick.AddListener (() => {
				Connect ();
			});
			_infoBtn.onClick.AddListener (() => {
				TcpIpInfoView.Create ();
			});
			_server = new Server ();

			_server.AcceptedSendMsg = () => { return this._logs; };
			_server.IpAddress = TcpIpDefine.Instance.domain;
			_server.Port = TcpIpDefine.Instance.port;
			_server.Start ();
		}

		private void Connect ()
		{
			if (_client != null) {
				return;
			}

			_client = new Client ();
			_client.IpAddress = TcpIpDefine.Instance.domain;
			_client.Port = TcpIpDefine.Instance.port;
			_client.AcceptedReceiveMsg = (string msg) => {
				Debug.LogError(msg);
				_logs += msg;
			};
			_client.Start ();
		}
	}
}