using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EyeSimulator {

	public class TogglesMenuUIManager : MonoBehaviour {

		[SerializeField] protected GameObject menuContent;

		[SerializeField] protected GameObject categoryWholePrefab;
		[SerializeField] protected GameObject toggleElementPrefab;

		protected float spacingCategory;

		protected List<GameObject> categoryList = new List<GameObject> ();
		private List<Toggle> togglesList = new List<Toggle> ();

		public List<Toggle> TogglesList {
			get { return togglesList; }
		}

		protected virtual void Start () {
			spacingCategory = menuContent.GetComponent<VerticalLayoutGroup> ().spacing;

			PrepareMenu ();
		}

		private void PrepareMenu() {
			PrepareMenuCategories ();

			SetMenuContentHeight ();

			PrepareElements ();
		}

		protected virtual void PrepareMenuCategories() {
	
		}

		protected virtual void PrepareElements() {

		}

		private void SetMenuContentHeight () {

			float menuContentHeight = 0;

			int children = menuContent.transform.childCount;

			for (int i = 0; i < children; i++)
				menuContentHeight += menuContent.transform.GetChild (i).GetComponent<RectTransform> ().sizeDelta.y + spacingCategory;

			menuContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menuContent.GetComponent<RectTransform> ().sizeDelta.x, menuContentHeight);
		}

		protected GameObject InstantiateToggleElement(string nameHierachy, string nameToShow, Transform parentTransform) {
			GameObject toggle = (GameObject)Instantiate (toggleElementPrefab, transform.position, Quaternion.identity);
			toggle.SetActive (true);
			toggle.name = nameHierachy;
			toggle.transform.SetParent (parentTransform, true);
			toggle.transform.localScale = Vector3.one;

			toggle.GetComponentInChildren<TextMeshProUGUI> ().text = nameToShow;

			togglesList.Add (toggle.GetComponent<Toggle>());

			return toggle;
		}
				
	}

}