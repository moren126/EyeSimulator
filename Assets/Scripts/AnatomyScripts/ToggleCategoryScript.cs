using UnityEngine;
using UnityEngine.UI;

namespace EyeSimulator.Anatomy.Toggles {

	public class ToggleCategoryScript : MonoBehaviour {

		private bool uncheck;

		void Start() {
			uncheck = false;
		}
			
		private void SetChildToggles (bool isOn) {

			int childCount = transform.parent.childCount;

			for (int i = 1; i < childCount; i++) {
				transform.parent.GetChild(i).GetComponent<Toggle>().isOn = isOn;
				transform.parent.GetChild (i).gameObject.SetActive (isOn);
			}

		}

		private void SetCategoryHeight(bool rollOut) {

			float sizeY;

			int childCount = transform.parent.childCount - 1;
			float rollHeight = childCount * (transform.parent.GetChild (1).GetComponent<RectTransform> ().sizeDelta.y) + (childCount + 1) * transform.parent.GetComponent<VerticalLayoutGroup> ().spacing;

			if (rollOut) {
				sizeY = transform.parent.GetComponent<RectTransform> ().sizeDelta.y + rollHeight;
			} else {
				sizeY = transform.parent.GetComponent<RectTransform> ().sizeDelta.y - rollHeight;
			}

			transform.parent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (transform.parent.GetComponent<RectTransform> ().sizeDelta.x, sizeY);  

		}

		public void CheckCategoryToggle () {

			if (!uncheck) {
				SetChildToggles(false);
				SetCategoryHeight(false);
			}
			else if (uncheck) {
				SetChildToggles(true);
				SetCategoryHeight(true);
			}

			uncheck = !uncheck;
		}

	}

}