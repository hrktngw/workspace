using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ヘッダー
/// </summary>
public class Header : MonoBehaviour
{
	Text _moneyLabel;

	public void UpdateLabel (int money)
	{
		_moneyLabel.text = money.ToString ();
	}
}
