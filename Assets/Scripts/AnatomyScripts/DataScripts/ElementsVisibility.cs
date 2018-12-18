using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace EyeSimulator.Anatomy {

	public class ElementsVisibility : MonoBehaviour {

		public static List <GameObject> nonVisibility = new List<GameObject> ();
		public static List <GameObject> nonVisibilityH = new List<GameObject> ();
		public static List <GameObject> nonHighlited = new List<GameObject> ();
		public static List <GameObject> nonHighlitedH = new List<GameObject> ();
		public static List <Toggle> nonVisibleToggles = new List<Toggle> ();

		public static void ClearAllElements() {
			nonVisibility.Clear ();
			nonVisibilityH.Clear ();
			nonHighlited.Clear ();
			nonHighlitedH.Clear ();
			nonVisibleToggles.Clear ();
		}

	}

}