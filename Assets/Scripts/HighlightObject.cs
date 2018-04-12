using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {
	
	private Color _startColor;
	private Color _changeColor;
	private Renderer _rend;
	private string _name;

	public Color GetColor () {
		return _startColor;
	}

	void Start () {
		_rend = GetComponent<Renderer> ();
		_startColor = GetComponent<Renderer> ().material.color;
		_changeColor = new Color (0f, 0f, 255f, 0f);
	}

	void OnMouseEnter() {
		_rend.material.color = _changeColor;
	}

	void OnMouseExit() {
		_rend.material.color = _startColor;
	}
		
}
