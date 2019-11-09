using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TcpIp
{
	public class TcpIpInfoView : MonoBehaviour
	{
		[SerializeField]
		Button _closeBtn;
		[SerializeField]
		Text _domain;
		[SerializeField]
		Text _port;

		private void Start ()
		{
			_closeBtn.onClick.AddListener (() => {
				Destroy (gameObject);
			});
			_domain.text = TcpIpDefine.Instance.domain;
			_port.text = TcpIpDefine.Instance.port.ToString ();
		}

		public static void Create ()
		{
			TcpIpInfoView view = Resources.Load<TcpIpInfoView> ("TcpIpInfoView");
			Instantiate<TcpIpInfoView> (view);
		}
	}
}