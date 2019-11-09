using UnityEngine;
using System.Collections;
using UniRx;

namespace ReactiveProperySample
{
	public class View2 : MonoBehaviour
	{
		private ReactiveProperty<string> _property;

		public ReactiveProperty<string> Property {
			get {
				return _property;
			}
		}

		[SerializeField]
		private TextHistory _history;

		public void Init (IObservable<string> obs)
		{
			_property = new ReactiveProperty<string> (obs);
			_property.Subscribe (_ => _history.PushText (_));
		}
	}
}