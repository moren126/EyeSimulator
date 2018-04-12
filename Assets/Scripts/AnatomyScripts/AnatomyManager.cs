using UnityEngine;
using System.Collections;

public class AnatomyManager : MonoBehaviour {

	public GameObject _eye;
	public GameObject _eyeHalf; 

	public int state;
	public int previousState;
	public bool wasStateChange;

	int GetState () {
		GameObject canvObj = GameObject.Find ("Main Canvas");
		Modes myMode = canvObj.GetComponent<Modes>();
		state = myMode.state;
		return state;
	}

	public void SetPosition() {

		if (GetState () == 0) {
			_eye.transform.position = new Vector3 (0, 0, 0);
			_eye.transform.eulerAngles = new Vector3 (0, 210, 0);

			_eyeHalf.transform.position = new Vector3 (0, 0, 0);
			_eyeHalf.transform.eulerAngles = new Vector3 (0, 210, 0);
		}
		else if (GetState () == 1) {
			_eyeHalf.transform.position = new Vector3 (0, 0, 0);
			_eyeHalf.transform.eulerAngles = new Vector3 (0, 210, 0);

			_eye.transform.position = new Vector3 (0, 0, 0);
			_eye.transform.eulerAngles = new Vector3 (0, 210, 0);
		}

		Camera.main.fieldOfView = 55f;
	}
		
	void Start () {
	}

	void Update () {
	}
}
