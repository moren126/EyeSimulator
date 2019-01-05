using UnityEngine;
using System.Collections;

namespace EyeSimulator.Menu { 

	public class MenuEyeScript : MonoBehaviour {

		public GameObject eyeball;

		void Update () {
			Quaternion rotateUp = Quaternion.AngleAxis(0.6f, Vector3.up);
			eyeball.transform.rotation = eyeball.transform.rotation * rotateUp;
		}

	}

}