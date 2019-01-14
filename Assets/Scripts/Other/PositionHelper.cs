using UnityEngine;

namespace EyeSimulator {

	public class PositionHelper : MonoBehaviour {

		public float posX;
		public float posY;

		void Start () {
			GetComponent<RectTransform> ().anchoredPosition = new Vector2 (posX, posY);
		}

	}

}