using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

namespace EyeSimulator.Disorders.UI {

	public class DisordersTextsManager : MonoBehaviour {

		[SerializeField] private GameObject descriptionUp;
		[SerializeField] private GameObject descriptionDown;

		private RaycastHit hit;
		private DisordersSceneManager disordersSceneManager;
		private static DisordersTextsManager instance;

		public static DisordersTextsManager Instance {
			get {
				if (!instance) {
					instance = FindObjectOfType<DisordersTextsManager> ();

					if (!instance)
						Debug.Log ("Did not find DisordersTextsManager script on GameObject in scene.");
				}

				return instance;
			}
		}

		void Start() {
			disordersSceneManager = FindObjectOfType<DisordersSceneManager> ();
		}

		void Update () {
			ShowHightLight ();
		}
			
		#region Private Methods
		private bool RayHitSthg() {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit))
				return true;
			else
				return false;
		}

		private void ShowHightLight () {
			if (RayHitSthg ()) {
				descriptionUp.SetActive (true);
				descriptionUp.GetComponentInChildren<TextMeshProUGUI> ().text = disordersSceneManager.GetDisorderFragment (hit.transform.name);
			} else {
				descriptionUp.GetComponentInChildren<TextMeshProUGUI> ().text = string.Empty;
				descriptionUp.SetActive (false);
			}
		}
		#endregion

		#region Public Methods
		public void ShowDescription(string disorder) {
			descriptionDown.SetActive (true);

			string path = "Descriptions/" + disorder;
			TextAsset textAsset = (TextAsset)Resources.Load (path, typeof(TextAsset));
			descriptionDown.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = textAsset.ToString();

			if (descriptionDown.GetComponentInChildren<Scrollbar> ())
				descriptionDown.GetComponentInChildren<Scrollbar> ().value = 1f;

		}

		public void HideDescription() {
			descriptionDown.SetActive (false);
		}
		#endregion

	}

}