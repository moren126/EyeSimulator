using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public float _minFov;
	private float _maxFov;
	private float _sensitivity;

	void Start () {
		_minFov = 40f;
		_maxFov = 55f;
		_sensitivity = 10f;	
	}

	// obsluga zoom'a
	void Update () {
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * _sensitivity;
		fov = Mathf.Clamp(fov, _minFov, _maxFov);
		Camera.main.fieldOfView = fov;
	}
}
