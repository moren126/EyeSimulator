using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class TextsManager : MonoBehaviour {

	public Text _descriptionUpText;
	public Text _descriptionRightText;

	public GameObject _descriptionRight;
	public GameObject _scrollbarRight;
	public GameObject _descriptionUp;
	public Toggle _pinsToggle;

	public TextAsset _bChoroideaFile;
	public TextAsset _bCorneaFile;
	public TextAsset _bCorpusCiliareFile;
	public TextAsset _bCorpusVitreumFile;
	public TextAsset _bIrisFile;
	public TextAsset _bLensFile;
	public TextAsset _bRetinaFile;
	public TextAsset _bScleraFile;

	public TextAsset _mObliquusInferiorFile;
	public TextAsset _mObliquusSuperiorFile;
	public TextAsset _mRectusInferiorFile;
	public TextAsset _mRectusLateralisFile;
	public TextAsset _mRectusMedialisFile;
	public TextAsset _mRectusSuperiorFile;

	public TextAsset _nAbducensFile;
	public TextAsset _nOculomotoriusFile;
	public TextAsset _nOpticusFile;
	public TextAsset _nTrochlearisFile;

	public TextAsset _osEthmoidaleFile;
	public TextAsset _osFrontaleFile;
	public TextAsset _osLacrimaleFile;
	public TextAsset _osMaxillaFile;
	public TextAsset _osPalatinumFile;
	public TextAsset _osSphenoidaleFile;
	public TextAsset _osZygomaticumFile;

	public TextAsset _othAnulusFile;
	public TextAsset _othTrochleaFile;

	public TextAsset _pinsFile;

	private Button _fullSectionButton, _halfSectionButton, _resetButton;
	private Image _descriptionLeft;
	private Scrollbar _scrollbarLeft;

	private string[] lineList;
	private RaycastHit hit;
	private string distributor;
	private string _textToShow;
	private bool _showName;


	bool RayHitSthg() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit))
			return true;
		else
			return false;
	}
		
	void ShowDescription (Text whatKind, GameObject plane) {
		if (RayHitSthg ()) {
			
			plane.SetActive (true);

			if (hit.transform.name == "bCorpusVitreum")
				whatKind.text = _bCorpusVitreumFile.text;
			else if (hit.transform.name == "bRetina")
				whatKind.text = _bRetinaFile.text;
			else if (hit.transform.name == "bLens")
				whatKind.text = _bLensFile.text;
			else if (hit.transform.name == "bChoroidea")
				whatKind.text = _bChoroideaFile.text;
			else if (hit.transform.name == "bCorpusCiliare")
				whatKind.text = _bCorpusCiliareFile.text;
			else if (hit.transform.name == "bIris")
				whatKind.text = _bIrisFile.text;
			else if (hit.transform.name == "bSclera")
				whatKind.text = _bScleraFile.text;
			else if (hit.transform.name == "bCornea")
				whatKind.text = _bCorneaFile.text;
			else if (hit.transform.name == "mRectusMedialis")
				whatKind.text = _mRectusMedialisFile.text;
			else if (hit.transform.name == "mRectusLateralis")
				whatKind.text = _mRectusLateralisFile.text;
			else if (hit.transform.name == "mRectusSuperior")
				whatKind.text = _mRectusSuperiorFile.text;
			else if (hit.transform.name == "mRectusInferior")
				whatKind.text = _mRectusInferiorFile.text;
			else if (hit.transform.name == "mObliquusSuperior")
				whatKind.text = _mObliquusSuperiorFile.text;
			else if (hit.transform.name == "mObliquusInferior")
				whatKind.text = _mObliquusInferiorFile.text;
			else if (hit.transform.name == "nAbducens")
				whatKind.text = _nAbducensFile.text;
			else if (hit.transform.name == "nOculomotorius")
				whatKind.text = _nOculomotoriusFile.text;
			else if (hit.transform.name == "nOpticus")
				whatKind.text = _nOpticusFile.text;
			else if (hit.transform.name == "nTrochlearis")
				whatKind.text = _nTrochlearisFile.text;
			else if (hit.transform.name == "osEthmoidale")
				whatKind.text = _osEthmoidaleFile.text;
			else if (hit.transform.name == "osFrontale")
				whatKind.text = _osFrontaleFile.text;
			else if (hit.transform.name == "osLacrimale")
				whatKind.text = _osLacrimaleFile.text;
			else if (hit.transform.name == "osMaxilla")
				whatKind.text = _osMaxillaFile.text;
			else if (hit.transform.name == "osPalatinum")
				whatKind.text = _osPalatinumFile.text;
			else if (hit.transform.name == "osSphenoidale")
				whatKind.text = _osSphenoidaleFile.text;
			else if (hit.transform.name == "osZygomaticum")
				whatKind.text = _osZygomaticumFile.text;
			else if (hit.transform.name == "pinBackPole")
				whatKind.text = lineList [0];
			else if (hit.transform.name == "pinCanalisOpticus")
				whatKind.text = lineList [1];
			else if (hit.transform.name == "pinEquator")
				whatKind.text = lineList [2];
			else if (hit.transform.name == "pinFissuraOrbitalisInferior")
				whatKind.text = lineList [3];
			else if (hit.transform.name == "pinFissuraOrbitalisSuperior")
				whatKind.text = lineList [4];
			else if (hit.transform.name == "pinFrontPole")
				whatKind.text = lineList [5];
			else if (hit.transform.name == "pinInferiorWall")
				whatKind.text = lineList [6];
			else if (hit.transform.name == "pinLateralWall")
				whatKind.text = lineList [7];
			else if (hit.transform.name == "pinMedialWall")
				whatKind.text = lineList [8];
			else if (hit.transform.name == "pinSuperiorWall")
				whatKind.text = lineList [9];
			else if (hit.transform.name == "othAnulusTendineusCommunis")
				whatKind.text = _othAnulusFile.text;
			else if (hit.transform.name == "othTrochlea")
				whatKind.text = _othTrochleaFile.text;

		} else {
			whatKind.text = "";
			plane.SetActive (false);
		}
	}

	public void ShowFullDescription (string namePart) {

		_pinsToggle.isOn = false;
		_pinsToggle.gameObject.SetActive (false);
		_descriptionUp.SetActive (false);
		_showName = false;

		Text whatKind = _descriptionRightText;
		_descriptionRight.SetActive (true);
		_scrollbarRight.SetActive (true);

		if (namePart == "bCorpusVitreum")
			whatKind.text = _bCorpusVitreumFile.text;
		else if (namePart == "bRetina")
			whatKind.text = _bRetinaFile.text;
		else if (namePart == "bLens")
			whatKind.text = _bLensFile.text;
		else if (namePart == "bChoroidea")
			whatKind.text = _bChoroideaFile.text;
		else if (namePart == "bCorpusCiliare")
			whatKind.text = _bCorpusCiliareFile.text;
		else if (namePart == "bIris")
			whatKind.text = _bIrisFile.text;
		else if (namePart == "bSclera")
			whatKind.text = _bScleraFile.text;
		else if (namePart == "bCornea")
			whatKind.text = _bCorneaFile.text;
		else if (namePart == "mRectusMedialis")
			whatKind.text = _mRectusMedialisFile.text;
		else if (namePart == "mRectusLateralis")
			whatKind.text = _mRectusLateralisFile.text;
		else if (namePart == "mRectusSuperior")
			whatKind.text = _mRectusSuperiorFile.text;
		else if (namePart == "mRectusInferior")
			whatKind.text = _mRectusInferiorFile.text;
		else if (namePart == "mObliquusSuperior")
			whatKind.text = _mObliquusSuperiorFile.text;
		else if (namePart == "mObliquusInferior")
			whatKind.text = _mObliquusInferiorFile.text;
		else if (namePart == "nAbducens")
			whatKind.text = _nAbducensFile.text;
		else if (namePart == "nOculomotorius")
			whatKind.text = _nOculomotoriusFile.text;
		else if (namePart == "nOpticus")
			whatKind.text = _nOpticusFile.text;
		else if (namePart == "nTrochlearis")
			whatKind.text = _nTrochlearisFile.text;
		else if (namePart == "osEthmoidale")
			whatKind.text = _osEthmoidaleFile.text;
		else if (namePart == "osFrontale")
			whatKind.text = _osFrontaleFile.text;
		else if (namePart == "osLacrimale")
			whatKind.text = _osLacrimaleFile.text;
		else if (namePart == "osMaxilla")
			whatKind.text = _osMaxillaFile.text;
		else if (namePart == "osPalatinum")
			whatKind.text = _osPalatinumFile.text;
		else if (namePart == "osSphenoidale")
			whatKind.text = _osSphenoidaleFile.text;
		else if (namePart == "osZygomaticum")
			whatKind.text = _osZygomaticumFile.text;
		else if (namePart == "othAnulusTendineusCommunis")
			whatKind.text = _othAnulusFile.text;
		else if (namePart == "othTrochlea")
			whatKind.text = _othTrochleaFile.text;
		else
			whatKind = null;

		_descriptionRightText = whatKind;
	}

	public void SettOffFullDescription () {
		_pinsToggle.gameObject.SetActive (true);
		_descriptionRight.SetActive (false);
		_scrollbarRight.SetActive (false);
		_showName = true;
	}

	public void SettOffLeftMenu () {
		_fullSectionButton.gameObject.SetActive (false);
		_halfSectionButton.gameObject.SetActive (false);
		_resetButton.gameObject.SetActive (false);
		_descriptionLeft.gameObject.SetActive (false); 
		_scrollbarLeft.gameObject.SetActive (false);
	}

	public void SettOnLeftMenu () {
		_fullSectionButton.gameObject.SetActive (true);
		_halfSectionButton.gameObject.SetActive (true);
		_resetButton.gameObject.SetActive (true);
		_descriptionLeft.gameObject.SetActive (true); 
		_scrollbarLeft.gameObject.SetActive (true);
	}

	void Start () {
		_fullSectionButton = GameObject.Find ("FullSectionButton").GetComponent<UnityEngine.UI.Button> ();
		_halfSectionButton = GameObject.Find ("HalfSectionButton").GetComponent<UnityEngine.UI.Button> ();
		_resetButton = GameObject.Find ("ResetButton").GetComponent<UnityEngine.UI.Button> ();
		_descriptionLeft = GameObject.Find ("ListOfToggles").GetComponent<UnityEngine.UI.Image> ();
		_scrollbarLeft = GameObject.Find ("Scrollbar").GetComponent<UnityEngine.UI.Scrollbar> ();

		_descriptionUpText.text = "";

		if (_pinsFile)
			lineList = (_pinsFile.text.Split ('\n'));

		_showName = true;
	}

	void Update () {
		if (_showName)
			ShowDescription (_descriptionUpText, _descriptionUp);
	}

}
