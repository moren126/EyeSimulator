using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EyeSimulator.Quiz {

	public class QuizUIManager : MonoBehaviour {

		public GameObject mainWindowHolder;
		public GameObject answearsHolder;
		public GameObject endWindowHolder;

		public GameObject pickTextObject;

		public Button plButton;
		public Button latButton;

		public Button answerA;
		public Button answerB;
		public Button answerC;
		public Button answerD;

		public Button repeatButton;
		public Button newQuizButton;

		public TextMeshProUGUI questionNr;
		public TextMeshProUGUI scoreText;

		public TextMeshProUGUI headlineText;

		private string pickText = "Wybierz język:";


		void Start () {
			plButton.onClick.AddListener (() => ChooseLang(plButton));
			latButton.onClick.AddListener (() => ChooseLang(latButton));

			answerA.onClick.AddListener (() => QuizSceneManager.Instance.CheckAnswer ("a"));
			answerB.onClick.AddListener (() => QuizSceneManager.Instance.CheckAnswer ("b"));
			answerC.onClick.AddListener (() => QuizSceneManager.Instance.CheckAnswer ("c"));
			answerD.onClick.AddListener (() => QuizSceneManager.Instance.CheckAnswer ("d"));	

			repeatButton.onClick.AddListener (() => RepeatQuiz ());
			newQuizButton.onClick.AddListener (() => NewQuiz ());
		}
			
		#region Private Methods
		private void ChooseLang (Button lang) {
			mainWindowHolder.SetActive (false);
			answearsHolder.SetActive (true);

			headlineText.gameObject.SetActive(false);

			QuizSceneManager.Instance.ChooseLang(lang);
		}

		private void RepeatQuiz () {
			endWindowHolder.SetActive (false);
			answearsHolder.SetActive (true);

			headlineText.gameObject.SetActive(false);

			QuizSceneManager.Instance.RepeatQuiz ();
		}

		private void NewQuiz () {
			QuizSceneManager.Instance.NewQuiz ();

			headlineText.text = pickText;

			endWindowHolder.SetActive (false);
			mainWindowHolder.SetActive (true);
		}
		#endregion
			
		#region Public Methods
		public bool IncreaseScore (string buttonName, string buttonText) {

			if (buttonName == "a") {
				if (answerA.GetComponentInChildren<TextMeshProUGUI> ().text == buttonText)
					return true;
				else
					return false;
			} else if (buttonName == "b") {
				if (answerB.GetComponentInChildren<TextMeshProUGUI> ().text == buttonText)
					return true;
				else
					return false;
			} else if (buttonName == "c") {
				if (answerC.GetComponentInChildren<TextMeshProUGUI> ().text == buttonText)
					return true;
				else
					return false;
			} else if (buttonName == "d") {
				if (answerD.GetComponentInChildren<TextMeshProUGUI> ().text == buttonText)
					return true;
				else
					return false;
			} else
				return false;

		}

		public bool ChangeButtonText(string buttonName, string text) {

			if (buttonName == "a") {
				answerA.GetComponentInChildren<TextMeshProUGUI> ().text = text;
				return true;
			} else if (buttonName == "b") {
				answerB.GetComponentInChildren<TextMeshProUGUI> ().text = text;
				return true;
			} else if (buttonName == "c") {
				answerC.GetComponentInChildren<TextMeshProUGUI> ().text = text;
				return true;
			} else if (buttonName == "d") {
				answerD.GetComponentInChildren<TextMeshProUGUI> ().text = text;
				return true;
			} else
				return false;
			
		}

		public void UpdateScore(int score) {
			scoreText.text = "Wynik: " + score.ToString() + " / 100";
		}

		public void UpdateQuestionNr(int whichQuestion) {
			questionNr.text = whichQuestion.ToString () + " / 10";
		}

		public void UpdateResultText(int res) {

			string answerEnd = "";
			if (res == 1)
				answerEnd = " dobra odpowiedź";
			else if ((res == 2 || res == 3) || res == 4)
				answerEnd = " dobre odpowiedzi";
			else
				answerEnd = " dobrych odpowiedzi";

			headlineText.gameObject.SetActive(true);
			headlineText.text = res.ToString () + answerEnd;
		}

		public void EndQuiz() {
			answearsHolder.SetActive (false);
			endWindowHolder.SetActive (true);
		}
		#endregion

	}

}