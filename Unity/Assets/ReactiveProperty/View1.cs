using UnityEngine;
using System.Collections;
using UniRx;

namespace ReactiveProperySample
{
	public class View1 : MonoBehaviour
	{
		private StringReactiveProperty _property;

		public StringReactiveProperty Property {
			get {
				return _property;
			}
		}

		[SerializeField]
		private TextHistory _history;

		public void Init (string str)
		{
			_property = new StringReactiveProperty(str);
			_property.Subscribe (_ => _history.PushText (_));
		}
	}
}