using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class DisordersTextManager : MonoBehaviour {

	public Image _descriptionDown;
	public Scrollbar _scrollbarDown;
	public Text _description;

	public Image _descriptionUp;
	public Text _descriptionUpText;

	public TextAsset _myopiaFile;
	public TextAsset _hyperopiaFile;
	public TextAsset _astigFile;

	public TextAsset _cataractaFile;
	public TextAsset _hyphemaFile;
	public TextAsset _uveitisFile;
	public TextAsset _ablatioFile;

	public TextAsset _disordersFile;

	private string[] lineList;
	private RaycastHit hit;
	private string _textToShow;


	bool RayHitSthg() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit))
			return true;
		else
			return false;
	}

	void ShowHightLight (Text whatKind, Image plane) {
		if (RayHitSthg ()) {

			plane.gameObject.SetActive (true);

			if (hit.transform.name == "bLensCapsule") 
				whatKind.text = lineList [0];
			else if (hit.transform.name == "bLensCortex")
				whatKind.text = lineList [1];
			else if (hit.transform.name == "bLensNucleus")
				whatKind.text = lineList [2];
			else if (hit.transform.name == "eHyphema")
				whatKind.text = lineList [3];
			else if (hit.transform.name == "eInflammation")
				whatKind.text = lineList [4];
			else if (hit.transform.name.StartsWith("S"))
				whatKind.text = lineList [5];
			else if (hit.transform.name == "bRetina")
				whatKind.text = lineList [6];

		} else {
			whatKind.text = "";
			plane.gameObject.SetActive (false);
		}
	}

	public void ShowDescription(string name) {

		if (name == "myopia") {
			_description.text = _myopiaFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "hyperopia") {
			_description.text = _hyperopiaFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "astig") {
			_description.text = _astigFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "cataracta") {
			_description.text = _cataractaFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "hyphema") {
			_description.text = _hyphemaFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "uveitis") {
			_description.text = _uveitisFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		} else if (name == "ablatio") {
			_description.text = _ablatioFile.text;
			_descriptionDown.gameObject.SetActive (true);
			_scrollbarDown.gameObject.SetActive (true);
		}
		else if (name == "clear") {
			_description.text = "";
			_descriptionDown.gameObject.SetActive (false);
			_scrollbarDown.gameObject.SetActive (false);
		}
		else
			Debug.Log ("Zła nazwa");
	}

	void Awake () {
		_descriptionDown.gameObject.SetActive (false);
	}

	void Start () {
		if (_disordersFile)
			lineList = (_disordersFile.text.Split ('\n'));

		_descriptionDown.rectTransform.sizeDelta = new Vector2 (_descriptionDown.rectTransform.rect.width, (Screen.height / 4));
		_scrollbarDown.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2 (_scrollbarDown.GetComponentInChildren<RectTransform>().rect.width, (Screen.height / 4));
	}
	

	void Update () {
		ShowHightLight (_descriptionUpText, _descriptionUp);
	}
}
