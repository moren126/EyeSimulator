using UnityEngine;
using System.Collections;

namespace EyeSimulator {

	public class HighlightObject : MonoBehaviour {
		
		private Color startColor;
		private Color changeColor;
		private Renderer rend;

		public Color GetColor () {
			return startColor;
		}

		void Start () {
			rend = GetComponent<Renderer> ();
			startColor = GetComponent<Renderer> ().material.color;
			changeColor = new Color (0f, 0f, 255f, 0f);
		}

		void OnMouseEnter() {
			rend.material.color = changeColor;
		}

		void OnMouseExit() {
			rend.material.color = startColor;
		}
			
	}

}