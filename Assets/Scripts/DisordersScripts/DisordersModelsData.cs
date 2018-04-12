using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisordersModelsData : MonoBehaviour {

	public GameObject _myopiaEye;
	public GameObject _hyperopiaEye;
	public GameObject _astigEye;

	public GameObject _cataractaEye;
	public GameObject _hyphemaEye;
	public GameObject _uveitisEye;
	public GameObject _ablatioEye;

	public Image _picAfter, _picBeforeMyo, _picBeforeHyper, _picBeforeAstig;
	public Image _picCataract, _picHyphema, _picRetinal, _picUveitis;

	[HideInInspector]
	public GameObject _mRayBefore2, _mRayBefore3, _mRayAfter2, _mRayAfter3;
	[HideInInspector]
	public GameObject _hRayBefore2, _hRayBefore3, _hRayAfter2, _hRayAfter3;
	[HideInInspector]
	public GameObject _aRayBefore2, _aRayBefore3, _aRayAfter2, _aRayAfter3;
	[HideInInspector]
	public GameObject _aRayBefore4, _aRayBefore5, _aRayAfter4, _aRayAfter5;
	[HideInInspector]
	public GameObject _mLens, _hLens, _aLens;

	[HideInInspector]
	public List<GameObject> _models = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> _myopiaParts = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> _hyperopiaParts = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> _astigParts = new List<GameObject>();

	[HideInInspector]
	public List<GameObject> _astigSagital = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> _astigTransverse = new List<GameObject>();

	[HideInInspector]
	public Vector3 _myopiaPosition, _hyperopiaPosition, _astigPosition;
	[HideInInspector]
	public Vector3 _myopiaAngle, _hyperopiaAngle, _astigAngle;
	[HideInInspector]
	public Vector3 _cataractaPosition, _hyphemaPosition, _uveitisPosition, _ablatioPosition;
	[HideInInspector]
	public Vector3 _cataractaAngle, _hyphemaAngle, _uveitisAngle, _ablatioAngle;

	DisordersData _myopiaObj, _hyperopiaObj, _astigObj;
	DisordersData _cataractaObj, _hyphemaObj, _uveitisObj, _ablatioObj;
	public List<DisordersData> _disordersList = new List<DisordersData> ();


	void RememberPosition (GameObject model) {
		if (model.name == "MyopiaEye") {
			_myopiaPosition = model.transform.position;
			_myopiaAngle = model.transform.eulerAngles;
		} else if (model.name == "HyperopiaEye") {
			_hyperopiaPosition = model.transform.position;
			_hyperopiaAngle = model.transform.eulerAngles;
		} else if (model.name == "AstigmatismEye") {
			_astigPosition = model.transform.position;
			_astigAngle = model.transform.eulerAngles;
		} else if (model.name == "Cataract") {
			_cataractaPosition = model.transform.position;
			_cataractaAngle = model.transform.eulerAngles;
		} else if (model.name == "Hyphema") {
			_hyphemaPosition = model.transform.position;
			_hyphemaAngle = model.transform.eulerAngles;
		} else if (model.name == "Uveitis") {
			_uveitisPosition = model.transform.position;
			_uveitisAngle = model.transform.eulerAngles;
		} else if (model.name == "Ablatio") {
			_ablatioPosition = model.transform.position;
			_ablatioAngle = model.transform.eulerAngles;
		}
	}


	void AssignChildren(GameObject model) {

		foreach (Transform child in model.transform) {

			if (child.name == "cBefore2") {
				if (model.name == "MyopiaEye") {
					_mRayBefore2 = child.gameObject;
					_myopiaParts.Add (_mRayBefore2);
				} else if (model.name == "HyperopiaEye") {
					_hRayBefore2 = child.gameObject;
					_hyperopiaParts.Add (_hRayBefore2);
				} else if (model.name == "AstigmatismEye") {
					_aRayBefore2 = child.gameObject;
					_astigParts.Add (_aRayBefore2);
				}
			} else if (child.name == "cBefore3") {
				if (model.name == "MyopiaEye") {
					_mRayBefore3 = child.gameObject;
					_myopiaParts.Add (_mRayBefore3);
				} else if (model.name == "HyperopiaEye") {
					_hRayBefore3 = child.gameObject;
					_hyperopiaParts.Add (_hRayBefore3);
				} else if (model.name == "AstigmatismEye") {
					_aRayBefore3 = child.gameObject;
					_astigParts.Add (_aRayBefore3);
				}
			} else if (child.name == "cAfter2") {
				if (model.name == "MyopiaEye") {
					_mRayAfter2 = child.gameObject;
					_myopiaParts.Add (_mRayAfter2);
				} else if (model.name == "HyperopiaEye") {
					_hRayAfter2 = child.gameObject;
					_hyperopiaParts.Add (_hRayAfter2);
				} else if (model.name == "AstigmatismEye") {
					_aRayAfter2 = child.gameObject;
					_astigParts.Add (_aRayAfter2);
				}
			} else if (child.name == "cAfter3") {
				if (model.name == "MyopiaEye") {
					_mRayAfter3 = child.gameObject;
					_myopiaParts.Add (_mRayAfter3);
				} else if (model.name == "HyperopiaEye") {
					_hRayAfter3 = child.gameObject;
					_hyperopiaParts.Add (_hRayAfter3);
				} else if (model.name == "AstigmatismEye") {
					_aRayAfter3 = child.gameObject;
					_astigParts.Add (_aRayAfter3);
				}
			} else if (child.name == "cCorrectiveLens") {
				if (model.name == "MyopiaEye") {
					_mLens = child.gameObject;
					_myopiaParts.Add (_mLens);
				} else if (model.name == "HyperopiaEye") {
					_hLens = child.gameObject;
					_hyperopiaParts.Add (_hLens);
				} else if (model.name == "AstigmatismEye") {
					_aLens = child.gameObject;
					_astigParts.Add (_aLens);
				}
			} else if (child.name == "cBefore4") {
				_aRayBefore4 = child.gameObject;
				_astigParts.Add (_aRayBefore4);
			} else if (child.name == "cBefore5") {
				_aRayBefore5 = child.gameObject;
				_astigParts.Add (_aRayBefore5);
			} else if (child.name == "cAfter4") {
				_aRayAfter4 = child.gameObject;
				_astigParts.Add (_aRayAfter4);
			} else if (child.name == "cAfter5") {
				_aRayAfter5 = child.gameObject;
				_astigParts.Add (_aRayAfter5);
			} 
		}
	}

	void Astig(GameObject model) {
		foreach (Transform child in model.transform) {
			if (child.name.StartsWith ("a"))
				_astigTransverse.Add (child.gameObject);
			else if (child.name.StartsWith ("b"))
				_astigSagital.Add (child.gameObject);
		}
	}

	void PrepareDisorders () {
		GameObject[] tempBefore = new GameObject[] {_mRayBefore2, _mRayBefore3}; 
		GameObject[] tempAfter = new GameObject[] {_mRayAfter2, _mRayAfter3, _mLens};
		_myopiaObj = new DisordersData ("myopia", "myopiaToggle", tempBefore, tempAfter, _myopiaPosition, _myopiaAngle, true, false, _picBeforeMyo);

		tempBefore = new GameObject[] {_hRayBefore2, _hRayBefore3}; 
		tempAfter = new GameObject[] {_hRayAfter2, _hRayAfter3, _hLens};
		_hyperopiaObj = new DisordersData ("hyperopia", "hyperopiaToggle", tempBefore, tempAfter, _hyperopiaPosition, _hyperopiaAngle, true, false, _picBeforeHyper);

		tempBefore = new GameObject[] {_aRayBefore2, _aRayBefore3, _aRayBefore4, _aRayBefore5}; 
		tempAfter = new GameObject[] {_aRayAfter2, _aRayAfter3, _aRayAfter4, _aRayAfter5, _aLens};
		_astigObj = new DisordersData ("astig", "astigmatismToggle", tempBefore, tempAfter, _astigPosition, _astigAngle, true, true, _picBeforeAstig); 
			
		tempBefore = new GameObject[] { };
		tempAfter = new GameObject[] { };
		_cataractaObj = new DisordersData ("cataracta", "oth1Toggle", tempBefore, tempAfter, _cataractaPosition, _cataractaAngle, false, false, _picCataract);

		_hyphemaObj = new DisordersData ("hyphema", "oth2Toggle", tempBefore, tempAfter, _hyphemaPosition, _hyphemaAngle, false, false, _picHyphema);
		_uveitisObj = new DisordersData ("uveitis", "oth3Toggle", tempBefore, tempAfter, _uveitisPosition, _uveitisAngle, false, false, _picUveitis);
		_ablatioObj = new DisordersData ("ablatio", "oth4Toggle", tempBefore, tempAfter, _ablatioPosition, _ablatioAngle, false, false, _picRetinal);
	}

	void MakeDisordersList () {
		PrepareDisorders ();

		_disordersList.AddRange (new DisordersData[] {_myopiaObj, _hyperopiaObj, _astigObj, _cataractaObj, _hyphemaObj, _uveitisObj, _ablatioObj});
	}

	void Start () {
		AssignChildren (_myopiaEye);
		AssignChildren (_hyperopiaEye);
		AssignChildren (_astigEye);

		Astig (_astigEye);

		RememberPosition (_myopiaEye);
		RememberPosition (_hyperopiaEye);
		RememberPosition (_astigEye);
		RememberPosition (_cataractaEye);
		RememberPosition (_hyphemaEye);
		RememberPosition (_uveitisEye);
		RememberPosition (_ablatioEye);

		_models.Add (_myopiaEye);
		_models.Add (_hyperopiaEye);
		_models.Add (_astigEye);
		_models.Add (_cataractaEye);
		_models.Add (_hyphemaEye);
		_models.Add (_uveitisEye);
		_models.Add (_ablatioEye);

		foreach (GameObject g in _models)
			g.SetActive (false);
	
		MakeDisordersList ();
	}

	void Update () {
	
	}
}
