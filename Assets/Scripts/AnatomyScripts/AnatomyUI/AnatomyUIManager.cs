using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EyeSimulator.Anatomy.Toggles;

namespace EyeSimulator.Anatomy.UI {

	public class AnatomyUIManager : TogglesMenuUIManager {

		private AnatomySceneManager anatomySceneManager;

		protected override void Start () {
			anatomySceneManager = AnatomySceneManager.Instance;

			base.Start ();
		}

		protected override void PrepareMenuCategories() {
			
			int categoryTypes = anatomySceneManager.EyeCategories.EyeCategoriesList.Count;

			for (int i = 0; i < categoryTypes; i++) {

				GameObject category = (GameObject)Instantiate (categoryWholePrefab, transform.position, Quaternion.identity);
				category.SetActive (true);
				category.name = anatomySceneManager.EyeCategories.EyeCategoriesList[i].Type.ToString();
				category.transform.SetParent (menuContent.transform, true);
				category.transform.localScale = Vector3.one;

				category.transform.Find ("ToggleCategory").GetComponentInChildren<TextMeshProUGUI> ().text = anatomySceneManager.EyeCategories.EyeCategoriesList [i].NamePolish;

				categoryList.Add (category);

				EyeCategory statement = anatomySceneManager.EyeCategories.EyeCategoriesList [i].Type;

				int elements = 0;
				float height = 0;

				float spacing = category.GetComponent<VerticalLayoutGroup> ().spacing;

				switch (statement) {
				case EyeCategory.EYESOCKET:
					elements = anatomySceneManager.EyeElements.EyeSocketList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.MUSCLES:
					elements = anatomySceneManager.EyeElements.MusclesList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.NERVES:
					elements = anatomySceneManager.EyeElements.NervesList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.EYEBALL:
					elements = anatomySceneManager.EyeElements.EyeballList.Count;
					height = elements * (toggleElementPrefab.GetComponent<RectTransform> ().sizeDelta.y + spacing) + category.GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;
					category.GetComponent<RectTransform> ().sizeDelta = new Vector2(category.GetComponent<RectTransform> ().sizeDelta.x, height);
					break;
				case EyeCategory.OTHER:
					elements = anatomySceneManager.EyeElements.OtherList.Count;
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

				case "EYESOCKET":
					categoryTransform = categoryList [i].transform;

					foreach (var element in anatomySceneManager.EyeElements.EyeSocketList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript>().Part = anatomySceneManager.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript>().PartH = anatomySceneManager.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "MUSCLES":
					categoryTransform = categoryList [i].transform;

					foreach (var element in anatomySceneManager.EyeElements.MusclesList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = anatomySceneManager.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = anatomySceneManager.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "NERVES":
					categoryTransform = categoryList [i].transform;

					foreach (var element in anatomySceneManager.EyeElements.NervesList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = anatomySceneManager.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = anatomySceneManager.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "EYEBALL":
					categoryTransform = categoryList [i].transform;

					foreach (var element in anatomySceneManager.EyeElements.EyeballList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = anatomySceneManager.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = anatomySceneManager.GetPart (false, element.DescriptionFileName);
					}
					break;
				case "OTHER":
					categoryTransform = categoryList [i].transform;

					foreach (var element in anatomySceneManager.EyeElements.OtherList) {
						GameObject t = InstantiateToggleElement (element.DescriptionFileName, element.NamePolish, categoryTransform);

						t.GetComponent<ToggleScript> ().Part = anatomySceneManager.GetPart (true, element.DescriptionFileName);
						t.GetComponent<ToggleScript> ().PartH = anatomySceneManager.GetPart (false, element.DescriptionFileName);
					}
					break;
				default:
					break;
				}
			}

		}

	}

}