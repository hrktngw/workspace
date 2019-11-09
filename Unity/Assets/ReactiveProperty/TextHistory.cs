using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ReactiveProperySample
{
	public class TextHistory : MonoBehaviour
	{
		[SerializeField]
		private TextBox _textPrefab;
		[SerializeField]
		private GameObject _container;

		public void PushText (string str)
		{
			TextBox go = Instantiate<TextBox> (_textPrefab);
			go.transform.SetParent (_container.transform, false);
			if (string.IsNullOrEmpty (str)) {
				str = "<i>''' Empty '''</i>";
			}
			go.Text = str;
		}

		public void Clear ()
		{
			foreach (Transform t in _container.transform) {
				DestroyImmediate (t.gameObject);
			}
		}
	}

	[CustomEditor (typeof(TextHistory))]
	public class TextHistoryEditor : Editor
	{
		private string sampleText = "";
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			TextHistory history = target as TextHistory;
			GUILayout.BeginHorizontal ();
			sampleText = GUILayout.TextField (sampleText);
			if (GUILayout.Button ("Push")) {
				if (!string.IsNullOrEmpty (sampleText)) {
					history.PushText (sampleText);
				}
			}
			GUILayout.EndHorizontal ();
			if (GUILayout.Button ("Clean")) {
				history.Clear ();
			}
		}
	}
}
