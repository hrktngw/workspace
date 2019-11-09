using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChildPresenter : MonoBehaviour
{
	[SerializeField]
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
	private Button _addCulumn;

	public System.Action addCulumnAction;

	void Awake ()
	{
		_model = new Data ();
	}

	void Start ()
	{
		_addCulumn.onClick.AddListener (() => {
			addCulumnAction ();
		});
	}
}
