using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
