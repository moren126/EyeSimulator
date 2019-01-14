using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using EyeSimulator.Disorders.UI;

namespace EyeSimulator.Disorders {

	public class DisordersToggleScript : MonoBehaviour {

		private DisordersUIManager disordersUIManager;
		private DisordersButtonsManager buttonsDisorderManager;
		private DisordersTextsManager disordersTextsManager;
		private GameObject model;
		private Sprite sprite;
		private string fileName;
		private bool isRefractiveError;

		private Toggle toggle;

		#region Properties
		public GameObject Model {
			get { return model; }
			set { model = value; }
		}

		public Sprite Sprite {
			get { return sprite; }
			set { sprite = value; }
		}

		public string FileName {
			set { fileName = value; }
		}

		public bool IsRefractiveError {
			set { isRefractiveError = value; }
		}
		#endregion


		void Start() {
			disordersUIManager = DisordersUIManager.Instance;
			buttonsDisorderManager = DisordersButtonsManager.Instance;
			disordersTextsManager = DisordersTextsManager.Instance;
			toggle = GetComponent<Toggle> ();
		}

		void Update() {
			CheckToggle ();
		}

		private void CheckToggle () {

			toggle.onValueChanged.AddListener ((bool on) => {

				model.SetActive (on);
				model.GetComponent<DisordersModelMovement>().ResetPosition();

				if (on == false) {
					disordersTextsManager.HideDescription();
					disordersUIManager.SetImageHolder(false);
					disordersUIManager.SetPlaneButtons(false);
					disordersUIManager.SetBeforeAfterToggles(false);
				} else if (on == true) {

					// max one toggle can be active
					foreach (Toggle t in disordersUIManager.TogglesList) {
						if (t != toggle)
							t.isOn = false;
					}

					disordersTextsManager.ShowDescription(fileName);
					disordersUIManager.SetImageHolder(true);

					if (isRefractiveError) {

						if (toggle.name == "dAstig") {
							disordersUIManager.SetPlaneButtons(true);
							disordersUIManager.SagitalPlaneToggle.isOn = true;
						} else {
							disordersUIManager.SetPlaneButtons(false);
						}

						disordersUIManager.SetBeforeAfterToggles(true);

						disordersUIManager.AfterToggle.isOn = true;
						disordersUIManager.BeforeToggle.isOn = true;

					}
					else {
						buttonsDisorderManager.SetImage(toggle.GetComponent<DisordersToggleScript> ().Sprite);
					}

				}

			});

		}

	}

}