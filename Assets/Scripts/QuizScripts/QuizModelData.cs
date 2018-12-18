using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EyeSimulator;

public class QuizModelData : MonoBehaviour {

	public Text _chooseLang;
	public Button _pl;
	public Button _lat;
	public Button _answerA;
	public Button _answerB;
	public Button _answerC;
	public Button _answerD;
	public Text _pick;
	public Text _questionNr;
	public Text _scoreText;
	public Text _resultText;
	public Button _repeat;
	public Button _newQuiz;

	public Text _infoText;

	public List<QuestionData> _quizList = new List<QuestionData> ();

	public string[] _quizBulbusStringArrayLAT;
	public string[] _quizMusculiStringArrayLAT; 
	public string[] _quizNerviStringArrayLAT; 
	public string[] _quizOsStringArrayLAT; 
	public string[] _quizBulbusStringArrayPL;
	public string[] _quizMusculiStringArrayPL; 
	public string[] _quizNerviStringArrayPL; 
	public string[] _quizOsStringArrayPL;

	private QuestionData _corpusVitreumObj, _retinaObj, _lensObj, _choroideaObj, _corpusCiliareObj, _irisObj, _scleraObj, _corneaObj;
	private QuestionData _mObliquusInferiorObj, _mObliquusSuperiorObj, _mRectusInferiorObj, _mRectusLateralisObj, _mRectusMedialisObj, _mRectusSuperiorObj;
	private QuestionData _nAbducensObj, _nOculomotoriusObj, _nOpticusObj, _nTrochlearisObj; 
	private QuestionData _osEthmoidaleObj, _osFrontaleObj, _osLacrimaleObj, _osMaxillaObj, _osPalatinumObj, _osSphenoidaleObj, _osZygomaticumObj; 

	private List<string> _questionsList = new List<string>();
	private int _nr, _wholeQuiz, _score;
	private string _version;
	private GameObject _previousElement;
	private Color _previousColor;
	private bool _first, _infoState;
	private AssignModels _assignModelsInstance;
	private GameManager _gm;


	void ResetPosition(AssignModels model) {
		model._whole.transform.position = new Vector3 (0.25f, 0, 0);
		model._whole.transform.eulerAngles = new Vector3 (0, 0, 0);
	}

	int GetQuestionNr () {
		return _nr;
	}

	void SetQuestionNr () {
		_nr++;
	}
		
