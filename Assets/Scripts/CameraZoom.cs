using UnityEngine;

namespace EyeSimulator {

	public class CameraZoom : MonoBehaviour {

		[SerializeField] private float minFov = 40f;
		[SerializeField] private float maxFov = 70f;
		[SerializeField] private float sensitivity = 10f;

		private float startingFov;

		public float StartingFov {
			get { return startingFov; }
		}

		void Start() {
			startingFov = Camera.main.fieldOfView;
		}

		void Update () {
			float fov = Camera.main.fieldOfView;

			fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
			fov = Mathf.Clamp(fov, minFov, maxFov);

			Camera.main.fieldOfView = fov;
		}

	}

}