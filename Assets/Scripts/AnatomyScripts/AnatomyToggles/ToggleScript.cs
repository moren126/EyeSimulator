using UnityEngine;
using UnityEngine.UI;
using EyeSimulator.Anatomy.Data;

namespace EyeSimulator.Anatomy.Toggles {

	public class ToggleScript : MonoBehaviour {

		private GameObject part;
		private GameObject partH;

		private Toggle toggle;


		public GameObject Part {
			set { part = value; }
		}

		public GameObject PartH {
			get { return partH; }
			set { partH = value; }
		}

		void Start() {
			toggle = GetComponent<Toggle> ();
		}

		void Update() {
			CheckToggle ();
		}

		private void CheckToggle () {

			toggle.onValueChanged.AddListener ((bool on) => {

				part.SetActive (on);
				partH.SetActive (on);

				if (on == false) {
					if (!ElementsVisibility.nonVisibility.Contains (part))
						ElementsVisibility.nonVisibility.Add (part);
					if (!ElementsVisibility.nonVisibilityH.Contains (partH) || partH.name == "JustEmpty")
						ElementsVisibility.nonVisibilityH.Add (partH);
					if (!ElementsVisibility.nonVisibleToggles.Contains (toggle))
						ElementsVisibility.nonVisibleToggles.Add (toggle);
				
					CheckToggleGroup ();

				} else if (on == true) {
					ElementsVisibility.nonVisibility.Remove (part);
					ElementsVisibility.nonVisibilityH.Remove (partH);
					ElementsVisibility.nonVisibleToggles.Remove (toggle);
				}

			});

		}

		// if all elements are inactive, set category toggle off 
		private void CheckToggleGroup () {

			int siblings = transform.parent.childCount;
			int enabled = 0;

			// on [0] position sits category, it's irrelevant for this checking
			for (int i = 1; i < siblings; i++) {
				if (transform.parent.GetChild(i).GetComponent<Toggle>().isOn)
					enabled += 1;
			}
			if (enabled <= 0)
				transform.parent.GetChild (0).GetComponent<Toggle>().isOn = false;

		}

	}

}