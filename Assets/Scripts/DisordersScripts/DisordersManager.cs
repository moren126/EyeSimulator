using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EyeSimulator;

public class DisordersManager : MonoBehaviour {

	public Toggle _isMyopiaToggle, _isHyperopiaToggle, _isAstigmatismToggle;
	public Toggle _isCataractaToggle, _isHyphemaToggle, _isUveitisToggle, _isAblatioToggle;
	public Button _beforeButton, _afterButton, _sagitalButton, _transverseButton;
	public Text _infoText;

	private DisordersModelsData _disordersInstance;
	private DisordersTextManager _disordersTextInstance;
	private GameObject _activeModel;
	private GameManager _gm;
	private Image _picBefore;
	private List<Toggle> _togglesList = new List<Toggle>();
	private Vector3 _startPosition, _startAngle;
	private float _posYAfter, _posYBefore;
	private bool _infoState;


	IEnumerator MoveToPosition (Transform transform, Vector3 position, float timeToMove) {
		Vector3 currentPos = transform.localPosition;
		float t = 0.0f;

		while (t < 1) {
			t += Time.deltaTime / timeToMove;
			transform.localPosition = Vector3.Lerp (currentPos, position, t);
			yield return null;
		}
	}

	public void AfterCorrection () {
		Vector3 temp = new Vector3 (_picBefore.transform.localPosition.x, _posYAfter, _picBefore.transform.localPosition.z);
		IEnumerator coroutine = MoveToPosition(_picBefore.transform, temp, 0.5f);
		StartCoroutine(coroutine);

		_disordersInstance._picAfter.gameObject.SetActive(true);

		foreach (Toggle t in _togglesList) {
			if (t.isOn) {
				foreach (DisordersData d in _disordersInstance._disordersList) {
					if (d.toggleName == t.name) {
						foreach (GameObject g in d.partsBefore)
							g.SetActive (false);
						foreach (GameObject g in d.partsAfter)
							g.SetActive (true);
						break;
					}
				}
				break;
			}
		}	
	}

	public void BeforeCorrection () {
		Vector3 temp = new Vector3 (_picBefore.transform.localPosition.x, _posYBefore, _picBefore.transform.localPosition.z);
		IEnumerator coroutine = MoveToPosition(_picBefore.transform, temp, 0.5f);
		StartCoroutine(coroutine);

		_disordersInstance._picAfter.gameObject.SetActive (false);

		foreach (Toggle t in _togglesList) {
			if (t.isOn) {
				foreach (DisordersData d in _disordersInstance._disordersList) {
					if (d.toggleName == t.name) {
						foreach (GameObject g in d.partsBefore)
							g.SetActive (true);
						foreach (GameObject g in d.partsAfter)
							g.SetActive (false);
						break;
					}
				}
				break;
			}
		}

	}

	public void SagitalPlane () {
		foreach (GameObject g in _disordersInstance._astigTransverse)
			g.SetActive (false);
		foreach (GameObject g in _disordersInstance._astigSagital)
			g.SetActive (true);
	}
		
	public void TransversePlane () {
		foreach (GameObject g in _disordersInstance._astigSagital)
			g.SetActive (false);
		foreach (GameObject g in _disordersInstance._astigTransverse)
			g.SetActive (true);
	}

