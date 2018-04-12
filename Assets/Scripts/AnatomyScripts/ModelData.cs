using UnityEngine;
using System.Collections;

public class ModelData {

	public string name;
	public string toggleName;
	public GameObject part;
	public GameObject partH;
	public Color color;

	public ModelData (string _name, string _toggleName, GameObject _part, GameObject _partH, Color _color) {
		name = _name;
		toggleName = _toggleName;
		part = _part;
		partH = _partH;
		color = _color;
	}

}
