﻿using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.IO;
using EyeSimulator.Anatomy.Data;

namespace EyeSimulator.Anatomy {

	public class AnatomyPinsManager : MonoBehaviour {

		private List <GameObject> pinsModelList = new List<GameObject> ();

		private AnatomyModes mode;

		private Pins pins;

		public Pins Pins {
			get { return pins; }
		}
			
		#region MonoBehaviour Methods
		void Start () {
			mode = FindObjectOfType<AnatomyModes> ();

			LoadFromXML ();
			SetPins ();
		}
		#endregion

		#region Private Methods
		private void LoadFromXML () {
			Type[] types = { typeof(Pin) };
			XmlSerializer serializer = new XmlSerializer (typeof(Pins), types);
			TextReader textReader = new StreamReader (Application.streamingAssetsPath + "/XML/Pins.xml");
			pins = (Pins)serializer.Deserialize (textReader);
			textReader.Close ();
		}

		private void SetPins () {

			foreach (var pin in pins.PinsList) {
				pinsModelList.Add (AnatomySceneManager.Instance.GetPart (true, pin.Name));

				pinsModelList.Add(AnatomySceneManager.Instance.GetPart (false, pin.Name));
			}

		}
		#endregion

		#region Public Methods
		public void PinsOn () {

			if (!mode.PinsMode)
				mode.PinsMode = true;
			else
				mode.PinsMode = false;

			foreach (var item in pinsModelList)
				item.SetActive (mode.PinsMode);
		}
		#endregion

	}

}