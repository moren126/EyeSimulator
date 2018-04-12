using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TogglesManager : MonoBehaviour {

	public List<Toggle> _togglesList = new List<Toggle> (); 

	private Toggle _isORBITToggle, _isOsFrontaleToggle, _isOsMaxillaToggle, _isOsZygomaticumToggle, _isOsLacrimaleToggle, _isOsEthmoidaleToggle, _isOsSphenoidaleToggle, _isOsPalatinumToggle;
	private Toggle _isMUSCULIToggle, _isMRectusMedialisToggle, _isMRectusLateralisToggle, _isMRectusSuperiorToggle, _isMRectusInferiorToggle, _isMObliquusSuperiorToggle, _isMObliquusInferiorToggle;
	private Toggle _isNERVIToggle, _isNOpticusToggle, _isNOculomotoriusToggle, _isNTrochlearisToggle, _isNAbducensToggle;
	private Toggle _isBULBUSOCULIToggle, _isCorneaToggle, _isScleraToggle, _isChoroideaToggle, _isCorpusCiliareToggle, _isIrisToggle, _isRetinaToggle, _isLensToggle, _isCorpusVitreumToggle;
	private Toggle _isOTHERToggle, _isOthAnulusToggle, _isOthTrochleaToggle;

	private GameObject _modelsObject;
	private ModelManager _modelManagerInstance;
	private ElementsVisibility _elementsVisibilityInstance;
	private int orbitDistance, muscliDistance, nerviDistance, bulbusDistance;


	void AssignToggles() {
		_isORBITToggle = GameObject.Find ("ORBITTOGGLE").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsFrontaleToggle = GameObject.Find("osFrontaleToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsMaxillaToggle = GameObject.Find("osMaxillaToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsZygomaticumToggle = GameObject.Find("osZygomaticumToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsLacrimaleToggle = GameObject.Find("osLacrimaleToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsEthmoidaleToggle = GameObject.Find("osEthmoidaleToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsSphenoidaleToggle = GameObject.Find("osSphenoidaleToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOsPalatinumToggle = GameObject.Find("osPalatinumToggle").GetComponent<UnityEngine.UI.Toggle> ();

		_isMUSCULIToggle = GameObject.Find("MUSCULITOGGLE").GetComponent<UnityEngine.UI.Toggle> ();
		_isMRectusMedialisToggle = GameObject.Find("mRectusMedialisToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isMRectusLateralisToggle = GameObject.Find("mRectusLateralisToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isMRectusSuperiorToggle = GameObject.Find("mRectusSuperiorToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isMRectusInferiorToggle = GameObject.Find("mRectusInferiorToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isMObliquusSuperiorToggle = GameObject.Find("mObliquusSuperiorToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isMObliquusInferiorToggle = GameObject.Find("mObliquusInferiorToggle").GetComponent<UnityEngine.UI.Toggle> ();

		_isNERVIToggle = GameObject.Find("NERVITOGGLE").GetComponent<UnityEngine.UI.Toggle> ();
		_isNOpticusToggle = GameObject.Find("nOpticusToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isNOculomotoriusToggle = GameObject.Find("nOculomotoriusToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isNTrochlearisToggle = GameObject.Find("nTrochlearisToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isNAbducensToggle = GameObject.Find("nAbducensToggle").GetComponent<UnityEngine.UI.Toggle> ();

		_isBULBUSOCULIToggle = GameObject.Find ("BULBUSOCULITOGGLE").GetComponent<UnityEngine.UI.Toggle> ();
		_isCorneaToggle = GameObject.Find("corneaToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isScleraToggle = GameObject.Find("scleraToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isChoroideaToggle = GameObject.Find("choroideaToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isCorpusCiliareToggle = GameObject.Find("corpusCiliareToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isIrisToggle = GameObject.Find("irisToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isRetinaToggle = GameObject.Find("retinaToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isLensToggle = GameObject.Find("lensToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isCorpusVitreumToggle = GameObject.Find("corpusVitreumToggle").GetComponent<UnityEngine.UI.Toggle> ();

		_isOTHERToggle = GameObject.Find ("OTHERTOGGLE").GetComponent<UnityEngine.UI.Toggle> ();
		_isOthAnulusToggle = GameObject.Find("anulusToggle").GetComponent<UnityEngine.UI.Toggle> ();
		_isOthTrochleaToggle = GameObject.Find("trochleaToggle").GetComponent<UnityEngine.UI.Toggle> ();

	}

	void SetStacks(ElementsVisibility elementVisibility) {
		elementVisibility._orbitTogglesList.Add (_isORBITToggle);
		elementVisibility._orbitTogglesList.Add (_isOsEthmoidaleToggle);
		elementVisibility._orbitTogglesList.Add (_isOsFrontaleToggle);
		elementVisibility._orbitTogglesList.Add (_isOsLacrimaleToggle);
		elementVisibility._orbitTogglesList.Add (_isOsMaxillaToggle);
		elementVisibility._orbitTogglesList.Add (_isOsPalatinumToggle);
		elementVisibility._orbitTogglesList.Add (_isOsSphenoidaleToggle);
		elementVisibility._orbitTogglesList.Add (_isOsZygomaticumToggle);

		elementVisibility._musculiTogglesList.Add (_isMUSCULIToggle);
		elementVisibility._musculiTogglesList.Add (_isMObliquusInferiorToggle);
		elementVisibility._musculiTogglesList.Add (_isMObliquusSuperiorToggle);
		elementVisibility._musculiTogglesList.Add (_isMRectusInferiorToggle);
		elementVisibility._musculiTogglesList.Add (_isMRectusLateralisToggle);
		elementVisibility._musculiTogglesList.Add (_isMRectusMedialisToggle);
		elementVisibility._musculiTogglesList.Add (_isMRectusSuperiorToggle);

		elementVisibility._nerviTogglesList.Add (_isNERVIToggle);
		elementVisibility._nerviTogglesList.Add (_isNAbducensToggle);
		elementVisibility._nerviTogglesList.Add (_isNOculomotoriusToggle);
		elementVisibility._nerviTogglesList.Add (_isNOpticusToggle);
		elementVisibility._nerviTogglesList.Add (_isNTrochlearisToggle);

		elementVisibility._bulbusTogglesList.Add (_isBULBUSOCULIToggle);
		elementVisibility._bulbusTogglesList.Add (_isCorneaToggle);
		elementVisibility._bulbusTogglesList.Add (_isScleraToggle);
		elementVisibility._bulbusTogglesList.Add (_isChoroideaToggle);
		elementVisibility._bulbusTogglesList.Add (_isCorpusCiliareToggle);
		elementVisibility._bulbusTogglesList.Add (_isIrisToggle);
		elementVisibility._bulbusTogglesList.Add (_isRetinaToggle);
		elementVisibility._bulbusTogglesList.Add (_isLensToggle);
		elementVisibility._bulbusTogglesList.Add (_isCorpusVitreumToggle);

		elementVisibility._otherTogglesList.Add (_isOTHERToggle);
		elementVisibility._otherTogglesList.Add (_isOthAnulusToggle);
		elementVisibility._otherTogglesList.Add (_isOthTrochleaToggle);
	}
		
	void CheckToggleGroup (List<Toggle> partsTogglesStack) {
		int enabled = 0;
		foreach (Toggle item in partsTogglesStack) {
			if (item.isOn)
				enabled += 1;
		}
		if (enabled <= 1)
			partsTogglesStack [0].isOn = false;
	}

	void CheckBigToggle (Toggle partsName, List<Toggle> partsTogglesStack) { //, int stateOfToggles) {
		partsName.onValueChanged.AddListener ((bool on) => { 
			if (on == false) {
				foreach (Toggle item in partsTogglesStack) {
					item.isOn = false;
				}
			}
			else if (on == true) {
				foreach (Toggle item in partsTogglesStack) {
					item.isOn = true;
				}
			}
		});
	}

	public void CheckMainToggles(int stateOfGame) {
		CheckBigToggle (_isORBITToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckBigToggle (_isMUSCULIToggle, _elementsVisibilityInstance._musculiTogglesList);
		CheckBigToggle (_isNERVIToggle, _elementsVisibilityInstance._nerviTogglesList);
		CheckBigToggle (_isBULBUSOCULIToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckBigToggle (_isOTHERToggle, _elementsVisibilityInstance._otherTogglesList);
	}
		
	void CheckToggle (GameObject part, GameObject partH, Toggle partToggle, List<Toggle> partsTogglesStack) {
		partToggle.onValueChanged.AddListener ((bool on) => {
			part.SetActive (on);
			partH.SetActive (on);

			if (on == false) {
				if (!_elementsVisibilityInstance._nonVisibility.Contains(part))
					_elementsVisibilityInstance._nonVisibility.Add (part);
				if (!_elementsVisibilityInstance._nonVisibilityH.Contains(partH))
					_elementsVisibilityInstance._nonVisibilityH.Add (partH);
				if (!_elementsVisibilityInstance._nonVisibleToggles.Contains(partToggle))
					_elementsVisibilityInstance._nonVisibleToggles.Add(partToggle);
				CheckToggleGroup (partsTogglesStack);
			} else if (on == true) {
				_elementsVisibilityInstance._nonVisibility.Remove (part);
				_elementsVisibilityInstance._nonVisibilityH.Remove (partH);
				_elementsVisibilityInstance._nonVisibleToggles.Remove(partToggle);
			}
		});

	}
		
	public void CheckMinorToggles(int stateOfGame) {
		CheckToggle (_modelManagerInstance._osEthmoidale, _modelManagerInstance._osEthmoidaleH, _isOsEthmoidaleToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osFrontale, _modelManagerInstance._osFrontaleH, _isOsFrontaleToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osLacrimale, _modelManagerInstance._osLacrimaleH, _isOsLacrimaleToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osMaxilla, _modelManagerInstance._osMaxillaH, _isOsMaxillaToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osPalatinum, _modelManagerInstance._osPalatinumH, _isOsPalatinumToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osSphenoidale, _modelManagerInstance._osSphenoidaleH, _isOsSphenoidaleToggle, _elementsVisibilityInstance._orbitTogglesList);
		CheckToggle (_modelManagerInstance._osZygomaticum, _modelManagerInstance._osZygomaticumH, _isOsZygomaticumToggle, _elementsVisibilityInstance._orbitTogglesList);

		CheckToggle (_modelManagerInstance._mObliquusInferior, _modelManagerInstance._mObliquusInferiorH, _isMObliquusInferiorToggle, _elementsVisibilityInstance._musculiTogglesList); 
		CheckToggle (_modelManagerInstance._mObliquusSuperior, _modelManagerInstance._mObliquusSuperiorH, _isMObliquusSuperiorToggle, _elementsVisibilityInstance._musculiTogglesList); 
		CheckToggle (_modelManagerInstance._mRectusInferior, _modelManagerInstance._mRectusInferiorH, _isMRectusInferiorToggle, _elementsVisibilityInstance._musculiTogglesList);
		CheckToggle (_modelManagerInstance._mRectusLateralis, _modelManagerInstance._mRectusLateralisH, _isMRectusLateralisToggle, _elementsVisibilityInstance._musculiTogglesList);
		CheckToggle (_modelManagerInstance._mRectusMedialis, _modelManagerInstance._mRectusMedialisH, _isMRectusMedialisToggle, _elementsVisibilityInstance._musculiTogglesList);
		CheckToggle (_modelManagerInstance._mRectusSuperior, _modelManagerInstance._mRectusSuperiorH, _isMRectusSuperiorToggle, _elementsVisibilityInstance._musculiTogglesList);

		CheckToggle (_modelManagerInstance._nAbducens, _modelManagerInstance._nAbducensH, _isNAbducensToggle, _elementsVisibilityInstance._nerviTogglesList);
		CheckToggle (_modelManagerInstance._nOculomotorius, _modelManagerInstance._nOculomotoriusH, _isNOculomotoriusToggle, _elementsVisibilityInstance._nerviTogglesList);
		CheckToggle (_modelManagerInstance._nOpticus, _modelManagerInstance._nOpticusH, _isNOpticusToggle, _elementsVisibilityInstance._nerviTogglesList);
		CheckToggle (_modelManagerInstance._nTrochlearis, _modelManagerInstance._nTrochlearisH, _isNTrochlearisToggle, _elementsVisibilityInstance._nerviTogglesList);

		CheckToggle (_modelManagerInstance._corpusVitreum, _modelManagerInstance._corpusVitreumH, _isCorpusVitreumToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._retina, _modelManagerInstance._retinaH, _isRetinaToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._lens, _modelManagerInstance._lensH, _isLensToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._choroidea, _modelManagerInstance._choroideaH, _isChoroideaToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._corpusCiliare, _modelManagerInstance._corpusCiliareH, _isCorpusCiliareToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._iris, _modelManagerInstance._irisH, _isIrisToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._sclera, _modelManagerInstance._scleraH, _isScleraToggle, _elementsVisibilityInstance._bulbusTogglesList);
		CheckToggle (_modelManagerInstance._cornea, _modelManagerInstance._corneaH, _isCorneaToggle, _elementsVisibilityInstance._bulbusTogglesList);

		CheckToggle (_modelManagerInstance._othAnulus, _modelManagerInstance._othAnulusH, _isOthAnulusToggle, _elementsVisibilityInstance._otherTogglesList);
		CheckToggle (_modelManagerInstance._othTrochlea, _modelManagerInstance._othTrochleaH, _isOthTrochleaToggle, _elementsVisibilityInstance._otherTogglesList);
	}

	void SetToggles () {
		_togglesList.AddRange (new Toggle[] {_isOsFrontaleToggle, _isOsMaxillaToggle, _isOsZygomaticumToggle, _isOsLacrimaleToggle, _isOsEthmoidaleToggle, _isOsSphenoidaleToggle, _isOsPalatinumToggle});
		_togglesList.AddRange (new Toggle[] {_isMRectusMedialisToggle, _isMRectusLateralisToggle, _isMRectusSuperiorToggle, _isMRectusInferiorToggle, _isMObliquusSuperiorToggle, _isMObliquusInferiorToggle}); 
		_togglesList.AddRange (new Toggle[] {_isNOpticusToggle, _isNOculomotoriusToggle, _isNTrochlearisToggle, _isNAbducensToggle});
		_togglesList.AddRange (new Toggle[] {_isCorneaToggle, _isScleraToggle, _isChoroideaToggle, _isCorpusCiliareToggle, _isIrisToggle, _isRetinaToggle, _isLensToggle, _isCorpusVitreumToggle});
		_togglesList.AddRange (new Toggle[] {_isOthAnulusToggle, _isOthTrochleaToggle});
	}
		
	void Awake () {
		DontDestroyOnLoad (_elementsVisibilityInstance);
	}

	void Start() {
		_modelsObject = GameObject.Find ("Models");
		_modelManagerInstance = _modelsObject.GetComponent<ModelManager>();
		_elementsVisibilityInstance = _modelsObject.GetComponent<ElementsVisibility> ();

		AssignToggles ();
		SetStacks (_elementsVisibilityInstance);

		orbitDistance = 180;
		muscliDistance = 155;
		nerviDistance = 105;
		bulbusDistance = 205; 

		SetToggles ();
	}
		
	void Update () {
	}
		
	void ChangeLocalPositions (List<Toggle> partsMove, int distance) { 
		foreach (Toggle t in partsMove)
			t.transform.localPosition = new Vector3 (t.transform.localPosition.x, (t.transform.localPosition.y + distance), t.transform.localPosition.z);
	}

	public void SetOrbit() {

		if (!_isORBITToggle.isOn) {
			for (int i = 1; i < _elementsVisibilityInstance._orbitTogglesList.Count; i++)
				_elementsVisibilityInstance._orbitTogglesList[i].gameObject.SetActive (false);

			ChangeLocalPositions (_elementsVisibilityInstance._musculiTogglesList, orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._nerviTogglesList, orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, orbitDistance);
		} else {
			for (int i = 1; i < _elementsVisibilityInstance._orbitTogglesList.Count; i++)
				_elementsVisibilityInstance._orbitTogglesList[i].gameObject.SetActive (true);

			ChangeLocalPositions (_elementsVisibilityInstance._musculiTogglesList, -orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._nerviTogglesList, -orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, -orbitDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, -orbitDistance);
		}
	}

	public void SetMuscli () {

		if (!_isMUSCULIToggle.isOn) {
			for(int i = 1; i < _elementsVisibilityInstance._musculiTogglesList.Count; i++)
				_elementsVisibilityInstance._musculiTogglesList[i].gameObject.SetActive (false);

			ChangeLocalPositions (_elementsVisibilityInstance._nerviTogglesList, muscliDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, muscliDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, muscliDistance);
		} else {
			for(int i = 1; i < _elementsVisibilityInstance._musculiTogglesList.Count; i++)
				_elementsVisibilityInstance._musculiTogglesList[i].gameObject.SetActive (true);

			ChangeLocalPositions (_elementsVisibilityInstance._nerviTogglesList, -muscliDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, -muscliDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, -muscliDistance);
		}
	}

	public void SetNervi () {

		if (!_isNERVIToggle.isOn) {
			for(int i = 1; i < _elementsVisibilityInstance._nerviTogglesList.Count; i++)
				_elementsVisibilityInstance._nerviTogglesList[i].gameObject.SetActive (false);

			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, nerviDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, nerviDistance);
		} else {
			for(int i = 1; i < _elementsVisibilityInstance._nerviTogglesList.Count; i++)
				_elementsVisibilityInstance._nerviTogglesList[i].gameObject.SetActive (true);

			ChangeLocalPositions (_elementsVisibilityInstance._bulbusTogglesList, -nerviDistance);
			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, -nerviDistance);
		}
	}

	public void SetBulbi () {

		if (!_isBULBUSOCULIToggle.isOn) {
			for(int i = 1; i < _elementsVisibilityInstance._bulbusTogglesList.Count; i++)
				_elementsVisibilityInstance._bulbusTogglesList[i].gameObject.SetActive (false);

			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, bulbusDistance);
		} else {
			for(int i = 1; i < _elementsVisibilityInstance._bulbusTogglesList.Count; i++)
				_elementsVisibilityInstance._bulbusTogglesList[i].gameObject.SetActive (true);

			ChangeLocalPositions (_elementsVisibilityInstance._otherTogglesList, -bulbusDistance);
		}
	}

	public void SetOther () {

		if (!_isOTHERToggle.isOn) {
			for(int i = 1; i < _elementsVisibilityInstance._otherTogglesList.Count; i++)
				_elementsVisibilityInstance._otherTogglesList[i].gameObject.SetActive (false);
		} else {
			for(int i = 1; i < _elementsVisibilityInstance._otherTogglesList.Count; i++)
				_elementsVisibilityInstance._otherTogglesList[i].gameObject.SetActive (true);
		}

	}

}