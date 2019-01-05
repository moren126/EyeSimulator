using UnityEngine;

namespace EyeSimulator {

	public class GetPartScript {

		private static GameObject emptyGameObject;

		public static GameObject GetPart(GameObject model, string name) {

			int childCount = model.transform.childCount;

			for (int i = 0; i < childCount; i++) {
				if (model.transform.GetChild (i).name == name) {
					return model.transform.GetChild (i).gameObject;
				}
			}

			// in case that name doesn't exists
			if (emptyGameObject == null) {
				emptyGameObject = new GameObject ();
				emptyGameObject.name = "EmptyGameObject";
				emptyGameObject.transform.SetParent(model.transform);
			}
			
			return emptyGameObject;
		}

	}

}