using UnityEngine;
using System.Collections.Generic;

namespace EyeSimulator.Anatomy {

	public class ButtonsAnatomyManager : ButtonsManager {

		private Modes modes;

		protected override void Start () {
			base.Start ();
			modes = FindObjectOfType<Modes> ();
		}

		#region Public Methods
		public void ViewModelWhole() {
			modes.ChangeState (0);
		}

		public void ViewModelHalf() {
			modes.ChangeState (1);
		}

		public void ResetPosition() {
			AnatomySceneManager.Instance.EyeSocketModel.transform.position = Vector3.zero;
			AnatomySceneManager.Instance.EyeSocketModel.transform.eulerAngles = AnatomySceneManager.Instance.StartingRotation;

			AnatomySceneManager.Instance.EyeSocketHalfModel.transform.position = Vector3.zero;
			AnatomySceneManager.Instance.EyeSocketHalfModel.transform.eulerAngles = AnatomySceneManager.Instance.StartingRotation;

			Camera.main.fieldOfView = Camera.main.GetComponent<CameraZoom> ().StartingFov;
		}
		#endregion

	}
		
}