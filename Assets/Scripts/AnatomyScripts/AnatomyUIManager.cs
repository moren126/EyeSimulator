using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EyeSimulator.Anatomy.Toggles;

namespace EyeSimulator.Anatomy {

	public class AnatomyUIManager : MonoBehaviour {

		[SerializeField] private GameObject categoryWholePrefab;
		[SerializeField] private GameObject toggleElementPrefab;

		private GameObject menuContent;
		private float spacingCategory;
		private List<GameObject> categoryList = new List<GameObject> ();

		private List<Toggle> togglesList = new List<Toggle> ();
		public List<Toggle> ToggleList {
			get { return togglesList; }
		}

		void Start () {
			menuContent = transform.Find("MenuHolder").GetChild (0).GetChild(0).gameObject;
			spacingCategory = menuContent.GetComponent<VerticalLayoutGroup> ().spacing;

			PrepareMenu ();
		}

		void Update () {
			
		}

		private void PrepareMenu() {

			PrepareMenuCategories ();

			SetMenuContentHeight ();

			PrepareElements ();

		}

		private void PrepareMenuCategories() {
			
			int categoryTypes = AnatomySceneManager.Instance.EyeCategories.EyeCategoriesList.Count;

			for (int i = 0; i < categoryTypes; i++) {

				GameObject category = (GameObject)Instantiate (categoryWholePrefab, transform.position, Quaternion.identity);
				category.SetActive (true);
				category.name = AnatomySceneManager.Instance.EyeCategories.EyeCategoriesList[i].Type.ToString();
				category.transform.SetParent (GameObject.Find("MenuContent").transform, true);
				category.transform.localScale = Vector3.one;

				category.transform.Find ("ToggleCategory").GetComponentInChildren<TextMeshProUGUI> ().text = AnatomySceneManager.Instance.EyeCategories.EyeCategoriesList [i].NamePolish;

				categoryList.Add (category);

				EyeCategory statement = AnatomySceneManager.Instance.EyeCategories.EyeCategoriesList [i].Type;

				int elements = 0;
				float height = 0;

				float spacing = category.GetComponent<VerticalLayoutGroup> ().spacing;

				switch (statement) {
				case EyeCategory.EYESOCKET:
					elements = AnatomySceneManager.Instance.EyeElements.EyeSocketList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.MUSCLES:
					elements = AnatomySceneManager.Instance.EyeElements.MusclesList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.NERVES:
					elements = AnatomySceneManager.Instance.EyeElements.NervesList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.EYEBALL:
					elements = AnatomySceneManager.Instance.EyeElements.EyeballList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.OTHER:
					elements = AnatomySceneManager.Instance.EyeElements.OtherList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				default:
					break;
				}
					
			}
		}

		private void SetMenuContentHeight () {

			float menuContentHeight = 0;

			int children = menuContent.transform.childCount;

			for (int i = 0; i < children; i++)
				menuContentHeight += menuContent.transform.GetChild (i).GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;

			menuContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menuContent.GetComponent<RectTransform> ().sizeDelta.x, menuContentHeight);
		}

		private GameObject InstantiateToggleElement(string nameHierachy, string nameToShow, Transform parentTransform) {
			GameObject toggle = (GameObject)Instantiate (toggleElementPrefab, transform.position, Quaternion.identity);
			toggle.SetActive (true);
			toggle.name = nameHierachy;
			toggle.transform.SetParent (parentTransform, true);
			toggle.transform.localScale = Vector3.one;

			toggle.GetComponentInChildren<TextMeshProUGUI> ().text = nameToShow;

			togglesList.Add (toggle.GetComponent<Toggle>());

			return toggle;
		}

		private void PrepareElements() {

			int categoryTypes = categoryList.Count;

			for (int i = 0; i < categoryTypes; i++) {

				Transform categoryTransform;

				switch (categoryList[i].name) {

				case "EYESOCKET":
					categoryTransform = categoryList [i].transform;

					foreach (var element in AnatomySceneManager.Instance.EyeElements.EyeSocketList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript>().Part = AnatomySceneManager.Instance.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript>().PartH = AnatomySceneManager.Instance.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "MUSCLES":
					categoryTransform = categoryList [i].transform;

					foreach (var element in AnatomySceneManager.Instance.EyeElements.MusclesList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = AnatomySceneManager.Instance.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = AnatomySceneManager.Instance.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "NERVES":
					categoryTransform = categoryList [i].transform;

					foreach (var element in AnatomySceneManager.Instance.EyeElements.NervesList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = AnatomySceneManager.Instance.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = AnatomySceneManager.Instance.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "EYEBALL":
					categoryTransform = categoryList [i].transform;

					foreach (var element in AnatomySceneManager.Instance.EyeElements.EyeballList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = AnatomySceneManager.Instance.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = AnatomySceneManager.Instance.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "OTHER":
					categoryTransform = categoryList [i].transform;

					foreach (var element in AnatomySceneManager.Instance.EyeElements.OtherList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = AnatomySceneManager.Instance.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = AnatomySceneManager.Instance.GetPart (false, element.DescriptionFileName);
					}
					break;
				default:
					break;
				}
			}

		}

	}

}