using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.IO;
using EyeSimulator.Disorders.Data;

namespace EyeSimulator.Disorders {

	public class DisordersSceneManager : MonoBehaviour {

		[SerializeField] private GameObject models;
		private GameManager gm;

		private DisordersElements disordersElements = new DisordersElements ();
		private DisordersCategories disordersCategories = new DisordersCategories ();
		private DisordersFragments disordersFragments = new DisordersFragments ();

		private static DisordersSceneManager instance;

		#region Properties
		public static DisordersSceneManager Instance {
			get {
				if (!instance) {
					instance = FindObjectOfType<DisordersSceneManager> ();

					if (!instance)
						Debug.LogError ("Did not find DisordersSceneManager script on GameObject in scene");
				}

				return instance;
			}
		}

		public DisordersElements DisordersElements {
			get { return disordersElements; }
		}

		public DisordersCategories DisordersCategories {
			get { return disordersCategories; }
		}
		#endregion

		#region MonoBehaviour methods
		void Awake () {
			LoadFromXMLFiles ();
		}

		void Start () {
			gm = FindObjectOfType<GameManager>();
		}
			
		void Update () {

			// going back to menu
			if (Input.GetKeyUp (KeyCode.Escape)) {
				gm.LoadScene("main");
			}

		}
		#endregion

		private void LoadFromXMLFiles() {
			Type[] disordersElementsTypes = { typeof(DisordersElement) };
			XmlSerializer disordersElementsSerializer = new XmlSerializer (typeof(DisordersElements), disordersElementsTypes);
			TextReader disordersElementsTextReader = new StreamReader (Application.streamingAssetsPath + "/XML/DisordersElements.xml");
			disordersElements = (DisordersElements)disordersElementsSerializer.Deserialize (disordersElementsTextReader);
			disordersElementsTextReader.Close ();

			Type[] disordersCategoriesTypes = { typeof(DisordersCategory) };
			XmlSerializer disordersCategoriesSerializer = new XmlSerializer (typeof(DisordersCategories), disordersCategoriesTypes);
			TextReader disordersCategoriesTextReader = new StreamReader (Application.streamingAssetsPath + "/XML/DisordersCategories.xml");
			disordersCategories = (DisordersCategories)disordersCategoriesSerializer.Deserialize (disordersCategoriesTextReader);
			disordersCategoriesTextReader.Close ();

			Type[] disordersFragmentsTypes = { typeof(DisordersFragment) };
			XmlSerializer disordersFragmentsSerializer = new XmlSerializer (typeof(DisordersFragments), disordersFragmentsTypes);
			TextReader disordersFragmentsTextReader = new StreamReader (Application.streamingAssetsPath + "/XML/DisordersFragments.xml");
			disordersFragments = (DisordersFragments)disordersFragmentsSerializer.Deserialize (disordersFragmentsTextReader);
			disordersFragmentsTextReader.Close ();
		}
			
		public GameObject GetDisorderModel(string name) {
			
			return GetPartScript.GetPart (models, name);

		}

		public string GetDisorderFragment(string fragmentName) {

			foreach (var f in disordersFragments.DisordersFragmentsList) {
				if (fragmentName.StartsWith(f.Name))
					return f.NamePolish;
			}

			return string.Empty;
		}

	}

}