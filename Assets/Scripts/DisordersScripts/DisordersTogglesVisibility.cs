using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisordersTogglesVisibility : MonoBehaviour {

	public Toggle _REFRACTIVETOGGLE;
	public Toggle _OTHERTOGGLE;

	public Toggle _myopiaToggle;
	public Toggle _hyperopiaToggle;
	public Toggle _astigmatismToggle;

	public Toggle _othToggle1;
	public Toggle _othToggle2;
	public Toggle _othToggle3;
	public Toggle _othToggle4;

	private DisordersTogglesLists _disTogglesListsInstance;
	private bool _isRefractive, _isOther;
	private int _distanceOth;


	void SetList(string name, List<Toggle> list) {
		if (name == "refractive") {
			list.Add (_REFRACTIVETOGGLE);
			list.Add (_myopiaToggle);
			list.Add (_hyperopiaToggle);
			list.Add (_astigmatismToggle);
		}
		if (name == "other") {
			list.Add (_OTHERTOGGLE);
			list.Add (_othToggle1);
			list.Add (_othToggle2);
			list.Add (_othToggle3);
			list.Add (_othToggle4);
		} 
	}

	void Start () {
		_disTogglesListsInstance = GetComponent<DisordersTogglesLists> ();

		_isRefractive = true;
		_isOther = true;

		SetList ("refractive", _disTogglesListsInstance._refractiveNonVisibility);
		SetList ("other", _disTogglesListsInstance._otherNonVisibility);

		_distanceOth = 80;
	}

	void Update () {
		_isRefractive = _REFRACTIVETOGGLE.isOn;
		_isOther = _OTHERTOGGLE.isOn;
	}

	void ChangeLocalPositions (List<Toggle> partsMove, int distance) {
		foreach (Toggle t in partsMove)
			t.transform.localPosition = new Vector3 (t.transform.localPosition.x, (t.transform.localPosition.y + distance), t.transform.localPosition.z);
	}

	public void SetRefractive () {

		if (_isRefractive) {

			for (int x = 1; x < _disTogglesListsInstance._refractiveNonVisibility.Count; x++) {
				_disTogglesListsInstance._refractiveNonVisibility [x].isOn = false;
				_disTogglesListsInstance._refractiveNonVisibility [x].gameObject.SetActive (false);
			}
				
			ChangeLocalPositions (_disTogglesListsInstance._otherNonVisibility, _distanceOth);

		} else {
			for (int x = 1; x < _disTogglesListsInstance._refractiveNonVisibility.Count; x++)
				_disTogglesListsInstance._refractiveNonVisibility [x].gameObject.SetActive (true);

			ChangeLocalPositions (_disTogglesListsInstance._otherNonVisibility, -_distanceOth);
		}
	}

	public void SetOther () {

		if (_isOther) {

			for (int x = 1; x < _disTogglesListsInstance._otherNonVisibility.Count; x++) {
				_disTogglesListsInstance._otherNonVisibility [x].isOn = false;
				_disTogglesListsInstance._otherNonVisibility [x].gameObject.SetActive (false);
			}

		} else {
			for (int x = 1; x < _disTogglesListsInstance._otherNonVisibility.Count; x++)
				_disTogglesListsInstance._otherNonVisibility [x].gameObject.SetActive (true);
		}
	}

}

