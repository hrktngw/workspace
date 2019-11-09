using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class CulumnPresenter : MonoBehaviour
{
	private Data _model;

	public Data Model {
		set {
			_model.Set (value);
			_idLabel.text = "id: " + _model.id;
			_nameLabel.text = "name: " + _model.name;
		}
		get {
			return _model;
		}
	}

	[SerializeField]
	private Text _idLabel;
	[SerializeField]
	private Text _nameLabel;
	[SerializeField]
	private Button _selectButton;

	public int index;
	public Action<int> selectButtonAction;

	void Awake ()
	{
		_model = new Data ();
	}

	// Use this for initialization
	void Start ()
	{
		_selectButton.onClick.AddListener (() => {
			if (_model != null) {
				selectButtonAction (index);
			}
		});
	}
}
