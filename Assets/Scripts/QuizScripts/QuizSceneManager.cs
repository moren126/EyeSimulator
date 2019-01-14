using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using EyeSimulator.Anatomy.Data;

namespace EyeSimulator.Quiz {

	public class QuizSceneManager : MonoBehaviour {

		[SerializeField] private GameObject modelPrefab; 
		[SerializeField] private QuizUIManager quizUIManager;

		private int nr, wholeQuiz, score;
		private int childCount;
		private string version;
		private bool wasFirst;

		private GameObject modelObject;
		private GameObject previousElement;
		private Color previousColor;
		private Color startColor;
		private CameraZoom cameraZoom;

		private Dictionary<string, EyeCategory> questionsDict = new Dictionary<string, EyeCategory>();
		private List<string> questionsKeys = new List<string>();
		private EyeElements eyeElements = new EyeElements ();

		private int questionValue = 10;
		private Color changeColor = new Color (0f, 0f, 255f, 0f);

		private static QuizSceneManager instance;

		public static QuizSceneManager Instance {
			get {
				if (instance == null)
					instance = FindObjectOfType<QuizSceneManager> ();
				return instance;
			}
		}


		void Start () {
			modelObject = InstantaiteModel (modelPrefab);

			childCount = modelObject.transform.childCount;

			SetActiveModelParts (modelObject, childCount, false);

			SetQuizElementsFromXML ();

			nr = 0;
			wholeQuiz = 10;
			score = 0;

			cameraZoom = Camera.main.GetComponent<CameraZoom> ();

			wasFirst = false;
		}

		#region Private Methods
		private GameObject InstantaiteModel(GameObject prefab) {
			GameObject g = (GameObject)Instantiate (prefab, prefab.transform.position, prefab.transform.rotation);
			g.name = "ModelObject";
			g.transform.parent = transform;
			g.SetActive (true);

			return g;
		}

		private void SetActiveModelParts(GameObject model, int childCount, bool active) {
			for (int i = 0; i < childCount; i++) {
				model.transform.GetChild (i).gameObject.SetActive(active);
			}
		}
			
		private void SetQuizElementsFromXML () {
			Type[] eyeElementsTypes = { typeof(Element) };
			XmlSerializer eyeElementsSerializer = new XmlSerializer (typeof(EyeElements), eyeElementsTypes);
			TextReader eyeElementsTextReader = new StreamReader (Application.streamingAssetsPath + "/XML/EyeElements.xml");
			eyeElements = (EyeElements)eyeElementsSerializer.Deserialize (eyeElementsTextReader);
			eyeElementsTextReader.Close ();
		}

		private void ResetPosition(GameObject model) {
			model.transform.position = new Vector3 (0.25f, 0, 0);
			model.transform.eulerAngles = new Vector3 (0, 0, 0);
			cameraZoom.ResetFov ();
		}

		private Dictionary<string, EyeCategory> DrawQuerstion (List<Element> listName, int howMany, string langVersion) {

			Dictionary<string, EyeCategory> listToExpel = new Dictionary<string, EyeCategory> ();
			Dictionary<string, EyeCategory> results = new Dictionary<string, EyeCategory> ();

			for (int x = 0; x < listName.Count; x++) {
				if (langVersion == "Pl")
					listToExpel.Add (listName[x].NamePolish, listName[x].Type);
				else if (langVersion == "Lat")
					listToExpel.Add (listName[x].NameLatin, listName[x].Type);
			}
				
			List <string> listToExpelKeys = new List<string> (listToExpel.Keys);

			if (listToExpel.Count >= howMany) {
				
				for (int i = 0; i < howMany; i++) {

					System.Random rand = new System.Random ();
					string randomKey = listToExpelKeys [rand.Next (listToExpelKeys.Count)];

					results.Add(randomKey, listToExpel[randomKey]);

					listToExpelKeys.Remove (randomKey);
					listToExpel.Remove (randomKey);
				}

			} else
				Debug.Log ("List doesn't have enough elements");

			return results;
		}

		private List<string> DrawAnswers (string partName, EyeCategory eyeCategory, string langVersion) {

			int howMany = 3;

			List<string> listToExpel = new List<string> ();
			List<string> results = new List<string> ();

			List<Element> listName = new List<Element> ();

			switch (eyeCategory) {
			case EyeCategory.EYEBALL:
				listName = eyeElements.EyeballList;
				break;
			case EyeCategory.MUSCLES:
				listName = eyeElements.MusclesList;
				break;
			case EyeCategory.NERVES:
				listName = eyeElements.NervesList;
				break;
			case EyeCategory.EYESOCKET:
				listName = eyeElements.EyeSocketList;
				break;
			default:
				break;
			}

			for (int x = 0; x < listName.Count; x++) {
				if (langVersion == "Pl")
					listToExpel.Add (listName[x].NamePolish);
				else if (langVersion == "Lat")
					listToExpel.Add (listName[x].NameLatin);
			}
				
			listToExpel.Remove (partName);
			for (int i = 0; i < howMany; i++) {

				int rand = UnityEngine.Random.Range(0, listToExpel.Count - 1);
				results.Add (listToExpel [rand]);
				listToExpel.RemoveAt(rand);

			}
				
			return results;
		}
			
