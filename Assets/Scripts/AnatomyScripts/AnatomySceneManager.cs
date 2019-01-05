using System.Collections;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

namespace EyeSimulator.Anatomy {

	public class AnatomySceneManager : MonoBehaviour {

		[SerializeField] private GameObject eyeSocketPrefab;
		[SerializeField] private GameObject eyeSocketHalfPrefab;

		[SerializeField] private GameObject emptyGameObject;

		private GameObject eyeSocketModel;
		private GameObject eyeSocketHalfModel;
		private GameManager gameManager;

		private EyeElements eyeElements = new EyeElements ();
		private EyeCategories eyeCategories = new EyeCategories ();

		private Vector3 startingRotation = new Vector3(0, 210f, 0);

		private static AnatomySceneManager instance;

		#region Properties
		public EyeElements EyeElements {
			get { return eyeElements; }
		}

		public EyeCategories EyeCategories {
			get { return eyeCategories; }
		}

		public GameObject EyeSocketModel {
			get { return eyeSocketModel; }
		}

		public GameObject EyeSocketHalfModel {
			get { return eyeSocketHalfModel; }
		}

		public GameObject EmptyGameObject {
			get { return emptyGameObject; }
		}

		public Vector3 StartingRotation {
			get { return startingRotation; }
		}
			
		public static AnatomySceneManager Instance {
			get {
				if (instance == null)
					instance = FindObjectOfType<AnatomySceneManager> ();
				return instance;
			}
		}
		#endregion

		#region MonoBehavoiur Methods
		void Awake() {
			PrepareModels ();

			LoadFromXMLS ();
			eyeElements.SetEyeElements ();

		}

		void Start () {
			gameManager = FindObjectOfType<GameManager>();
		}

		void Update () {

			// going back to main menu
			if (Input.GetKeyUp (KeyCode.Escape)) {
				gameManager.LoadScene("main");
			}

		}
		#endregion

		#region Private Methods
		private void PrepareModels () {
			eyeSocketModel = InstantiateModel (eyeSocketPrefab, "EyeSocket");
			eyeSocketHalfModel = InstantiateModel (eyeSocketHalfPrefab, "EyeSocketHalf");
		}

		private GameObject InstantiateModel (GameObject prefab, string name) {
			GameObject model = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
			model.SetActive (true);
			model.name = name;
			model.transform.SetParent (transform, true);
			model.transform.position = Vector3.zero;
			model.transform.localScale = Vector3.one * 30f;
			model.transform.Rotate (startingRotation);

			return model;
		}

		private void LoadFromXMLS () {

			Type[] eyeElementsTypes = { typeof(Element) };
			XmlSerializer eyeElementsSerializer = new XmlSerializer (typeof(EyeElements), eyeElementsTypes);
			TextReader eyeElementsTextReader = new StreamReader (Application.streamingAssetsPath + "/XMLS/EyeElements.xml");
			eyeElements = (EyeElements)eyeElementsSerializer.Deserialize (eyeElementsTextReader);
			eyeElementsTextReader.Close ();

			Type[] eyeCategoriesTypes = { typeof(Category) };
			XmlSerializer eyeCategoriesSerializer = new XmlSerializer (typeof(EyeCategories), eyeCategoriesTypes);
			TextReader eyeCategoriesTextReader = new StreamReader (Application.streamingAssetsPath + "/XMLS/EyeCategories.xml");
			eyeCategories = (EyeCategories)eyeCategoriesSerializer.Deserialize (eyeCategoriesTextReader);
			eyeCategoriesTextReader.Close ();

		}
		#endregion

		#region Public Methods
		public GameObject GetPart(bool wholeModel, string name) {

			if (wholeModel)
				return GetPartScript.GetPart(eyeSocketModel, name);
			else
				return GetPartScript.GetPart(eyeSocketHalfModel, name);

		}

		public void ShowWholeModel() {
			eyeSocketModel.SetActive (true);
			eyeSocketHalfModel.SetActive (false);
		}

		public void ShowHalfModel () {
			eyeSocketModel.SetActive (false);
			eyeSocketHalfModel.SetActive (true);
		}
		#endregion

	}

}