using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using EyeSimulator.Anatomy.Data;

namespace EyeSimulator.Anatomy.UI {

	public class AnatomyTextsManager : MonoBehaviour {

		[SerializeField] private GameObject descriptionUp;
		[SerializeField] private GameObject descriptionRight;

		[SerializeField] private GameObject menuHolder;
		[SerializeField] private AnatomyButtonsManager anatomyButtonsManager;

		private AnatomyPinsManager pinsManager;
		private RaycastHit hit;
		private bool showName;

		#region MonoBehaviour Methods
		void Start () {
			pinsManager = FindObjectOfType<AnatomyPinsManager> ();

			SetDescriptions ();

			showName = true;
		}

		void Update () {
			if (showName)
				ShowDescription (descriptionUp);

		}
		#endregion

		#region Private Methods
		private void SetDescriptions() {
			descriptionUp.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, -40f);
			descriptionUp.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);

			descriptionRight.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-40, 0);
			descriptionRight.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (180f, -400f);
		}


		private bool RayHitSthg() {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit))
				return true;
			else
				return false;
		}

		private string GetDescription (string name) {

			// check in model elements
			foreach (var list in AnatomySceneManager.Instance.EyeElements.AllLists) {
				foreach (var element in list) {
					if (name == element.DescriptionFileName)
						return element.NamePolish;
				}
			}

			// check in pins
			foreach(Pin pin in pinsManager.Pins.PinsList) {
				if (name == pin.Name)
					return pin.Description;
			}

			return string.Empty;
		}
			
		private void ShowDescription (GameObject whereToShow) {

			if (RayHitSthg ()) {
				whereToShow.SetActive (true);
				whereToShow.GetComponentInChildren<TextMeshProUGUI> ().text = GetDescription (hit.transform.name);

			} else {
				whereToShow.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
				whereToShow.SetActive (false);
			}

		}
		#endregion

		#region Public Methods
		public void ShowFullDescription (string namePart) {
			anatomyButtonsManager.SetPinToggleOn (false);
			anatomyButtonsManager.SetPinToggleActive (false);

			descriptionUp.SetActive (false);
			showName = false;

			descriptionRight.SetActive (true);

			string path = "Descriptions/" + namePart;
			TextAsset textAsset = (TextAsset)Resources.Load (path, typeof(TextAsset));
			descriptionRight.GetComponentInChildren<TextMeshProUGUI>().text = textAsset.ToString();
		}

		public void SettOffFullDescription () {
			anatomyButtonsManager.SetPinToggleActive (true);
			descriptionRight.SetActive (false);
			showName = true;
		}

		public void SettOffLeftMenu () {
			anatomyButtonsManager.SetModelViewTogglesAndButtonActive (false);
			menuHolder.SetActive (false);
		}

		public void SettOnLeftMenu () {
			anatomyButtonsManager.SetModelViewTogglesAndButtonActive (true);
			menuHolder.SetActive (true);
		}
		#endregion

	}

}