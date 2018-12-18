using UnityEngine;
using System.Collections.Generic;

namespace EyeSimulator.Anatomy {

	public class ButtonsManager : MonoBehaviour {

		public GameObject infoText;

		private Modes modes;
		private GameManager gm;

		private bool wholeModel;


		void Start () {
			modes = FindObjectOfType<Modes> ();
			gm = FindObjectOfType<GameManager> ();
			wholeModel = true;
		}

		#region Public Methods
		public void HelpTextOn() {
			if (!wholeModel)
				infoText.SetActive (true);
			else if (wholeModel)
				infoText.SetActive (false);
				
			wholeModel = !wholeModel;
		}
			
		public void BackToMenu () {
			ElementsVisibility.ClearAllElements ();
			gm.LoadScene("main");
		}

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