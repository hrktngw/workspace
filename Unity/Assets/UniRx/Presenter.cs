using UnityEngine;
using System.Collections;
using UniRx;

public class Presenter : MonoBehaviour
{
	[SerializeField]
	private Model _model;

	[SerializeField]
	private ChildPresenter _child;

	[SerializeField]
	private GameObject culumnPrefab;

	[SerializeField]
	private GameObject _culumnContainer;

	void Start ()
	{
		_model = new Model ();

		_child.addCulumnAction = () => {
			GameObject go = Instantiate (culumnPrefab);
			go.transform.SetParent (_culumnContainer.transform, false);

			CulumnPresenter culumn = go.GetComponent<CulumnPresenter> ();
			culumn.Model = _child.Model;

			_model.AddData(culumn.Model);
			culumn.index = _model.maxIndex;

			culumn.selectButtonAction = (index) => {
				_model.index.Value = index;
			};
		};

		_model.currentData.Do (_ => {
			Debug.LogError ("Change Data");
		}).Subscribe (_ => {
			_child.Model = _;
		});
	}
}
