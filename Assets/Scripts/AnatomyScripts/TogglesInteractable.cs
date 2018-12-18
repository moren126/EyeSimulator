using UnityEngine;
using UnityEngine.UI;

namespace EyeSimulator.Anatomy.Toggles {

	public class TogglesInteractable : MonoBehaviour {

		private Modes modes;

		void Start () {
			modes = FindObjectOfType<Modes> ();
		}

		void Update () {

			if (modes.WasStateChangeForToggles) {

				int children = transform.childCount;

				for (int i = 0; i < children; i++) {
					if (transform.GetChild (i).GetComponent<ToggleScript> () != null) {
						if (transform.GetChild (i).GetComponent<ToggleScript> ().PartH.name == "JustEmpty") {

							if (modes.State == 0)
								transform.GetChild (i).GetComponent<Toggle> ().interactable = true;
							else if (modes.State == 1)
								transform.GetChild (i).GetComponent<Toggle> ().interactable = false;

						}
					}
				}

			}

		}

	}

}