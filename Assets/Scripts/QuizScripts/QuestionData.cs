using UnityEngine;
using System.Collections;

public class QuestionData {

	public string textLat;
	public string textPl;
	public GameObject partName;
	public string[] otherAnswersLat;
	public string[] otherAnswersPl;
	public string structure;

	public QuestionData (string _textLat, string _textPl, GameObject _partName, string[] _otherLat, string[] _otherPl, string _structure) {
		textLat = _textLat;
		textPl = _textPl;
		partName = _partName;
		otherAnswersLat = _otherLat;
		otherAnswersPl = _otherPl;
		structure = _structure;
	}

}
