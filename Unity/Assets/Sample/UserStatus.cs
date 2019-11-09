using UnityEngine;
using System.Collections;

/// <summary>
/// ユーザー情報
/// </summary>
public class UserStatus
{
	int _money;

	public void UpdateMoney (int money)
	{
		_money = money;
	}
}
