using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UniRx;

/// <summary>
/// データを取り扱うモデル
/// </summary>
[Serializable]
public class Model
{
	public IntReactiveProperty index;
	public ReactiveProperty<Data> currentData;
	[SerializeField]
	private List<Data> _datas;

	public Model ()
	{
		index = new IntReactiveProperty ();
		currentData = new ReactiveProperty<Data> ();
		_datas = new List<Data> ();

		index.Do (_ => {
			Debug.LogError ("Change index");
		}).Subscribe (_ => {
			currentData.Value = _datas.ElementAtOrDefault (_);
		});
	}

	public int maxIndex {
		get {
			return _datas.Count - 1;
		}
	}

	public void AddData (Data data)
	{
		Data newData = new Data ();
		newData.Set (data);
		_datas.Add (newData);
	}

	~Model ()
	{
		index.Dispose ();
		currentData.Dispose ();
		_datas.Clear ();
	}
}

/// <summary>
/// データ
/// </summary>
[Serializable]
public class Data
{
	public int id;
	public string name;

	public void Set (Data data)
	{
		if (data == null) {
			return;
		}
		id = data.id;
		name = data.name;
	}
}
