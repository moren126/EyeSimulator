using UnityEngine;
using System.Collections;

namespace EyeSimulator.Anatomy {

	public class Modes : MonoBehaviour {

		private int state; 
		private int previousState;
		private bool wasStateChange;
		private bool wasStateChangeForToggles;
		private bool pinsMode;

		public int State {
			get { return state; }
		}

		public bool PinsMode {
			get { return pinsMode; }
			set { pinsMode = value; }
		}

		public bool WasStateChangeForToggles {
			get { return wasStateChangeForToggles; }
			set { wasStateChangeForToggles = value; }
		}
			
		void Start () {
			state = 0; // 0-whole model, 1-half model
			AnatomySceneManager.Instance.ShowWholeModel ();

			previousState = 0;
			wasStateChange = wasStateChangeForToggles = false;

			pinsMode = true;
		}

		void Update () {
			
			if (previousState != state) {
				wasStateChange = true;
				wasStateChangeForToggles = wasStateChange;
				previousState = state;
			}
				
			if (wasStateChange && state == 0) {
				AnatomySceneManager.Instance.ShowWholeModel ();
				wasStateChange = false;
			} else if (wasStateChange && state == 1) {
				AnatomySceneManager.Instance.ShowHalfModel ();
				wasStateChange = false;
			}
		}

		public void ChangeState(int desiredState) {
			previousState = state;
			state = desiredState;
		}

	}

}