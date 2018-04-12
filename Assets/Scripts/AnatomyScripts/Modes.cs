using UnityEngine;
using System.Collections;

public class Modes : MonoBehaviour {

	public int state;
	public int previousState;
	public bool wasStateChange;
	public bool pinsMode;
	public int gameMode;

	private ModelManager _modelManagerInstance;

	void Start () {
		GameObject _modelsObject = GameObject.Find("Models");
		_modelManagerInstance = _modelsObject.GetComponent<ModelManager>();

		state = 0;
		previousState = 0;
		wasStateChange = false;

		pinsMode = false;
		gameMode = 0;
	}

	void Update () {
		
		if (previousState != state) {
			wasStateChange = true;
			previousState = state;
		}
			
		if (state == 0) {
			_modelManagerInstance._orbit.SetActive (true);
			_modelManagerInstance._halfOrbit.SetActive (false);
		} else if (state == 1) {
			_modelManagerInstance._orbit.SetActive (false);
			_modelManagerInstance._halfOrbit.SetActive (true);
		}
	}

	public void ChangeState(int desiredState) {
		state = desiredState;
	}
}
