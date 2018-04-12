using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelManager : MonoBehaviour {

	public GameObject someName;
	public GameObject _orbit;
	public GameObject _halfOrbit;

	[HideInInspector]
	public GameObject _corpusVitreum, _retina, _lens, _choroidea, _corpusCiliare, _iris, _sclera, _cornea;
	[HideInInspector]
	public GameObject _corpusVitreumH, _retinaH, _lensH, _choroideaH, _corpusCiliareH, _irisH, _scleraH, _corneaH;

	[HideInInspector]
	public GameObject _mObliquusInferior, _mObliquusSuperior, _mRectusInferior, _mRectusLateralis, _mRectusMedialis, _mRectusSuperior;
	[HideInInspector]
	public GameObject _mObliquusInferiorH, _mObliquusSuperiorH, _mRectusInferiorH, _mRectusLateralisH, _mRectusMedialisH, _mRectusSuperiorH;

	[HideInInspector]
	public GameObject _nAbducens, _nOculomotorius, _nOpticus, _nTrochlearis; 
	[HideInInspector]
	public GameObject _nAbducensH, _nOculomotoriusH, _nOpticusH, _nTrochlearisH; 

	[HideInInspector]
	public GameObject _osEthmoidale, _osFrontale, _osLacrimale, _osMaxilla, _osPalatinum, _osSphenoidale, _osZygomaticum; 
	[HideInInspector]
	public GameObject _osEthmoidaleH, _osFrontaleH, _osLacrimaleH, _osMaxillaH, _osPalatinumH, _osSphenoidaleH, _osZygomaticumH; 

	[HideInInspector] 
	public GameObject _othAnulus, _othTrochlea, _othAnulusH, _othTrochleaH;

	[HideInInspector]
	public GameObject _pinBackPole, _pinCanalis, _pinEquator, _pinFOInferior, _pinFOSuperior, _pinFrontPole;
	[HideInInspector]
	public GameObject _pinInferiorWall, _pinLateralWall, _pinMedialWall, _pinSuperiorWall;
	[HideInInspector]
	public GameObject _pinBackPoleH, _pinCanalisH, _pinEquatorH, _pinFOInferiorH, _pinFOSuperiorH, _pinFrontPoleH;
	[HideInInspector]
	public GameObject _pinInferiorWallH, _pinLateralWallH, _pinMedialWallH, _pinSuperiorWallH;

	public List<ModelData> _modelList = new List<ModelData> ();

	private ModelData _corpusVitreumObj, _retinaObj, _lensObj, _choroideaObj, _corpusCiliareObj, _irisObj, _scleraObj, _corneaObj;
	private ModelData _mObliquusInferiorObj, _mObliquusSuperiorObj, _mRectusInferiorObj, _mRectusLateralisObj, _mRectusMedialisObj, _mRectusSuperiorObj;
	private ModelData _nAbducensObj, _nOculomotoriusObj, _nOpticusObj, _nTrochlearisObj;
	private ModelData _osEthmoidaleObj, _osFrontaleObj, _osLacrimaleObj, _osMaxillaObj, _osPalatinumObj, _osSphenoidaleObj, _osZygomaticumObj;
	private ModelData _othAnulusObj, _othTrochleaObj;


	GameObject createNonExistent (string name) {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3 (100.0f, 100.0f, 100.0f);
		cube.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
		cube.name = name;
		Renderer cubeRenderer = cube.GetComponent<Renderer> ();
		cubeRenderer.enabled = false;
		return cube;
	}
		
	void AssignChildren(GameObject model) {

		foreach (Transform child in model.transform) {

			// GALKA - 8 ELEMENTOW

			// jesli cialo szkliste
			if (child.name == "bCorpusVitreum") {
				if (model.name == "Orbit")
					_corpusVitreum = child.gameObject;
				else if (model.name == "HalfOrbit")
					_corpusVitreumH = child.gameObject;
			}

			// jesli siatkowka
			else if (child.name == "bRetina") {
				if (model.name == "Orbit")
					_retina = child.gameObject;
				else if (model.name == "HalfOrbit")
					_retinaH = child.gameObject;
			}

			// jesli soczewka
			else if (child.name == "bLens") {
				if (model.name == "Orbit")
					_lens = child.gameObject;
				else if (model.name == "HalfOrbit")
					_lensH = child.gameObject;
			}

			// jesli naczyniowka
			else if (child.name == "bChoroidea") {
				if (model.name == "Orbit")
					_choroidea = child.gameObject;
				else if (model.name == "HalfOrbit")
					_choroideaH = child.gameObject;
			}

			// jesli cialo rzeskowe
			else if (child.name == "bCorpusCiliare") {
				if (model.name == "Orbit")
					_corpusCiliare = child.gameObject;
				else if (model.name == "HalfOrbit")
					_corpusCiliareH = child.gameObject;
			}

			// jesli teczowka
			else if (child.name == "bIris") {
				if (model.name == "Orbit")
					_iris = child.gameObject;
				else if (model.name == "HalfOrbit")
					_irisH = child.gameObject;
			}

			// jesli twardowka
			else if (child.name == "bSclera") {
				if (model.name == "Orbit")
					_sclera = child.gameObject;
				else if (model.name == "HalfOrbit")
					_scleraH = child.gameObject;
			}

			// jesli rogowka
			else if (child.name == "bCornea") {
				if (model.name == "Orbit")
					_cornea = child.gameObject;
				else if (model.name == "HalfOrbit")
					_corneaH = child.gameObject;
			}
				

			// MIESNIE - 6 ELEMENTOW

			// jesli m. skosny dolny
			else if (child.name == "mObliquusInferior") {
				if (model.name == "Orbit")
					_mObliquusInferior = child.gameObject;
				else if (model.name == "HalfOrbit")
					_mObliquusInferiorH = child.gameObject;
			}

			// jesli m. skosny gorny
			else if (child.name == "mObliquusSuperior") {
				if (model.name == "Orbit")
					_mObliquusSuperior = child.gameObject;
				else if (model.name == "HalfOrbit")
					_mObliquusSuperiorH = child.gameObject;
			}

			// jesli m. prosty dolny
			else if (child.name == "mRectusInferior") {
				if (model.name == "Orbit")
					_mRectusInferior = child.gameObject;
				else if (model.name == "HalfOrbit")
					_mRectusInferiorH = child.gameObject;
			}

			// jesli m. prosty boczny
			else if (child.name == "mRectusLateralis") {
				if (model.name == "Orbit")
					_mRectusLateralis = child.gameObject;
				else if (model.name == "HalfOrbit")
					_mRectusLateralisH = child.gameObject;
			}

			// jesli m. prosty przyśrodkowy
			else if (child.name == "mRectusMedialis") {
				if (model.name == "Orbit") {
					_mRectusMedialis = child.gameObject;
					_mRectusMedialisH = createNonExistent ("HNon");
				}
			}

			// jesli m. prosty gorny
			else if (child.name == "mRectusSuperior") {
				if (model.name == "Orbit")
					_mRectusSuperior = child.gameObject;
				else if (model.name == "HalfOrbit")
					_mRectusSuperiorH = child.gameObject;
			}


			// NERWY - 4 ELEMENTY

			// jesli n. odwodzacy
			else if (child.name == "nAbducens") {
				if (model.name == "Orbit")
					_nAbducens = child.gameObject;
				else if (model.name == "HalfOrbit")
					_nAbducensH = child.gameObject;
			}

			// jesli n. okoruchowy
			else if (child.name == "nOculomotorius") {
				if (model.name == "Orbit")
					_nOculomotorius = child.gameObject;
				else if (model.name == "HalfOrbit")
					_nOculomotoriusH = child.gameObject;
			}

			// jesli n. wzrokowy
			else if (child.name == "nOpticus") {
				if (model.name == "Orbit")
					_nOpticus = child.gameObject;
				else if (model.name == "HalfOrbit")
					_nOpticusH = child.gameObject;
			}

			// jesli n. bloczkowy
			else if (child.name == "nTrochlearis") {
				if (model.name == "Orbit") {
					_nTrochlearis = child.gameObject;
					_nTrochlearisH = createNonExistent ("HNon");
				}
			}


			// KOSCI - 7 ELEMENTOW

			// jesli k. sitowa
			else if (child.name == "osEthmoidale") {
				if (model.name == "Orbit") {
					_osEthmoidale = child.gameObject;
					_osEthmoidaleH = createNonExistent ("HNon");
				}
			}

			// jesli k. czolowa
			else if (child.name == "osFrontale") {
				if (model.name == "Orbit")
					_osFrontale = child.gameObject;
				else if (model.name == "HalfOrbit")
					_osFrontaleH = child.gameObject;
			}

			// jesli k. lzowa
			else if (child.name == "osLacrimale") {
				if (model.name == "Orbit") {
					_osLacrimale = child.gameObject;
					_osLacrimaleH = createNonExistent ("HNon");
				}
			}

			// jesli szczeka
			else if (child.name == "osMaxilla") {
				if (model.name == "Orbit")
					_osMaxilla = child.gameObject;
				else if (model.name == "HalfOrbit")
					_osMaxillaH = child.gameObject;
			}

			// jesli k. podniebienna
			else if (child.name == "osPalatinum") {
				if (model.name == "Orbit") {
					_osPalatinum = child.gameObject;
					_osPalatinumH = createNonExistent ("HNon");
				}
			}

			// jesli k. klinowa
			else if (child.name == "osSphenoidale") {
				if (model.name == "Orbit")
					_osSphenoidale = child.gameObject;
				else if (model.name == "HalfOrbit")
					_osSphenoidaleH = child.gameObject;
			}

			// jesli k. jarzmowa
			else if (child.name == "osZygomaticum") {
				if (model.name == "Orbit")
					_osZygomaticum = child.gameObject;
				else if (model.name == "HalfOrbit")
					_osZygomaticumH = child.gameObject;
			}


			//INNE

			// jesli pierscien sciegnisty wspolny
			else if (child.name == "othAnulusTendineusCommunis") {
				if (model.name == "Orbit") {
					_othAnulus = child.gameObject;
					_othAnulusH = createNonExistent ("HNon");
				}
			}

			// jesli bloczek
			else if (child.name == "othTrochlea") {
				if (model.name == "Orbit") {
					_othTrochlea = child.gameObject;
					_othTrochleaH = createNonExistent ("HNon");
				}
			}

			// jesli pin do bieguna tylnego
			else if (child.name == "pinBackPole") {
				if (model.name == "Orbit")
					_pinBackPole = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinBackPoleH = child.gameObject;
			}

			// jesli pin do kanalu wzrokowego
			else if (child.name == "pinCanalisOpticus") {
				if (model.name == "Orbit") {
					_pinCanalis = child.gameObject;
					_pinCanalisH = createNonExistent ("HNon");
				}
			}

			// jesli pin do rownika
			else if (child.name == "pinEquator") {
				if (model.name == "Orbit")
					_pinEquator = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinEquatorH = child.gameObject;
			}

			// jesli pin do szczeliny oczodolowej dolnej
			else if (child.name == "pinFissuraOrbitalisInferior") {
				if (model.name == "Orbit")
					_pinFOInferior = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinFOInferiorH = child.gameObject;
			}

			// jesli pin do szczeliny oczodolowej gornej
			else if (child.name == "pinFissuraOrbitalisSuperior") {
				if (model.name == "Orbit") {
					_pinFOSuperior = child.gameObject;
					_pinFOInferiorH = createNonExistent ("HNon");
				}
			}
				
			// jesli pin do bieguna przedniego
			else if (child.name == "pinFrontPole") {
				if (model.name == "Orbit")
					_pinFrontPole = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinFrontPoleH = child.gameObject;
			}

			// jesli pin do sciany gornej
			else if (child.name == "pinInferiorWall") {
				if (model.name == "Orbit")
					_pinInferiorWall = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinInferiorWallH = child.gameObject;
			}
			// jesli pin do sciany bocznej
			else if (child.name == "pinLateralWall") {
				if (model.name == "Orbit")
					_pinLateralWall = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinLateralWallH = child.gameObject;
			}
			// jesli pin do sciany przsrodkowej
			else if (child.name == "pinMedialWall") {
				if (model.name == "Orbit") {
					_pinMedialWall = child.gameObject;
					_pinMedialWallH = createNonExistent ("HNon");
				}
			}
			// jesli pin do sciany dolnej
			else if (child.name == "pinSuperiorWall") {
				if (model.name == "Orbit")
					_pinSuperiorWall = child.gameObject;
				else if (model.name == "HalfOrbit")
					_pinSuperiorWallH = child.gameObject;
			}

		}
	}

	void MakeModelObjects() {
		_corpusVitreumObj = new ModelData ("bCorpusVitreum", "corpusVitreumToggle", _corpusVitreum, _corpusVitreumH, _corpusVitreum.GetComponent<Renderer>().material.color);
		_retinaObj = new ModelData ("bRetina", "retinaToggle", _retina, _retinaH, _retina.GetComponent<Renderer> ().material.color);
		_lensObj = new ModelData ("bLens", "lensToggle", _lens, _lensH, _lens.GetComponent<Renderer> ().material.color);
		_choroideaObj = new ModelData ("bChoroidea", "choroideaToggle", _choroidea, _choroideaH, _choroidea.GetComponent<Renderer> ().material.color);
		_corpusCiliareObj = new ModelData ("bCorpusCiliare", "corpusCiliareToggle", _corpusCiliare, _corpusCiliareH, _corpusCiliare.GetComponent<Renderer> ().material.color);
		_irisObj = new ModelData ("bIris", "irisToggle", _iris, _irisH, _iris.GetComponent<Renderer> ().material.color);
		_scleraObj = new ModelData ("bSclera", "scleraToggle", _sclera, _scleraH, _sclera.GetComponent<Renderer> ().material.color);
		_corneaObj = new ModelData ("bCornea", "corneaToggle", _cornea, _corneaH, _cornea.GetComponent<Renderer> ().material.color);

		_mObliquusInferiorObj = new ModelData ("mObliquusInferior", "mObliquusInferiorToggle", _mObliquusInferior, _mObliquusInferiorH, _mObliquusInferior.GetComponent<Renderer> ().material.color);
		_mObliquusSuperiorObj = new ModelData ("mObliquusSuperior", "mObliquusSuperiorToggle", _mObliquusSuperior, _mObliquusSuperiorH, _mObliquusSuperior.GetComponent<Renderer> ().material.color);
		_mRectusInferiorObj = new ModelData ("mRectusInferior", "mRectusInferiorToggle", _mRectusInferior, _mRectusInferiorH, _mRectusInferior.GetComponent<Renderer> ().material.color);
		_mRectusLateralisObj = new ModelData ("mRectusLateralis", "mRectusLateralisToggle", _mRectusLateralis, _mRectusLateralisH, _mRectusLateralis.GetComponent<Renderer> ().material.color);
		_mRectusMedialisObj = new ModelData ("mRectusMedialis", "mRectusMedialisToggle", _mRectusMedialis, _mRectusMedialisH, _mRectusMedialis.GetComponent<Renderer> ().material.color);
		_mRectusSuperiorObj = new ModelData ("mRectusSuperior", "mRectusSuperiorToggle", _mRectusSuperior, _mRectusSuperiorH, _mRectusSuperior.GetComponent<Renderer> ().material.color);

		_nAbducensObj = new ModelData ("nAbducens", "nAbducensToggle", _nAbducens, _nAbducensH, _nAbducens.GetComponent<Renderer> ().material.color);
		_nOculomotoriusObj = new ModelData ("nOculomotorius", "nOculomotoriusToggle", _nOculomotorius, _nOculomotoriusH, _nOculomotorius.GetComponent<Renderer> ().material.color);
		_nOpticusObj = new ModelData ("nOpticus", "nOpticusToggle", _nOpticus, _nOpticusH, _nOpticus.GetComponent<Renderer> ().material.color);
		_nTrochlearisObj = new ModelData ("nTrochlearis", "nTrochlearisToggle", _nTrochlearis, _nTrochlearisH, _nTrochlearis.GetComponent<Renderer> ().material.color);

		_osEthmoidaleObj = new ModelData ("osEthmoidale", "osEthmoidaleToggle", _osEthmoidale, _osEthmoidaleH, _osEthmoidale.GetComponent<Renderer> ().material.color);
		_osFrontaleObj = new ModelData ("osFrontale", "osFrontaleToggle", _osFrontale, _osFrontaleH, _osFrontale.GetComponent<Renderer> ().material.color);
		_osLacrimaleObj = new ModelData ("osLacrimale", "osLacrimaleToggle", _osLacrimale, _osLacrimaleH, _osLacrimale.GetComponent<Renderer> ().material.color);
		_osMaxillaObj = new ModelData ("osMaxilla", "osMaxillaToggle", _osMaxilla, _osMaxillaH, _osMaxilla.GetComponent<Renderer> ().material.color);
		_osPalatinumObj = new ModelData ("osPalatinum", "osPalatinumToggle", _osPalatinum, _osPalatinumH, _osPalatinum.GetComponent<Renderer> ().material.color);
		_osSphenoidaleObj = new ModelData ("osSphenoidale", "osSphenoidaleToggle", _osSphenoidale, _osSphenoidaleH, _osSphenoidale.GetComponent<Renderer> ().material.color);
		_osZygomaticumObj = new ModelData ("osZygomaticum", "osZygomaticumToggle", _osZygomaticum, _osZygomaticumH, _osZygomaticum.GetComponent<Renderer> ().material.color);

		_othAnulusObj = new ModelData ("othAnulusTendineusCommunis", "anulusToggle", _othAnulus, _othAnulusH, _othAnulus.GetComponent<Renderer> ().material.color);
		_othTrochleaObj = new ModelData ("othTrochlea", "trochleaToggle", _othTrochlea, _othTrochleaH, _othTrochlea.GetComponent<Renderer> ().material.color);
	}

	void SetModelList () {
		MakeModelObjects ();

		_modelList.AddRange (new ModelData[] {_corpusVitreumObj, _retinaObj, _lensObj, _choroideaObj, _corpusCiliareObj, _irisObj, _scleraObj, _corneaObj});
		_modelList.AddRange (new ModelData[] {_mObliquusInferiorObj, _mObliquusSuperiorObj, _mRectusInferiorObj, _mRectusLateralisObj, _mRectusMedialisObj, _mRectusSuperiorObj});
		_modelList.AddRange (new ModelData[] {_nAbducensObj, _nOculomotoriusObj, _nOpticusObj, _nTrochlearisObj});
		_modelList.AddRange (new ModelData[] {_osEthmoidaleObj, _osFrontaleObj, _osLacrimaleObj, _osMaxillaObj, _osPalatinumObj, _osSphenoidaleObj, _osZygomaticumObj});
		_modelList.AddRange (new ModelData[] {_othAnulusObj, _othTrochleaObj});
	}

	void Awake () {
		AssignChildren (_orbit);
		AssignChildren (_halfOrbit);
		SetModelList ();
	}

	void Update () {
	}
}
