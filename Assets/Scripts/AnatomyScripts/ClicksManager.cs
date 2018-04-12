using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class ClicksManager : MonoBehaviour {

	public GameObject nothing;

	private Modes _whichMode;
	private ModelManager _modelManagerInstance;
	private ElementsVisibility _elementsVisibilityInstance;
	private TogglesManager _togglesManagerInstance;
	private TextsManager _textManagerInstance;
	private GameManager _gm;

	private GameObject positionBefore1, positionBefore2;
	private RaycastHit hit;
	private GameObject hitObject1, hitObject2;
	private Toggle hitToggle;
	private Color color;
	private bool rayHitSthg;
	private bool stopEyeRotation;
	private bool isHighlited;

	private float rotationSpeedH; 
	private float rotationSpeedV; 

	private float doubleClickTime;
	private float lastClickTime;

	private float fovBefore;
	private float minFov;
	private int _state;
	private bool wasSpace;

	private int index, index3;


	void AssignNames(GameObject model) {
		if (model.name == "Orbit") {
			foreach (Transform child in model.transform) {
				if (!child.name.StartsWith ("p"))
					_elementsVisibilityInstance.nonHighlited.Add (child.gameObject);
			}
		} else if (model.name == "HalfOrbit") {
			foreach (Transform child in model.transform) {
				if (!child.name.StartsWith ("p"))
					_elementsVisibilityInstance.nonHighlitedH.Add (child.gameObject);
			}
		}
	}

	void Start () {
		GameObject _modelsObject = GameObject.Find ("Models");
		_modelManagerInstance = _modelsObject.GetComponent<ModelManager>();
		_elementsVisibilityInstance = _modelsObject.GetComponent<ElementsVisibility> ();

		GameObject _mainCanvasObject = GameObject.Find ("Main Canvas");
		_textManagerInstance = _mainCanvasObject.GetComponent<TextsManager>();
		_whichMode = _mainCanvasObject.GetComponent<Modes>();
		_state = _whichMode.state;

		GameObject _togglesObject = GameObject.Find("ObjectForTogglesScipts");
		_togglesManagerInstance = _togglesObject.GetComponent<TogglesManager> ();

		GameObject _cameraObject = GameObject.Find ("Main Camera");
		_gm = _cameraObject.GetComponent<GameManager>();

		AssignNames (_modelManagerInstance._orbit);
		AssignNames (_modelManagerInstance._halfOrbit);

		isHighlited = false;
		rayHitSthg = false;
		stopEyeRotation = false;
		wasSpace = false;

		doubleClickTime = 1.0f;
		lastClickTime = -10.0f;

		minFov = 30;

		positionBefore1 = new GameObject ();
		positionBefore2 = new GameObject ();

		hitObject1 = nothing;
		hitObject2 = nothing;

		index = index3 = 0;

		rotationSpeedH = -30;
		rotationSpeedV = -30;
	}
		
	void Update () {
		_state = _whichMode.state;

		_togglesManagerInstance.CheckMainToggles(_state);
		_togglesManagerInstance.CheckMinorToggles(_state);

		// na co wskazuje kursor
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			foreach (ModelData m in _modelManagerInstance._modelList) {
				if (hit.transform.name == m.name) {
					hitObject1 = m.part;
					hitObject2 = m.partH;
					color = m.color;
					rayHitSthg = true;

					foreach (Toggle t in _togglesManagerInstance._togglesList) {
						if (t.name == m.toggleName) {
							hitToggle = t;
							break;
						}
					}

					break;
				}
			}
		} else {
			// zabezpieczenie
			if (!isHighlited) { 
				hitObject1 = nothing;
				hitObject2 = nothing;
			}
		}


		// kursor wskazuje na obiekt z colliderem
		if (rayHitSthg && (hitObject1 != nothing || hitObject2 != nothing)) {

			// dezaktywacja klikanych obiektow - podwójny LPM
			if (Input.GetMouseButtonDown (0)) {

				float timeDelta = Time.time - lastClickTime;

				if (!isHighlited) {

					if (timeDelta < doubleClickTime) {
						
						// zapamietanie koloru elementu przed podswietleniem 
						hitObject1.GetComponent<Renderer> ().material.color = color;
						hitObject2.GetComponent<Renderer> ().material.color = color;
				
						// dodawanie do listy i dezaktywacja klikanych podwojnie elementow
						if (!_elementsVisibilityInstance._nonVisibility.Contains(hitObject1))
							_elementsVisibilityInstance._nonVisibility.Add (hitObject1);
						if (!_elementsVisibilityInstance._nonVisibilityH.Contains(hitObject2))
							_elementsVisibilityInstance._nonVisibilityH.Add (hitObject2);
						
						hitObject1.SetActive (false);
						hitObject2.SetActive (false);

						// dodawanie do listy i dezaktywacja przelacznika do klikanego podwojnie elementu
						if (!_elementsVisibilityInstance._nonVisibleToggles.Contains(hitToggle))
							_elementsVisibilityInstance._nonVisibleToggles.Add (hitToggle);
						hitToggle.isOn = false;

						lastClickTime = 0;

					} else
						lastClickTime = Time.time;
				}
			}

			// wyroznienie elementu - wcisnieta raz spacja
			if (Input.GetKeyUp (KeyCode.Space) && !wasSpace) {

				if (!isHighlited) {
					// usuwanie elemtow wyroznionych (nonHighlited zawiera wszystkie elemnty modelu)
					_elementsVisibilityInstance.nonHighlited.Remove (hitObject1);
					_elementsVisibilityInstance.nonHighlitedH.Remove (hitObject2);

					// dezaktywacja wszystkich elementow poza wyroznionymi
					for (int x = 0; x < _elementsVisibilityInstance.nonHighlited.Count; x++)
						_elementsVisibilityInstance.nonHighlited[x].SetActive(false);

					for (int x = 0; x < _elementsVisibilityInstance.nonHighlitedH.Count; x++)
						_elementsVisibilityInstance.nonHighlitedH[x].SetActive(false);

					// warunek o stanie wyroznienia elementu
					isHighlited = true;
				}

				// zapamietanie widoku kamery przed wyroznianiem elementu
				fovBefore = Camera.main.fieldOfView;
				// zoom (by wyrozniony element bylo lepiej widac)
				Camera.main.fieldOfView = minFov;

				// zapamietanie pozycji modelu przed wyroznianiem elementu
				positionBefore1.transform.position = new Vector3 (hitObject1.transform.position.x, hitObject1.transform.position.y, hitObject1.transform.position.z);
				positionBefore1.transform.eulerAngles = new Vector3 (hitObject1.transform.eulerAngles.x, hitObject1.transform.eulerAngles.y, hitObject1.transform.eulerAngles.z);
				positionBefore2.transform.position = new Vector3 (hitObject2.transform.position.x, hitObject2.transform.position.y, hitObject2.transform.position.z);
				positionBefore2.transform.eulerAngles = new Vector3 (hitObject2.transform.eulerAngles.x, hitObject2.transform.eulerAngles.y, hitObject2.transform.eulerAngles.z);

				// przesuniecie wyroznionego elementu na srodek ekranu
				hitObject1.transform.position = new Vector3 (0, 0, 0);
				hitObject2.transform.position = new Vector3 (0, 0, 0);

				// warunek o stopowaniu widocznego obracania calego modelu, obraca sie tylko wyroznoiny element
				stopEyeRotation = true;

				// wcisnieto raz spacje (zabezpieczenie przed wieloklikiem)
				wasSpace = true;

				_textManagerInstance.ShowFullDescription (hitObject1.name);
				_textManagerInstance.SettOffLeftMenu ();
			}


		}


		// jesli nie ma stopowania widocznego obracania calego modelu -> caly model sie obraca
		if (!stopEyeRotation) {
			_modelManagerInstance._orbit.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
			_modelManagerInstance._orbit.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
			_modelManagerInstance._halfOrbit.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
			_modelManagerInstance._halfOrbit.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
		} 
		//jesli stopowanie widocznego obracania calego modelu -> obraca sie tylko wyrozniony element (x2)
		else {
			if (hitObject1.name == "bCorpusVitreum" || hitObject1.name == "bLens") {
				hitObject1.transform.Rotate (0, 0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime);
				hitObject2.transform.Rotate (0, 0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime);
				hitObject1.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
				hitObject2.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
			} else if (hitObject1.name == "mRectusInferior" || hitObject1.name == "mObliquusInferior") {
				hitObject1.transform.Rotate (0, Input.GetAxis ("Horizontal") * (-1) * rotationSpeedH * Time.deltaTime, 0);
				hitObject2.transform.Rotate (0, Input.GetAxis ("Horizontal") * (-1) * rotationSpeedH * Time.deltaTime, 0);
				hitObject1.transform.Rotate (Input.GetAxis ("Vertical") * (-1) * rotationSpeedV * Time.deltaTime, 0, 0);
				hitObject2.transform.Rotate (Input.GetAxis ("Vertical") * (-1) * rotationSpeedV * Time.deltaTime, 0, 0);
			} else if (hitObject1.name == "mRectusLateralis" || hitObject1.name == "mRectusMedialis") {
				hitObject1.transform.Rotate (0, Input.GetAxis ("Vertical") * rotationSpeedH * Time.deltaTime, 0);
				hitObject2.transform.Rotate (0, Input.GetAxis ("Vertical") * rotationSpeedH * Time.deltaTime, 0);
				hitObject1.transform.Rotate (Input.GetAxis ("Horizontal") * rotationSpeedV * Time.deltaTime, 0, 0);
				hitObject2.transform.Rotate (Input.GetAxis ("Horizontal") * rotationSpeedV * Time.deltaTime, 0, 0);
			} else {
				hitObject1.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
				hitObject2.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
				hitObject1.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
				hitObject2.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);
			}
		}

		// obsluga PPM 
		if (Input.GetMouseButtonDown(1)) {

			// cofanie wyroznienia elementu
			if (isHighlited) {

				// przywracanie niewyroznionych elementow (wyroznione elementy byly caly czas aktywne) 
				for (int x = 0; x < _elementsVisibilityInstance.nonHighlited.Count; x++)
					_elementsVisibilityInstance.nonHighlited[x].SetActive(true);

				for (int x = 0; x < _elementsVisibilityInstance.nonHighlitedH.Count; x++)
					_elementsVisibilityInstance.nonHighlitedH[x].SetActive(true);

				if (!_elementsVisibilityInstance.nonHighlited.Contains(hitObject1))
					_elementsVisibilityInstance.nonHighlited.Add (hitObject1);
				if (!_elementsVisibilityInstance.nonHighlitedH.Contains(hitObject2))
					_elementsVisibilityInstance.nonHighlitedH.Add (hitObject2);

				// wylaczanie elementow zdjetych przed wyroznianiem
				foreach (GameObject item in _elementsVisibilityInstance._nonVisibility)
					item.SetActive (false);
				foreach (GameObject item in _elementsVisibilityInstance._nonVisibilityH)
					item.SetActive (false);

				// powrot do widoku kamery i pozycji elementów sprzed wyrozniania
				Camera.main.fieldOfView = fovBefore;
				hitObject1.transform.position = new Vector3 (positionBefore1.transform.position.x, positionBefore1.transform.position.y, positionBefore1.transform.position.z);
				hitObject1.transform.eulerAngles = new Vector3 (positionBefore1.transform.eulerAngles.x, positionBefore1.transform.eulerAngles.y, positionBefore1.transform.eulerAngles.z);
				hitObject2.transform.position = new Vector3 (positionBefore2.transform.position.x, positionBefore2.transform.position.y, positionBefore2.transform.position.z);
				hitObject2.transform.eulerAngles = new Vector3 (positionBefore2.transform.eulerAngles.x, positionBefore2.transform.eulerAngles.y, positionBefore2.transform.eulerAngles.z);

				// warunek o stopowaniu widocznego obracania calego modelu jest juz nieprawdziwy
				stopEyeRotation = false;

				// warunek o pojedynczym wcisnieciu klawisza spacji jest juz nieprawdziwy
				wasSpace = false;

				// warunek o wyroznianiu elementu jt juz nieprawdziwy
				isHighlited = false;

				_textManagerInstance.SettOffFullDescription ();
				_textManagerInstance.SettOnLeftMenu ();
			}

			// cofanie dezaktywacji elementow (1 klik - 1 element)
			else if (_elementsVisibilityInstance._nonVisibility.Count > 0) {
				index = _elementsVisibilityInstance._nonVisibility.Count - 1;

				GameObject undo = _elementsVisibilityInstance._nonVisibility [index];
				if (undo) { 
					undo.SetActive (true);
					_elementsVisibilityInstance._nonVisibility.RemoveAt (index);
				}

				index = _elementsVisibilityInstance._nonVisibilityH.Count - 1;
				undo = _elementsVisibilityInstance._nonVisibilityH [index];

				if (undo) {
					undo.SetActive (true);
					_elementsVisibilityInstance._nonVisibilityH.RemoveAt (index);
				}

				// ustawianie przelacznikow do dezaktywowanych elemetow na wlaczone
				if (_elementsVisibilityInstance._nonVisibleToggles.Count >= 0) {
					index3 = _elementsVisibilityInstance._nonVisibleToggles.Count - 1;
					Toggle undo3 = _elementsVisibilityInstance._nonVisibleToggles [index3];
					undo3.isOn = true;
					if (index3 >= 0 && index3 < _elementsVisibilityInstance._nonVisibleToggles.Count)
						_elementsVisibilityInstance._nonVisibleToggles.RemoveAt (index3);
				}

			// zabezpieczenie przed koncem
			} else if (_elementsVisibilityInstance._nonVisibility.Count == 0) {
				_elementsVisibilityInstance._nonVisibility.Clear ();
				_elementsVisibilityInstance._nonVisibilityH.Clear ();
			}
		}

		// wyjscie do menu
		if (Input.GetKeyUp (KeyCode.Escape)) {
			_gm.LoadScene("main");
		}
			
	}

}