		private void MakeQuestion (string question, EyeCategory eyeCategory, string version) {

			string partName = string.Empty;

			List<string> readyQuestion = new List<string> ();
			int rand = UnityEngine.Random.Range(0, 3);

			// reset position of whole eye model
			ResetPosition (modelObject);

			// prepare question
			readyQuestion = DrawAnswers (question, eyeCategory, version);
			readyQuestion.Insert (rand, question);

			if (readyQuestion.Count != 4)
				Debug.Log ("Error in MakeQuestion");
			else {
				quizUIManager.ChangeButtonText ("a", readyQuestion [0]);
				quizUIManager.ChangeButtonText ("b", readyQuestion [1]);
				quizUIManager.ChangeButtonText ("c", readyQuestion [2]);
				quizUIManager.ChangeButtonText ("d", readyQuestion [3]);
			}

			// if was first question of quiz
			if (wasFirst) {

				for (int i = 0; i < childCount; i++) {

					// prepare previous element of model
					if (modelObject.transform.GetChild (i).gameObject == previousElement) {
						Renderer rend = modelObject.transform.GetChild (i).GetComponent<Renderer> ();
						rend.material.color = previousColor;
						break;
					}

				}

				// prepare current element of model
				partName = GetDescriptionFileName(question, eyeCategory, version);
				PrepareElement(partName);

			} else {
				// prepare current element of model
				partName = GetDescriptionFileName(question, eyeCategory, version);
				PrepareElement(partName);

				wasFirst = true;
			}

			// increase question number
			int whichQuestion = nr;
			whichQuestion++;
			quizUIManager.UpdateQuestionNr (whichQuestion);

			// deactivate all elements of model
			for (int i = 0; i < childCount; i++)
				modelObject.transform.GetChild (i).gameObject.SetActive (false);

			// activate needed eye category
			ActivateEyeCategory (eyeCategory);

		}

		private string GetDescriptionFileName(string question, EyeCategory eyeCategory, string version) {

			string partName = string.Empty;

			switch (eyeCategory) {

			case EyeCategory.EYEBALL:
				foreach (var p in eyeElements.EyeballList) {
					if (version == "Pl") {
						
						if (p.NamePolish == question) {
							partName = p.DescriptionFileName;
							break;
						} 

					}
						
					else if (version == "Lat") {
						
						if (p.NameLatin == question) {
							partName = p.DescriptionFileName;
							break;
						}

					}

				}
				break;

			case EyeCategory.MUSCLES:
				foreach (var p in eyeElements.MusclesList) { 
					if (version == "Pl") {

						if (p.NamePolish == question) {
							partName = p.DescriptionFileName;
							break;
						} 

					}

					else if (version == "Lat") {

						if (p.NameLatin == question) {
							partName = p.DescriptionFileName;
							break;
						}

					}

				}
				break;

			case EyeCategory.NERVES:
				foreach (var p in eyeElements.NervesList) {
					if (version == "Pl") {

						if (p.NamePolish == question) {
							partName = p.DescriptionFileName;
							break;
						} 

					}

					else if (version == "Lat") {

						if (p.NameLatin == question) {
							partName = p.DescriptionFileName;
							break;
						}

					}

				}
				break;

			case EyeCategory.EYESOCKET:
				foreach (var p in eyeElements.EyeSocketList) {
					if (version == "Pl") {

						if (p.NamePolish == question) {
							partName = p.DescriptionFileName;
							break;
						} 

					}

					else if (version == "Lat") {

						if (p.NameLatin == question) {
							partName = p.DescriptionFileName;
							break;
						}

					}

				}
				break;

			default:
				break;

			}

			return partName; 
		}


		private void PrepareElement(string partName) {
			GameObject q = GetPartScript.GetPart (modelObject, partName);

			Renderer rend = q.GetComponent<Renderer> ();
			startColor = rend.material.color;
			rend.material.color = changeColor;
			previousElement = q;
			previousColor = startColor;
		}

