using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using UnityEditor;

namespace ReactiveProperySample
{
	public class Presenter : MonoBehaviour
	{
		private ReactiveProperty<string> sendStr;

		[SerializeField]
		private View1 _view1;

		[SerializeField]
		private View2 _view2;

		[SerializeField]
		private View2 _view2_a;
		public View2 View2_a {
			get {
				return _view2_a;
			}
		}

		[SerializeField]
		private View3 _view3;

		[SerializeField]
		private TextHistory _history;

		[SerializeField]
		private Button _sendButton;

		[SerializeField]
		private Button _forceSendButton;


		[SerializeField]
		private InputField _sendText;

		void Start ()
		{
			sendStr = new ReactiveProperty<string> ();

			sendStr.Subscribe (_ => _history.PushText (_));

			_sendButton.onClick.AddListener (() => {
				sendStr.Value = _sendText.text;
			});
		}

		public void SubScribeSetting ()
		{
			// 独立
			_view1.Init (sendStr.Value);
			// これで連動する
//			sendStr.Subscribe (_ => _view1.Property.Value = _);



			// 連動する
			_view2.Init (sendStr);
//			sendStr.Subscribe (_ => _view2.Property.Value = _);

			// 連動する（where版）
			_view2_a.Init (sendStr.Where (_ => (_ != null) && _.StartsWith ("View3")));
			// 外部からセットできる
//			_view2_a.Property.Value = "hogehoge";

			// ReadOnlyReactiveProperty
			// 連動する（where版）
			_view3.Init (sendStr.Where (_ => (_ != null) && _.StartsWith ("View4")));
			// 外部からセットできない
//			_view3.Property.Value = "hogehoge";
		}
	}

	[CustomEditor (typeof(Presenter))]
	public class PresenterEditor : Editor
	{
		string sampleText = "";

		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			Presenter presenter = target as Presenter;
			if (GUILayout.Button ("SubScribe Setting")) {
				presenter.SubScribeSetting ();
			}

			GUILayout.BeginHorizontal ();
			sampleText = GUILayout.TextField (sampleText);
			if (GUILayout.Button ("over write")) {
				presenter.View2_a.Property.Value = "over write";
			}
			GUILayout.EndHorizontal ();
		}
	}
}
