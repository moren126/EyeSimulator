using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisordersData {

	public string name;
	public string toggleName;
	public GameObject[] partsBefore;
	public GameObject[] partsAfter;
	public Vector3 position;
	public Vector3 angle;
	public bool hasButtonsBA;
	public bool hasButtonsP;
	public Image image;

	public DisordersData (string _name, string _toggleName, GameObject[] _partsBefore, GameObject[] _partsAfter, Vector3 _position, Vector3 _angle, bool _hasButtonsBA, bool _hasButtonsP, Image _image) {
		name = _name;
		toggleName = _toggleName;
		partsBefore = _partsBefore;
		partsAfter = _partsAfter;
		position = _position;
		angle = _angle;
		hasButtonsBA = _hasButtonsBA;
		hasButtonsP = _hasButtonsP;
		image = _image;
	}
}
