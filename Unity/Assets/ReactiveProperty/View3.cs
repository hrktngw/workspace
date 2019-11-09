using UnityEngine;
using System.Collections;
using UniRx;

namespace ReactiveProperySample
{
	public class View3 : MonoBehaviour
	{
		private ReadOnlyReactiveProperty<string> _property;

		public ReadOnlyReactiveProperty<string> Property {
			get {
				return _property;
			}
		}

		[SerializeField]
		private TextHistory _history;

		public void Init (IObservable<string> obs)
		{
			_property = new ReadOnlyReactiveProperty<string> (obs);
			_property.Subscribe (_ => _history.PushText (_));
		}
	}
}