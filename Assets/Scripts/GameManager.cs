using UnityEngine;
using UnityEngine.SceneManagement;

namespace EyeSimulator {

	public class GameManager : MonoBehaviour {

		public void LoadScene(string name) {
			SceneManager.LoadScene (name);
		}

		public void QuitGame() {
			Application.Quit ();
		}
	}

}