	void MakeQuizElements (AssignModels model) {

		string [] temp = new string[] {"retina", "lens", "choroidea", "corpus ciliare", "iris", "sclera", "cornea"};
		string [] temp2 = new string[] {"siatkówka", "soczewka", "naczyniówka", "ciało rzęskowe", "tęczówka", "twardówka", "rogówka"};
		_corpusVitreumObj = new QuestionData ("corpus vitreum", "ciało szkliste", model._corpusVitreumH, temp, temp2, "bulbus"); 

		temp = new string[] {"corpus vitreum", "lens", "choroidea", "corpus ciliare", "iris", "sclera", "cornea"};
		temp2 = new string[] {"ciało szkliste", "soczewka", "naczyniówka", "ciało rzęskowe", "tęczówka", "twardówka", "rogówka"};
		_retinaObj = new QuestionData ("retina", "siatkówka", model._retinaH, temp, temp2, "bulbus");

		temp = new string[] {"corpus vitreum", "retina", "choroidea", "corpus ciliare", "iris", "sclera", "cornea"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "naczyniówka", "ciało rzęskowe", "tęczówka", "twardówka", "rogówka"};
		_lensObj = new QuestionData ("lens", "soczewka", model._lensH, temp, temp2, "bulbus");

		temp = new string[] {"corpus vitreum", "retina", "lens", "corpus ciliare", "iris", "sclera", "cornea"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "soczewka", "ciało rzęskowe", "tęczówka", "twardówka", "rogówka"};
		_choroideaObj = new QuestionData ("choroidea", "naczyniówka", model._choroideaH, temp, temp2, "bulbus");


		temp = new string[] {"corpus vitreum", "retina", "lens", "choroidea", "iris", "sclera", "cornea"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "soczewka", "naczyniówka", "tęczówka", "twardówka", "rogówka"};
		_corpusCiliareObj = new QuestionData ("corpus ciliare", "ciało rzęskowe", model._corpusCiliareH, temp, temp2, "bulbus");

		temp = new string[] {"corpus vitreum", "retina", "lens", "choroidea", "corpus ciliare", "sclera", "cornea"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "soczewka", "naczyniówka", "ciało rzęskowe", "twardówka", "rogówka"};
		_irisObj = new QuestionData ("iris", "tęczówka", model._irisH, temp, temp2, "bulbus");

		temp = new string[] {"corpus vitreum", "retina", "lens", "choroidea", "corpus ciliare", "iris", "cornea"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "soczewka", "naczyniówka", "ciało rzęskowe", "tęczówka", "rogówka"};
		_scleraObj = new QuestionData ("sclera", "twardówka", model._scleraH, temp, temp2, "bulbus");

		temp = new string[] {"corpus vitreum", "retina", "lens", "choroidea", "corpus ciliare", "iris", "sclera"};
		temp2 = new string[] {"ciało szkliste", "siatkówka", "soczewka", "naczyniówka", "ciało rzęskowe", "tęczówka", "twardówka"};
		_corneaObj = new QuestionData ("cornea", "rogówka", model._corneaH, temp, temp2, "bulbus");

		temp = new string[] {"musculus obliquus superior", "musculus rectus inferior", "musculus rectus lateralis", "musculus rectus medialis", "musculus rectus superior"};
		temp2 = new string[] {"mięsień skośny górny", "mięsień prosty dolny", "mięsień prosty boczny", "mięsień prosty przyśrodkowy", "mięsień prosty górny"};
		_mObliquusInferiorObj = new QuestionData ("musculus obliquus inferior", "mięsień skośny dolny", model._mObliquusInferior, temp, temp2, "musculi");

		temp = new string[] {"musculus obliquus inferior", "musculus rectus inferior", "musculus rectus lateralis", "musculus rectus medialis", "musculus rectus superior"};
		temp2 = new string[] {"mięsień skośny dolny", "mięsień prosty dolny", "mięsień prosty boczny", "mięsień prosty przyśrodkowy", "mięsień prosty górny"};
		_mObliquusSuperiorObj = new QuestionData ("musculus obliquus superior", "mięsień skośny górny", model._mObliquusSuperior, temp, temp2, "musculi");
	
		temp = new string[] {"musculus obliquus inferior", "musculus obliquus superior", "musculus rectus lateralis", "musculus rectus medialis", "musculus rectus superior"};
		temp2 = new string[] {"mięsień skośny dolny", "mięsień skośny górny", "mięsień prosty boczny", "mięsień prosty przyśrodkowy", "mięsień prosty górny"};
		_mRectusInferiorObj = new QuestionData ("musculus rectus inferior", "mięsień prosty dolny", model._mRectusInferior, temp, temp2, "musculi");

		temp = new string[] {"musculus obliquus inferior", "musculus obliquus superior", "musculus rectus inferior", "musculus rectus medialis", "musculus rectus superior"};
		temp2 = new string[] {"mięsień skośny dolny", "mięsień skośny górny", "mięsień prosty dolny", "mięsień prosty przyśrodkowy", "mięsień prosty górny"};
		_mRectusLateralisObj = new QuestionData ("musculus rectus lateralis", "mięsień prosty boczny", model._mRectusLateralis, temp, temp2, "musculi");

		temp = new string[] {"musculus obliquus inferior", "musculus obliquus superior", "musculus rectus inferior", "musculus rectus lateralis", "musculus rectus superior"};
		temp2 = new string[] {"mięsień skośny dolny", "mięsień skośny górny", "mięsień prosty dolny", "mięsień prosty boczny", "mięsień prosty górny"};
		_mRectusMedialisObj = new QuestionData ("musculus rectus medialis", "mięsień prosty przyśrodkowy", model._mRectusMedialis, temp, temp2, "musculi");

		temp = new string[] {"musculus obliquus inferior", "musculus obliquus superior", "musculus rectus inferior", "musculus rectus lateralis", "musculus rectus medialis"};
		temp2 = new string[] {"mięsień skośny dolny", "mięsień skośny górny", "mięsień prosty dolny", "mięsień prosty boczny", "mięsień prosty przyśrodkowy"};
		_mRectusSuperiorObj = new QuestionData ("musculus rectus superior", "mięsień prosty górny", model._mRectusSuperior, temp, temp2, "musculi");

		temp = new string[] {"nervi oculomotorius", "nervi opticus", "nervi trochlearis"};
		temp2 = new string[] {"nerw okoruchowy", "nerw wzrokowy", "nerw bloczkowy"};
		_nAbducensObj = new QuestionData ("nervi abducens", "nerw odwodzący", model._nAbducens, temp, temp2, "nervi");

		temp = new string[] {"nervi abducens", "nervi opticus", "nervi trochlearis"};
		temp2 = new string[] {"nerw odwodzący", "nerw wzrokowy", "nerw bloczkowy"};
		_nOculomotoriusObj = new QuestionData ("nervi oculomotorius", "nerw okoruchowy", model._nOculomotorius, temp, temp2, "nervi");

		temp = new string[] {"nervi abducens", "nervi oculomotorius", "nervi trochlearis"};
		temp2 = new string[] {"nerw odwodzący", "nerw okoruchowy", "nerw bloczkowy"};
		_nOpticusObj = new QuestionData ("nervi opticus", "nerw wzrokowy", model._nOpticus, temp, temp2, "nervi");

		temp = new string[] {"nervi abducens", "nervi oculomotorius", "nervi opticus"};
		temp2 = new string[] {"nerw odwodzący", "nerw okoruchowy", "nerw wzrokowy"};
		_nTrochlearisObj = new QuestionData ("nervi trochlearis", "nerw bloczkowy", model._nTrochlearis, temp, temp2, "nervi");

		temp = new string[] {"os frontale", "os lacrimale", "maxilla", "os palatinum", "os sphenoidale", "os zygomaticum"};
		temp2 = new string[] {"kość czołowa", "kość łzowa", "szczęka", "kość podniebienna", "kość klinowa", "kość jarzmowa"};
		_osEthmoidaleObj = new QuestionData ("os ethmoidale", "kość sitowa", model._osEthmoidale, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os lacrimale", "maxilla", "os palatinum", "os sphenoidale", "os zygomaticum"};
		temp2 = new string[] {"kość sitowa", "kość łzowa", "szczęka", "kość podniebienna", "kość klinowa", "kość jarzmowa"};
		_osFrontaleObj = new QuestionData ("os frontale", "kość czołowa", model._osFrontale, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os frontale", "maxilla", "os palatinum", "os sphenoidale", "os zygomaticum"};
		temp2 = new string[] {"kość sitowa", "kość czołowa", "szczęka", "kość podniebienna", "kość klinowa", "kość jarzmowa"};
		_osLacrimaleObj = new QuestionData ("os lacrimale", "kość łzowa", model._osLacrimale, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os frontale", "os lacrimale", "os palatinum", "os sphenoidale", "os zygomaticum"};
		temp2 = new string[] {"kość sitowa", "kość czołowa", "kość łzowa", "kość podniebienna", "kość klinowa", "kość jarzmowa"};
		_osMaxillaObj = new QuestionData ("maxilla", "szczęka", model._osMaxilla, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os frontale", "os lacrimale", "maxilla", "os sphenoidale", "os zygomaticum"};
		temp2 = new string[] {"kość sitowa", "kość czołowa", "kość łzowa", "szczęka", "kość klinowa", "kość jarzmowa"};
		_osPalatinumObj = new QuestionData ("os palatinum", "kość podniebienna", model._osPalatinum, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os frontale", "os lacrimale", "maxilla", "os palatinum", "os zygomaticum"};
		temp2 = new string[] {"kość sitowa", "kość czołowa", "kość łzowa", "szczęka", "kość podniebienna", "kość jarzmowa"};
		_osSphenoidaleObj = new QuestionData ("os sphenoidale", "kość klinowa", model._osSphenoidale, temp, temp2, "os");

		temp = new string[] {"os ethmoidale", "os frontale", "os lacrimale", "maxilla", "os palatinum", "os sphenoidale"};
		temp2 = new string[] {"kość sitowa", "kość czołowa", "kość łzowa", "szczęka", "kość podniebienna", "kość klinowa"};
		_osZygomaticumObj = new QuestionData ("os zygomaticum", "kość jarzmowa", model._osZygomaticum, temp, temp2, "os");
	}

	void SetQuizElements () {
		_quizList.Add (_corpusVitreumObj);
		_quizList.Add (_retinaObj);
		_quizList.Add (_lensObj);
		_quizList.Add (_choroideaObj);
		_quizList.Add (_corpusCiliareObj);
		_quizList.Add (_irisObj);
		_quizList.Add (_scleraObj);
		_quizList.Add (_corneaObj);

		_quizList.Add (_mObliquusInferiorObj);
		_quizList.Add (_mObliquusSuperiorObj);
		_quizList.Add (_mRectusInferiorObj); 
		_quizList.Add (_mRectusLateralisObj);
		_quizList.Add (_mRectusMedialisObj);
		_quizList.Add (_mRectusSuperiorObj);

		_quizList.Add (_nAbducensObj);
		_quizList.Add (_nOculomotoriusObj); 
		_quizList.Add (_nOpticusObj); 
		_quizList.Add (_nTrochlearisObj);

		_quizList.Add (_osEthmoidaleObj); 
		_quizList.Add (_osFrontaleObj); 
		_quizList.Add (_osLacrimaleObj); 
		_quizList.Add (_osMaxillaObj); 
		_quizList.Add (_osPalatinumObj);
		_quizList.Add (_osSphenoidaleObj); 
		_quizList.Add (_osZygomaticumObj); 

		_quizBulbusStringArrayLAT = new string[]{"corpus vitreum", "retina", "lens", "choroidea", "corpusCiliare", "iris", "sclera", "cornea"};
		_quizMusculiStringArrayLAT = new string[]{"musculus obliquus inferior", "musculus obliquus superior", "musculus rectus inferior", "musculus rectus lateralis", "musculus rectus medialis", "musculus rectus superior"};
		_quizNerviStringArrayLAT = new string[] {"nervi abducens", "nervi oculomotorius", "nervi opticus", "nervi trochlearis"};
		_quizOsStringArrayLAT = new string[] {"os ethmoidale", "os frontale", "os lacrimale", "maxilla", "os palatinum", "os sphenoidale", "os zygomaticum"};
		_quizBulbusStringArrayPL = new string[] {"ciało szkliste", "siatkówka", "soczewka", "naczyniówka", "ciało rzęskowe", "tęczówka", "twardówka", "rogówka"};
		_quizMusculiStringArrayPL = new string[] {"mięsień skośny dolny", "mięsień skośny górny", "mięsień prosty dolny", "mięsień prosty boczny", "mięsień prosty przyśrodkowy", "mięsień prosty górny"};
		_quizNerviStringArrayPL = new string[] {"nerw odwodzący", "nerw okoruchowy", "nerw wzrokowy", "nerw bloczkowy"};
		_quizOsStringArrayPL = new string[] {"kość sitowa", "kość czołowa", "kość łzowa", "szczęka", "kość podniebienna", "kość klinowa", "kość jarzmowa"};
	}

	List<string> DrawQuerstion (string[] questionsMaterial, int howMany) {
		int rand;
		List<string> listToExpel = new List<string> ();
		List<string> results = new List<string> ();

		for (int x = 0; x < questionsMaterial.Length; x++)
			listToExpel.Add (questionsMaterial[x]);

		if (questionsMaterial.Length >= howMany) {
			for (int i = 0; i < howMany; i++) {
				rand = Random.Range (0, listToExpel.Count - 1);
				results.Add(listToExpel [rand]);
				listToExpel.RemoveAt (rand);
			}

		} else
			Debug.Log ("Za mało elementów w tablicy");

		return results;
	}

	List<string> DrawAnswers (string question, string version) {
		int rand; 
		int answersNr = 0;
		int howMany = 3;
		List<string> listToExpel = new List<string> ();
		List<string> results = new List<string> ();

		if (version == "Pl") {
			foreach (QuestionData q in _quizList) {
				if (q.textPl == question) {
					answersNr = q.otherAnswersPl.Length;
					for (int x = 0; x < answersNr; x++)
						listToExpel.Add (q.otherAnswersPl [x]);
					break;
				} 
			}
		} else if (version == "Lat") {
			foreach (QuestionData q in _quizList) {
				if (q.textLat == question) {
					answersNr = q.otherAnswersLat.Length;
					for (int x = 0; x < answersNr; x++)
						listToExpel.Add (q.otherAnswersLat [x]);
					break;
				}
			}
		}


		if (answersNr >= howMany) {
			for (int i = 0; i < howMany; i++) {
				rand = Random.Range (0, listToExpel.Count - 1);
				results.Add(listToExpel [rand]);
				listToExpel.RemoveAt (rand);
			}

		} else
			Debug.Log ("Za mało elementów w tablicy");

		return results;
	}
		
	void MakeQuestion (string partName, Button a, Button b, Button c, Button d, string version) {

		List<string> readyQuestion = new List<string> ();
		readyQuestion = DrawAnswers (partName, version);

		int rand = Random.Range(0, 3);
		readyQuestion.Insert (rand, partName);
		string structure = "";
		Renderer rend;
		Color startColor;
		Color changeColor = new Color (0f, 0f, 255f, 0f);

		ResetPosition (_assignModelsInstance);

		if (readyQuestion.Count != 4)
			Debug.Log ("Coś nie tak z MakeQuestion");
		else {
			a.GetComponentInChildren<Text> ().text = readyQuestion [0];
			b.GetComponentInChildren<Text> ().text = readyQuestion [1];
			c.GetComponentInChildren<Text> ().text = readyQuestion [2];
			d.GetComponentInChildren<Text> ().text = readyQuestion [3];
		}

		if (_first) {
			foreach (QuestionData q in _quizList) {
				if (q.partName == _previousElement) {
					rend = q.partName.GetComponent<Renderer> ();
					rend.material.color = _previousColor;
					break;
				}
			}
		}
					

		int whichQuestion = GetQuestionNr ();
		whichQuestion++;
		_questionNr.text = whichQuestion.ToString() + " / 10";

		if (version == "Pl") { 
			foreach (QuestionData q in _quizList) {
				if (q.textPl == partName) {
					structure = q.structure;
					rend = q.partName.GetComponent<Renderer> ();
					startColor = rend.GetComponent<Renderer> ().material.color;
					rend.material.color = changeColor;
					_previousElement = q.partName;
					_previousColor = startColor;
					_first = true;
					break;
				}
			}
		} else if (version == "Lat") { 
			foreach (QuestionData q in _quizList) {
				if (q.textLat == partName) {
					structure = q.structure;
					rend = q.partName.GetComponent<Renderer> ();
					startColor = rend.GetComponent<Renderer> ().material.color;
					rend.material.color = changeColor;
					_previousElement = q.partName;
					_previousColor = startColor;
					_first = true;
					break;
				}
			}
		}

		foreach (QuestionData q in _quizList) {
			if (q.structure == structure)
				q.partName.SetActive (true);
			else 
				q.partName.SetActive (false);
		}
	}
				
	void EndScreen() {
		int res = _score / 10;
		_resultText.gameObject.SetActive (true);

		string answerEnd = "";
		if (res == 1)
			answerEnd = " dobra odpowiedź";
		else if ((res == 2 || res == 3) || res == 4)
			answerEnd = " dobre odpowiedzi";
		else
			answerEnd = " dobrych odpowiedzi";
				
		_resultText.text = res.ToString () + answerEnd;

		_answerA.gameObject.SetActive (false);
		_answerB.gameObject.SetActive (false);
		_answerC.gameObject.SetActive (false);
		_answerD.gameObject.SetActive (false);
		_pick.gameObject.SetActive (false);

		_repeat.gameObject.SetActive (true);
		_newQuiz.gameObject.SetActive (true);
		_first = false;


		foreach (QuestionData q in _quizList) {
			if (q.partName == _previousElement) {
				Renderer rend = q.partName.GetComponent<Renderer> ();
				rend.material.color = _previousColor;
				break;
			}
		}

		foreach (QuestionData q in _quizList)
			q.partName.SetActive (false);

	}

	void CheckAnswer(Button a, Button b, Button c, Button d, string button) {
		int nr = GetQuestionNr ();
		string rightAnswer = _questionsList [nr];

		if (button == "a") {
			if (a.GetComponentInChildren<Text> ().text == rightAnswer)
				_score = _score + 10;
		} else if (button == "b") {
			if (b.GetComponentInChildren<Text> ().text == rightAnswer)
				_score = _score + 10;
		} else if (button == "c") {
			if (c.GetComponentInChildren<Text> ().text == rightAnswer)
				_score = _score + 10;
		} else if (button == "d") {
			if (d.GetComponentInChildren<Text> ().text == rightAnswer)
				_score = _score + 10;
		} else
			Debug.Log("Zle okresklony przycisk");

		SetQuestionNr ();
		nr = GetQuestionNr ();
		if (nr < _wholeQuiz && _questionsList.Count != 0)
			MakeQuestion (_questionsList [nr], a, b, c, d, _version);
		else
			EndScreen ();
	}


	List<string> Questions (string version) {
		int bulbusNr = Random.Range(3, 4);
		int musculiNr = Random.Range (2, 3);
		int nerviNr = Random.Range (1, 2);
		int osNr = 10 - bulbusNr - musculiNr - nerviNr; 
		List <string> q = new List<string>();
		List<string> questionsList = new List<string>();

		if (version == "Pl") {
			q = DrawQuerstion (_quizBulbusStringArrayPL, bulbusNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizMusculiStringArrayPL, musculiNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizNerviStringArrayPL, nerviNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizOsStringArrayPL, osNr);
			questionsList.AddRange (q);
		}
		else if (version == "Lat") {
			q = DrawQuerstion (_quizBulbusStringArrayLAT, bulbusNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizMusculiStringArrayLAT, musculiNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizNerviStringArrayLAT, nerviNr);
			questionsList.AddRange (q);
			q = DrawQuerstion (_quizOsStringArrayLAT, osNr);
			questionsList.AddRange (q);
		}

		// przemieszanie kolejnosci w liscie
		for (int i = 0; i < questionsList.Count; i++) {
			string temp = questionsList[i];
			int randomIndex = Random.Range(i, questionsList.Count - 1);
			questionsList[i] = questionsList[randomIndex];
			questionsList[randomIndex] = temp;
		}

		return questionsList;
	}

	void ChooseLang (Button lang) {
		_questionsList = Questions (lang.name);
		_pl.gameObject.SetActive (false);
		_lat.gameObject.SetActive (false);
		_pick.gameObject.SetActive (true);
		_answerA.gameObject.SetActive (true);
		_answerB.gameObject.SetActive (true);
		_answerC.gameObject.SetActive (true);
		_answerD.gameObject.SetActive (true);

		_chooseLang.gameObject.SetActive (false);

		MakeQuestion(_questionsList[_nr], _answerA, _answerB, _answerC, _answerD, lang.name);
		_version = lang.name;
	}

	void RepeatQuiz () {
		_nr = 0;
		_score = 0;
		_resultText.gameObject.SetActive (false);
		_repeat.gameObject.SetActive (false);
		_newQuiz.gameObject.SetActive (false);

		_pick.gameObject.SetActive (true);
		_answerA.gameObject.SetActive (true);
		_answerB.gameObject.SetActive (true);
		_answerC.gameObject.SetActive (true);
		_answerD.gameObject.SetActive (true);

		MakeQuestion(_questionsList[_nr], _answerA, _answerB, _answerC, _answerD, _version);
	}

	void NewQuiz () {
		_nr = 0;
		_score = 0;
		_questionsList.Clear ();
		_version = "";

		_resultText.gameObject.SetActive (false);
		_repeat.gameObject.SetActive (false);
		_newQuiz.gameObject.SetActive (false);

		_chooseLang.gameObject.SetActive (true);
		_pl.gameObject.SetActive (true);
		_lat.gameObject.SetActive (true);
	}

	void Start () {
		GameObject _models = GameObject.Find("Models");
		_assignModelsInstance = _models.GetComponent<AssignModels> ();

		GameObject _cameraObject = GameObject.Find ("Main Camera");
		_gm = _cameraObject.GetComponent<GameManager>();

		MakeQuizElements (_assignModelsInstance);
		SetQuizElements ();

		_nr = 0;
		_wholeQuiz = 10;
		_score = 0;

		_first = false;
		_infoState = true;

		_pl.onClick.AddListener (() => ChooseLang(_pl));
		_lat.onClick.AddListener (() => ChooseLang(_lat));

		_answerA.onClick.AddListener (() => CheckAnswer (_answerA, _answerB, _answerC, _answerD, "a"));
		_answerB.onClick.AddListener (() => CheckAnswer (_answerA, _answerB, _answerC, _answerD, "b"));
		_answerC.onClick.AddListener (() => CheckAnswer (_answerA, _answerB, _answerC, _answerD, "c"));
		_answerD.onClick.AddListener (() => CheckAnswer (_answerA, _answerB, _answerC, _answerD, "d"));	

		_repeat.onClick.AddListener (() => RepeatQuiz ());
		_newQuiz.onClick.AddListener (() => NewQuiz ());
	}

	void Update () {
		
		if (!_assignModelsInstance._corpusVitreumH.activeSelf) {
			_assignModelsInstance._whole.transform.Rotate (0, Input.GetAxis ("Horizontal") * (-30) * Time.deltaTime, 0);
			_assignModelsInstance._whole.transform.Rotate (Input.GetAxis ("Vertical") * 30 * Time.deltaTime, 0, 0);
		} else {
			_assignModelsInstance._whole.transform.RotateAround (new Vector3 (0.3f, 0, -0.75f), new Vector3 (0, 1, 0), Input.GetAxis ("Horizontal") * (-1)); 
			_assignModelsInstance._whole.transform.RotateAround (new Vector3 (0.3f, 0, -0.75f), new Vector3 (1, 0, 0), Input.GetAxis ("Vertical") * 1); 
		}

		_scoreText.text = "Wynik: " + _score.ToString() + " / 100";

		// wyjscie do menu
		if (Input.GetKeyUp (KeyCode.Escape)) {
			_gm.LoadScene("main");
		}
	}

	public void InfoOn() {
		if (!_infoState)
			_infoText.gameObject.SetActive (true);
		else if (_infoState)
			_infoText.gameObject.SetActive (false);

		_infoState = !_infoState;
	}
}
