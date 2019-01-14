using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace EyeSimulator.Anatomy {

	public class AnatomyButtonsManager : ButtonsManager {

		[SerializeField] private Toggle viewModelWholeToggle;
		[SerializeField] private Toggle viewModelHalfToggle;
		[SerializeField] private Button resetButton;

		[SerializeField] private Toggle pinsToggle;

		private AnatomyModes modes;
		private AnatomyPinsManager anatomyPinsManager;
		private CameraZoom cameraZoom;

		private bool wasViewModelWhole = false;
		private bool wasViewModelHalf = false;

		protected override void Start () {
			base.Start ();
			modes = FindObjectOfType<AnatomyModes> ();
			anatomyPinsManager = FindObjectOfType<AnatomyPinsManager> ();
			cameraZoom = Camera.main.GetComponent<CameraZoom> ();
			viewModelWholeToggle.isOn = true;
		}

		#region Public Methods
		public void ViewModelWhole() {
			if (!wasViewModelWhole) {
				modes.ChangeState (0);

				viewModelHalfToggle.isOn = false;

				viewModelWholeToggle.interactable = false;
				viewModelHalfToggle.interactable = true;

				wasViewModelWhole = true;
				wasViewModelHalf = false;
			}
		}

		public void ViewModelHalf() {
			if (!wasViewModelHalf) {
				modes.ChangeState (1);

				viewModelWholeToggle.isOn = false;

				viewModelHalfToggle.interactable = false;
				viewModelWholeToggle.interactable = true;

				wasViewModelHalf = true;
				wasViewModelWhole = false;
			}
		}

		public void ResetPosition() {
			AnatomySceneManager.Instance.EyeSocketModel.transform.position = Vector3.zero;
			AnatomySceneManager.Instance.EyeSocketModel.transform.eulerAngles = AnatomySceneManager.Instance.StartingRotation;

			AnatomySceneManager.Instance.EyeSocketHalfModel.transform.position = Vector3.zero;
			AnatomySceneManager.Instance.EyeSocketHalfModel.transform.eulerAngles = AnatomySceneManager.Instance.StartingRotation;

			cameraZoom.ResetFov ();
		}

		public void PinsOn() {
			anatomyPinsManager.PinsOn ();
		}

		public void SetModelViewTogglesAndButtonActive(bool isActive) {
			viewModelWholeToggle.gameObject.SetActive (isActive);
			viewModelHalfToggle.gameObject.SetActive (isActive);
			resetButton.gameObject.SetActive (isActive);
		}

		public void SetPinToggleActive(bool isActive) {
			pinsToggle.gameObject.SetActive(isActive);
		}

		public void SetPinToggleOn(bool isOn) {
			pinsToggle.isOn = isOn;
		}
		#endregion

	}
		
}