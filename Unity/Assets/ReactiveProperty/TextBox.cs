using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ReactiveProperySample
{
	public class TextBox : MonoBehaviour
	{
		[SerializeField]
		private Text _mainText;

		public string Text {
			set {
				_mainText.text = value;
			}
		}
	}
}