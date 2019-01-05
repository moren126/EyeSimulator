using UnityEngine;

namespace EyeSimulator {

	public class PositionTextMeshHelper : MonoBehaviour {

		void Start () {
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
		}

	}

}