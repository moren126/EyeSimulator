using UnityEngine;
using System.Collections;

public class AssignModels : MonoBehaviour {

	public GameObject _whole;
	public GameObject _corpusVitreumH, _retinaH, _lensH, _choroideaH, _corpusCiliareH, _irisH, _scleraH, _corneaH;
	public GameObject _mObliquusInferior, _mObliquusSuperior, _mRectusInferior, _mRectusLateralis, _mRectusMedialis, _mRectusSuperior;
	public GameObject _nAbducens, _nOculomotorius, _nOpticus, _nTrochlearis; 
	public GameObject _osEthmoidale, _osFrontale, _osLacrimale, _osMaxilla, _osPalatinum, _osSphenoidale, _osZygomaticum; 
	public GameObject _othAnulus, _othTrochlea;

	void Start () {
		_corpusVitreumH.SetActive (false); 
		_retinaH.SetActive (false);
		_lensH.SetActive (false); 
		_choroideaH.SetActive (false); 
		_corpusCiliareH.SetActive (false); 
		_irisH.SetActive (false); 
		_scleraH.SetActive (false);
		_corneaH.SetActive (false);

		_mObliquusInferior.SetActive (false);
		_mObliquusSuperior.SetActive (false); 
		_mRectusInferior.SetActive (false); 
		_mRectusLateralis.SetActive (false); 
		_mRectusMedialis.SetActive (false); 
		_mRectusSuperior.SetActive (false);

		_nAbducens.SetActive (false); 
		_nOculomotorius.SetActive (false); 
		_nOpticus.SetActive (false);
		_nTrochlearis.SetActive (false);

		_osEthmoidale.SetActive (false); 
		_osFrontale.SetActive (false);
		_osLacrimale.SetActive (false);
		_osMaxilla.SetActive (false); 
		_osPalatinum.SetActive (false); 
		_osSphenoidale.SetActive (false); 
		_osZygomaticum.SetActive (false); 

		_othAnulus.SetActive (false); 
		_othTrochlea.SetActive (false);
	}
	

	void Update () {
	
	}
}
