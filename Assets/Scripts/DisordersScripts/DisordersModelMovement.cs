using UnityEngine;

namespace EyeSimulator.Disorders {

	public class DisordersModelMovement : MonoBehaviour {

		private Vector3 positionStart;
		private Vector3 eulerAnglesStart;
		private CameraZoom cameraZoom;

		void Awake() {
			positionStart = transform.position;
			eulerAnglesStart = transform.eulerAngles;	
			cameraZoom = Camera.main.GetComponent<CameraZoom> ();
		}

		void Update () {
			Quaternion rotateUp = Quaternion.AngleAxis(Input.GetAxis ("Horizontal") * (-1), Vector3.up);
			transform.rotation = transform.rotation * rotateUp;
			Quaternion rotateBack = Quaternion.AngleAxis(Input.GetAxis ("Vertical") * 1, Vector3.back);
			transform.rotation = transform.rotation * rotateBack;
		}

		public void ResetPosition() {
			transform.position = positionStart;
			transform.eulerAngles = eulerAnglesStart;
			cameraZoom.ResetFov ();
		}

	}

}