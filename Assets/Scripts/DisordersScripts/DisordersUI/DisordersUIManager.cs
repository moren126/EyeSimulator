using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EyeSimulator.Disorders.UI {

	public class DisordersUIManager : TogglesMenuUIManager {

		[SerializeField] private GameObject beforeAfterToggles;
		[SerializeField] private GameObject planeButtons;
		[SerializeField] private GameObject imageHolder;

		[SerializeField] private Toggle beforeToggle;
		[SerializeField] private Toggle afterToggle;

		[SerializeField] private Toggle sagitalPlaneToggle;
		[SerializeField] private Toggle transversePlaneToggle;

		private DisordersSceneManager disordersSceneManager;

		private static DisordersUIManager instance;

		#region Properties
		public Toggle BeforeToggle {
			get { return beforeToggle; }
		}

		public Toggle AfterToggle {
			get { return afterToggle; }
		}

		public Toggle SagitalPlaneToggle {
			get { return sagitalPlaneToggle; }
		}

		public Toggle TransversePlaneToggle {
			get { return transversePlaneToggle; }
		}

		public static DisordersUIManager Instance {
			get {
				if (instance == null) {
					instance = FindObjectOfType<DisordersUIManager> ();

					if (!instance)
						Debug.LogError ("Did not find DisordersUIManager script on Gameobject in scene");
				}

				return instance;
			}
		}
		#endregion

		#region Protected Methods
		protected override void Start () {
			disordersSceneManager = DisordersSceneManager.Instance;

			base.Start ();
		}

		protected override void PrepareMenuCategories() {

			int categoryTypes = disordersSceneManager.DisordersCategories.DisordersCategoriesList.Count;

			for (int i = 0; i < categoryTypes; i++) {

				GameObject category = (GameObject)Instantiate (categoryWholePrefab, transform.position, Quaternion.identity);
				category.SetActive (true);
				category.name = disordersSceneManager.DisordersCategories.DisordersCategoriesList [i].Type.ToString ();
				category.transform.SetParent (menuContent.transform, true);
				category.transform.localScale = Vector3.one;
				category.transform.Find ("ToggleCategory").GetComponentInChildren<TextMeshProUGUI> ().text = disordersSceneManager.DisordersCategories.DisordersCategoriesList [i].Name;

				categoryList.Add (category);

				DisorderType statement = disordersSceneManager.DisordersCategories.DisordersCategoriesList [i].Type;

				int elements = 0;
				float height = 0;

				float spacing = category.GetComponent<VerticalLayoutGroup> ().spacing;

				switch (statement) {
				case DisorderType.REFRACTIVE_ERRORS:
					elements = disordersSceneManager.DisordersElements.RefractiveErrorsList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case DisorderType.DISEASES:
					elements = disordersSceneManager.DisordersElements.DiseasesList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				default:
					break;
				}

			}
				
		}

		protected override void PrepareElements() {

			int categoryTypes = categoryList.Count;

			for (int i = 0; i < categoryTypes; i++) {

				Transform categoryTransform;

				switch (categoryList[i].name) {

				case "REFRACTIVE_ERRORS":
					categoryTransform = categoryList [i].transform;

					foreach (var element in disordersSceneManager.DisordersElements.RefractiveErrorsList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.Name, categoryTransform);
						t.GetComponent<DisordersToggleScript>().Model = DisordersSceneManager.Instance.GetDisorderModel (element.DescriptionFileName);
						t.GetComponent<DisordersToggleScript> ().Sprite = (Sprite)Resources.Load ("Pictures/" + element.ImageName, typeof(Sprite));
						t.GetComponent<DisordersToggleScript> ().FileName = element.DescriptionFileName;
						t.GetComponent<DisordersToggleScript> ().IsRefractiveError = true;
					}
					break;
				case "DISEASES":
					categoryTransform = categoryList [i].transform;

					foreach (var element in disordersSceneManager.DisordersElements.DiseasesList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.Name, categoryTransform);
						t.GetComponent<DisordersToggleScript>().Model = DisordersSceneManager.Instance.GetDisorderModel (element.DescriptionFileName);
						t.GetComponent<DisordersToggleScript> ().Sprite = (Sprite)Resources.Load ("Pictures/" + element.ImageName, typeof(Sprite));
						t.GetComponent<DisordersToggleScript> ().FileName = element.DescriptionFileName;
						t.GetComponent<DisordersToggleScript> ().IsRefractiveError = false;
					}
					break;
				default:
					break;
				}
			}

		}
		#endregion

		#region Public Methods
		public void SetBeforeAfterToggles(bool isOn) {
			beforeAfterToggles.SetActive (isOn);
		}

		public void SetPlaneButtons(bool isOn) {
			planeButtons.SetActive (isOn);
		}

		public void SetImageHolder(bool isOn) {
			imageHolder.SetActive (isOn);
		}
		#endregion

	}

}