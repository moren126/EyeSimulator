using UnityEngine;
using System.Collections.Generic;
using EyeSimulator.Anatomy.Data;

namespace EyeSimulator {

	public class ButtonsManager : MonoBehaviour {

		[SerializeField] private GameObject infoText;

		private GameManager gm;
		private bool infoOn;

		protected virtual void Start () {
			gm = FindObjectOfType<GameManager> ();
			infoOn = true;
		}

		#region Public Methods
		public void HelpTextOn() {
			if (!infoOn)
				infoText.SetActive (true);
			else if (infoOn)
				infoText.SetActive (false);
				
			infoOn = !infoOn;
		}
			
		public void BackToMenu () {
			ElementsVisibility.ClearAllElements ();
			gm.LoadScene("main");
		}
		#endregion

	}
		
}