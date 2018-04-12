using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Menu _currentMenu;
	public GameObject _bulbus;

	public void Start () {
		ShowMenu (_currentMenu);
	}

	public void ShowMenu(Menu menu) {
		if (_currentMenu != null)
			_currentMenu.isOpen = false;

		_currentMenu = menu;
		_currentMenu.isOpen = true; 
	}

	void Update () {
		Quaternion rotateUp = Quaternion.AngleAxis(0.6f, Vector3.up);
		_bulbus.transform.rotation = _bulbus.transform.rotation * rotateUp;
	}
}
