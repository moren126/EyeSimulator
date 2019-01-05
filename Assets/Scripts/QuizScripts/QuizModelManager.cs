using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EyeSimulator.Quiz {

	public class QuizModelManager : MonoBehaviour {

		private GameObject corpusVitreum;

		void Start () {
			
			int childCount = transform.childCount;

			for (int i = 0; i < childCount; i++) {
				if (transform.GetChild (i).name == "bCorpusVitreum") {
					corpusVitreum = transform.GetChild (i).gameObject;
					break;
				}
			}
				
		}

		void Update () {
			
			if (!corpusVitreum.activeSelf) {
				transform.Rotate (0, Input.GetAxis ("Horizontal") * (-30) * Time.deltaTime, 0);
				transform.Rotate (Input.GetAxis ("Vertical") * 30 * Time.deltaTime, 0, 0);
			} else {
				transform.RotateAround (new Vector3 (0.3f, 0, -0.75f), new Vector3 (0, 1, 0), Input.GetAxis ("Horizontal") * (-1)); 
				transform.RotateAround (new Vector3 (0.3f, 0, -0.75f), new Vector3 (1, 0, 0), Input.GetAxis ("Vertical") * 1); 
			}

		}

	}

}