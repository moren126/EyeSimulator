using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PinsManager : MonoBehaviour {

	public Text _infoText;
	public GameObject _pinBackPole;
	public GameObject _pinCanalis;
	public GameObject _pinEquator;
	public GameObject _pinFOInferior;
	public GameObject _pinFOSuperior;
	public GameObject _pinFrontPole;
	public GameObject _pinInferiorWall;
	public GameObject _pinLateralWall;
	public GameObject _pinMedialWall;
	public GameObject _pinSuperiorWall;
	public GameObject _pinBackPoleH;
	public GameObject _pinEquatorH;
	public GameObject _pinFOInferiorH;
	public GameObject _pinFrontPoleH;
	public GameObject _pinInferiorWallH;
	public GameObject _pinLateralWallH;
	public GameObject _pinSuperiorWallH;
	public List <GameObject> _pinsStack = new List<GameObject> ();

	private bool _infoState;

	void SetPinStack () {
		_pinsStack.Add (_pinBackPole);
		_pinsStack.Add (_pinCanalis);
		_pinsStack.Add (_pinEquator);
		_pinsStack.Add (_pinFOInferior);
		_pinsStack.Add (_pinFOSuperior);
		_pinsStack.Add (_pinFrontPole);
		_pinsStack.Add (_pinInferiorWall);
		_pinsStack.Add (_pinLateralWall);
		_pinsStack.Add (_pinMedialWall);
		_pinsStack.Add (_pinSuperiorWall);
		_pinsStack.Add (_pinBackPoleH);
		_pinsStack.Add (_pinEquatorH);
		_pinsStack.Add (_pinFOInferiorH);
		_pinsStack.Add (_pinFrontPoleH);
		_pinsStack.Add (_pinInferiorWallH);
		_pinsStack.Add (_pinLateralWallH);
		_pinsStack.Add (_pinSuperiorWallH);

		foreach (GameObject item in _pinsStack)
			item.SetActive (false);
	}

	public void PinsOn () {
		GameObject canvObj = GameObject.Find ("Main Canvas");
		Modes myMode = canvObj.GetComponent<Modes>();

		if (!myMode.pinsMode)
			myMode.pinsMode = true;
		else
			myMode.pinsMode = false;

		foreach (GameObject item in _pinsStack)
			item.SetActive (myMode.pinsMode);

	}

	public void InfoOn() {
		if (!_infoState)
			_infoText.gameObject.SetActive (true);
		else if (_infoState)
			_infoText.gameObject.SetActive (false);
			
		_infoState = !_infoState;
	}

	void Start () {
		_infoState = true;
		SetPinStack ();
	}

	void Update () {
	}
}
