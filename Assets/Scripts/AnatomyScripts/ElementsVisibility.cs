using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ElementsVisibility : MonoBehaviour {

	public List <GameObject> _nonVisibility = new List<GameObject> ();
	public List <GameObject> _nonVisibilityH = new List<GameObject> ();
	public List <GameObject> nonHighlited = new List<GameObject> ();
	public List <GameObject> nonHighlitedH = new List<GameObject> ();
	public List <Toggle> _nonVisibleToggles = new List<Toggle> ();

	public List <Toggle> _orbitTogglesList = new List<Toggle> ();
	public List <Toggle> _musculiTogglesList = new List<Toggle> ();
	public List <Toggle> _nerviTogglesList = new List<Toggle> ();
	public List <Toggle> _bulbusTogglesList = new List<Toggle> ();
	public List <Toggle> _otherTogglesList = new List<Toggle> ();

	void Start () {
	
	}

	void Update () {
	
	}
}