		private void ActivateEyeCategory(EyeCategory eyeCategory) {
			switch (eyeCategory) {

			case EyeCategory.EYEBALL:
				foreach (var p in eyeElements.EyeballList) 
					GetPartScript.GetPart (modelObject, p.DescriptionFileName).SetActive(true);
				break;

			case EyeCategory.MUSCLES:
				foreach (var p in eyeElements.MusclesList)  
					GetPartScript.GetPart (modelObject, p.DescriptionFileName).SetActive(true);
				break;

			case EyeCategory.NERVES:
				foreach (var p in eyeElements.NervesList)
					GetPartScript.GetPart (modelObject, p.DescriptionFileName).SetActive(true);
				break;

			case EyeCategory.EYESOCKET:
				foreach (var p in eyeElements.EyeSocketList)
					GetPartScript.GetPart (modelObject, p.DescriptionFileName).SetActive(true);
				break;

			default:
				break;

			}
		}
			
		private void EndScreen() {
			
			int res = score / 10;

			quizUIManager.UpdateResultText (res);
			quizUIManager.EndQuiz ();

			wasFirst = false;

			for (int i = 0; i < childCount; i++) {
				if (modelObject.transform.GetChild (i).gameObject == previousElement) {
					Renderer rend = modelObject.transform.GetChild (i).GetComponent<Renderer> ();
					rend.material.color = previousColor;
					break;
				}
			}

			for (int i = 0; i < childCount; i++)
				modelObject.transform.GetChild (i).gameObject.SetActive (false);

		}
			
		private Dictionary <string, EyeCategory> Questions (string version) {
			int eyeballNr = UnityEngine.Random.Range(3, 4);
			int muscleNr = UnityEngine.Random.Range (2, 3);
			int nervesNr = UnityEngine.Random.Range (1, 2);
			int eyeSocketNr = 10 - eyeballNr - muscleNr - nervesNr; 

			Dictionary <string, EyeCategory> q = new Dictionary<string, EyeCategory>();
			Dictionary <string, EyeCategory> questions = new Dictionary<string, EyeCategory>();
			Dictionary <string, EyeCategory> sortedQuestions = new Dictionary<string, EyeCategory>();

			q = DrawQuerstion (eyeElements.EyeballList, eyeballNr, version);
			q.ToList ().ForEach (x => questions.Add(x.Key, x.Value)); 

			q = DrawQuerstion (eyeElements.MusclesList, muscleNr, version);
			q.ToList ().ForEach (x => questions.Add(x.Key, x.Value));

			q = DrawQuerstion (eyeElements.NervesList, nervesNr, version);
			q.ToList ().ForEach (x => questions.Add(x.Key, x.Value));

			q = DrawQuerstion (eyeElements.EyeSocketList, eyeSocketNr, version);
			q.ToList ().ForEach (x => questions.Add(x.Key, x.Value));

			sortedQuestions = MixOrderRepeat (questions, 4);

			return sortedQuestions;
		}

		private Dictionary <string, EyeCategory> MixOrderRepeat(Dictionary <string, EyeCategory> dictToMix, int repeat) {
			Dictionary <string, EyeCategory> resultDict = new Dictionary<string, EyeCategory> ();
			resultDict = MixOrder (dictToMix);

			for (int i = 0; i < repeat; i++)
				resultDict = MixOrder (resultDict);

			return resultDict;
		}

		private Dictionary <string, EyeCategory> MixOrder(Dictionary <string, EyeCategory> dictToMix) {
			List <string> tempKeyList = new List<string> (dictToMix.Keys);
			Dictionary <string, EyeCategory> resultDict = new Dictionary<string, EyeCategory>();

			while (tempKeyList.Count != 0) {
				int rand = UnityEngine.Random.Range (0, tempKeyList.Count);
				string randomKey = tempKeyList[rand];

				resultDict.Add(randomKey, dictToMix [randomKey]);
				tempKeyList.Remove (randomKey);
			}

			return resultDict;
		}
		#endregion

		#region Public Methods
		public void CheckAnswer(string buttonName) {

			string rightAnswer = questionsKeys[nr];

			if (quizUIManager.IncreaseScore (buttonName, rightAnswer)) {
				score = score + questionValue;
				quizUIManager.UpdateScore (score);
			}

			nr++;

			if (nr < wholeQuiz && questionsDict.Count != 0)
				MakeQuestion (questionsKeys[nr], questionsDict[questionsKeys[nr]], version);
			else
				EndScreen ();
		}

		public void ChooseLang (Button lang) {
			questionsDict = Questions (lang.name);
			questionsKeys = new List<string> (questionsDict.Keys);

			MakeQuestion(questionsKeys[nr], questionsDict[questionsKeys[nr]], lang.name);
			version = lang.name;
		}

		public void RepeatQuiz () {
			nr = 0;
			score = 0;

			MakeQuestion(questionsKeys[nr], questionsDict[questionsKeys[nr]], version);
		}

		public void NewQuiz () {
			nr = 0;
			score = 0;
			questionsDict.Clear ();
			version = "";
		}
		#endregion
			
	}

}