	void CheckToggle (GameObject model, Toggle partToggle) {
		partToggle.onValueChanged.AddListener ((bool on) => {
			model.SetActive(on);

			if (on == true) {

				// pozycja wyjsciowa modelu
				model.transform.position = new Vector3 (_startPosition.x, _startPosition.y, _startPosition.z);
				model.transform.eulerAngles = new Vector3 (_startAngle.x, _startAngle.y, _startAngle.z);

				// max. jeden toggle moze byc aktywny
				foreach (Toggle t in _togglesList) {
					if (t != partToggle)
						t.isOn = false;
				}
					
				foreach (DisordersData d in _disordersInstance._disordersList) {
					if (d.toggleName == partToggle.name) {
						_startPosition = d.position;
						_startAngle = d.angle;
						_picBefore = d.image;
						_disordersTextInstance.ShowDescription(d.name);

						foreach (GameObject g in d.partsBefore)
							g.SetActive(true);
						foreach (GameObject g in d.partsAfter)
							g.SetActive(false);

						if (d.hasButtonsBA) {
							_beforeButton.gameObject.SetActive(true); 
							_afterButton.gameObject.SetActive(true); 
						} else {
							_beforeButton.gameObject.SetActive(false); 
							_afterButton.gameObject.SetActive(false); 
							_disordersInstance._picAfter.gameObject.SetActive (false);
						}

						if (d.hasButtonsP) {
							_sagitalButton.gameObject.SetActive(true); 
							_transverseButton.gameObject.SetActive(true);
							SagitalPlane ();
						} else {
							_sagitalButton.gameObject.SetActive(false); 
							_transverseButton.gameObject.SetActive(false);
						}

						break;
					}
				}


				if (_picBefore)
					_picBefore.gameObject.SetActive(true);

			}
			else if (on == false) {

				if (_picBefore)
					_picBefore.gameObject.SetActive(false);
				if (_disordersInstance._picAfter)
					_disordersInstance._picAfter.gameObject.SetActive (false);
				_disordersTextInstance.ShowDescription("clear");


				foreach (DisordersData d in _disordersInstance._disordersList) {
					if (d.toggleName == partToggle.name) {

						if (d.hasButtonsBA) {
							_beforeButton.gameObject.SetActive(false); 
							_afterButton.gameObject.SetActive(false); 
							_picBefore.transform.localPosition = new Vector3 (_picBefore.transform.localPosition.x, _posYBefore, _picBefore.transform.localPosition.z);
						}

						if (d.hasButtonsP) {
							_sagitalButton.gameObject.SetActive(false); 
							_transverseButton.gameObject.SetActive(false);
						}

						break;
					}
				}
			}

		});
	}

	void SetTogglesList () {
		_togglesList.Add (_isMyopiaToggle);
		_togglesList.Add (_isHyperopiaToggle);
		_togglesList.Add (_isAstigmatismToggle);
		_togglesList.Add (_isCataractaToggle);
		_togglesList.Add (_isHyphemaToggle);
		_togglesList.Add (_isUveitisToggle);
		_togglesList.Add (_isAblatioToggle);
	}

	void Awake () {
		_beforeButton.gameObject.SetActive (false); 
		_afterButton.gameObject.SetActive (false); 
		_sagitalButton.gameObject.SetActive (false); 
		_transverseButton.gameObject.SetActive (false);
	}

	void Start () {
		GameObject _models = GameObject.Find ("Models");
		_disordersInstance = _models.GetComponent<DisordersModelsData> ();
		_disordersTextInstance = _models.GetComponent<DisordersTextManager> ();

		GameObject _cameraObject = GameObject.Find ("Main Camera");
		_gm = _cameraObject.GetComponent<GameManager>();

		SetTogglesList ();

		_posYAfter = 155.0f;
		_posYBefore = 0.0f;

		_startPosition = new Vector3(0, 0, 0);
		_startAngle = new Vector3(0, 0, 0);

		_infoState = true;
	}
	

	void Update () {
		CheckToggle (_disordersInstance._myopiaEye, _isMyopiaToggle); 
		CheckToggle (_disordersInstance._hyperopiaEye, _isHyperopiaToggle); 
		CheckToggle (_disordersInstance._astigEye, _isAstigmatismToggle);
		CheckToggle (_disordersInstance._cataractaEye, _isCataractaToggle);
		CheckToggle (_disordersInstance._hyphemaEye, _isHyphemaToggle);
		CheckToggle (_disordersInstance._uveitisEye, _isUveitisToggle);
		CheckToggle (_disordersInstance._ablatioEye, _isAblatioToggle);
			

		foreach (GameObject g in _disordersInstance._models) {
			if (g.activeSelf) {
				_activeModel = g;
				break;
			} else
				_activeModel = null;
		}

		if (_activeModel) {
			Quaternion rotateUp = Quaternion.AngleAxis(Input.GetAxis ("Horizontal") * (-1), Vector3.up);
			_activeModel.transform.rotation = _activeModel.transform.rotation * rotateUp;
			Quaternion rotateBack = Quaternion.AngleAxis(Input.GetAxis ("Vertical") * 1, Vector3.back);
			_activeModel.transform.rotation = _activeModel.transform.rotation * rotateBack;
		}

		// wyjscie do menu
		if (Input.GetKeyUp (KeyCode.Escape)) {
			_gm.LoadScene("main");
		}

	}

	public void InfoOn() {
		if (!_infoState)
			_infoText.gameObject.SetActive (true);
		else if (_infoState)
			_infoText.gameObject.SetActive (false);

		_infoState = !_infoState;
	}
}
