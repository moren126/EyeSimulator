using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EyeSimulator.Disorders.UI;

namespace EyeSimulator.Disorders {

	public class DisordersButtonsManager : ButtonsManager {

		[SerializeField] private Image picBefore;
		[SerializeField] private Image picAfter;

		private DisordersUIManager disordersUIManager;
		private Sprite picBeforeReal;

		private float posYBefore = 70f;
		private float posYAfter = 210f;

		private bool wasBeforeToggle = false;
		private bool wasAfterToggle = false;
		private bool wasSagitalPalneToggle = false;
		private bool wasTransversePlaneToggle = false;

		private static DisordersButtonsManager instance;

		public static DisordersButtonsManager Instance {
			get {
				if (!instance) {
					instance = FindObjectOfType<DisordersButtonsManager> ();
				
					if (!instance)
						Debug.LogError ("Did not find ButtonsDisorderManager script on GameObject in scene.");
				}

				return instance;
			}
		}


		protected override void Start () {
			base.Start ();

			picBeforeReal = picBefore.sprite; 
			disordersUIManager = FindObjectOfType<DisordersUIManager> ();
		}

		#region Private Methods
		private IEnumerator MoveToPosition (Transform transform, Vector3 position, float timeToMove) {
			Vector3 currentPos = transform.localPosition;
			float t = 0.0f;

			while (t < 1) {
				t += Time.deltaTime / timeToMove;
				transform.localPosition = Vector3.Lerp (currentPos, position, t);
				yield return null;
			}
		}

		private void SetElements(Transform someTransform, bool before) {
			int childCount = someTransform.childCount;

			for (int i = 0; i < childCount; i++) {
				if (someTransform.GetChild (i).name.StartsWith ("cAfter"))
					someTransform.GetChild (i).gameObject.SetActive (!before);
				else if (someTransform.GetChild (i).name.StartsWith ("cBefore"))
					someTransform.GetChild (i).gameObject.SetActive (before);
			}
		}

		private void SetModelElements (Transform someTransform, bool before) {

			if (someTransform.name.StartsWith ("dAstig")) {

				if (someTransform.GetChild (0).gameObject.activeInHierarchy) {
					Transform tempTransform = someTransform.GetChild (0).transform;
					SetElements (tempTransform, before);
				} else if (someTransform.GetChild (1).gameObject.activeInHierarchy) {
					Transform tempTransform = someTransform.GetChild (1).transform;
					SetElements (tempTransform, before);
				} else
					Debug.LogError ("Something wrong with dAstig model");

			} else {
				SetElements (someTransform, before); 
			}

		}

		private void SetPlane (Toggle toggle, bool sagital) {
			GameObject sagitalPlaneObject = toggle.GetComponent<DisordersToggleScript> ().Model.transform.GetChild(0).gameObject;
			GameObject transversePlaneObject = toggle.GetComponent<DisordersToggleScript> ().Model.transform.GetChild(1).gameObject;

			sagitalPlaneObject.SetActive (sagital);
			transversePlaneObject.SetActive (!sagital);
		}
		#endregion

		#region Public Methods
		public void AfterCorrection () {

			if (!wasAfterToggle) {

				Vector3 temp = new Vector3 (picBefore.transform.localPosition.x, posYAfter, picBefore.transform.localPosition.z);
				IEnumerator coroutine = MoveToPosition (picBefore.transform, temp, 0.5f);
				StartCoroutine (coroutine);

				picAfter.gameObject.SetActive (true);

				foreach (Toggle t in disordersUIManager.TogglesList) {
					if (t.isOn) {
						Transform tempTransform = t.GetComponent<DisordersToggleScript> ().Model.transform;
						SetModelElements(tempTransform, false);

						break;
					}
				}	

				disordersUIManager.BeforeToggle.isOn = false;
				disordersUIManager.BeforeToggle.interactable = true;
				disordersUIManager.AfterToggle.interactable = false;

				wasAfterToggle = true;
				wasBeforeToggle = false;
			}
		}

		public void BeforeCorrection () {

			if (!wasBeforeToggle) {

				Vector3 temp = new Vector3 (picBefore.transform.localPosition.x, posYBefore, picBefore.transform.localPosition.z);
				IEnumerator coroutine = MoveToPosition (picBefore.transform, temp, 0.5f);
				StartCoroutine (coroutine);

				picBefore.sprite = picBeforeReal;
				picAfter.gameObject.SetActive (false);

				foreach (Toggle t in disordersUIManager.TogglesList) {
					if (t.isOn) {
						picBefore.sprite = t.GetComponent<DisordersToggleScript> ().Sprite;

						Transform tempTransform = t.GetComponent<DisordersToggleScript> ().Model.transform;
						SetModelElements(tempTransform, true);

						break;
					}
				}

				disordersUIManager.BeforeToggle.interactable = false;
				disordersUIManager.AfterToggle.isOn = false;
				disordersUIManager.AfterToggle.interactable = true;

				wasBeforeToggle = true;
				wasAfterToggle = false;
			}

		}
			
		public void SagitalPlane () {

			if (!wasSagitalPalneToggle) {

				foreach (Toggle t in disordersUIManager.TogglesList) {
					if (t.isOn) {
						SetPlane (t, true);
						break;
					}
				}

				disordersUIManager.SagitalPlaneToggle.interactable = false;
				disordersUIManager.TransversePlaneToggle.isOn = false;
				disordersUIManager.TransversePlaneToggle.interactable = true;

				wasSagitalPalneToggle = true;
				wasTransversePlaneToggle = false;
			}

		}

		public void TransversePlane () {

			if (!wasTransversePlaneToggle) {

				foreach (Toggle t in disordersUIManager.TogglesList) {
					if (t.isOn) {
						SetPlane (t, false);
						break;
					}
				}

				disordersUIManager.AfterToggle.isOn = true;
				disordersUIManager.BeforeToggle.isOn = true;

				disordersUIManager.TransversePlaneToggle.interactable = false;
				disordersUIManager.SagitalPlaneToggle.isOn = false;
				disordersUIManager.SagitalPlaneToggle.interactable = true;

				wasSagitalPalneToggle = false;
				wasTransversePlaneToggle = true;
			}

		}

		public void SetImage(Sprite spriteToShow) {
			Vector3 temp = new Vector3 (picBefore.transform.localPosition.x, posYBefore, picBefore.transform.localPosition.z);
			IEnumerator coroutine = MoveToPosition (picBefore.transform, temp, 0.5f);
			StartCoroutine (coroutine);

			picBefore.sprite = spriteToShow;

			picAfter.gameObject.SetActive (false);
		}
		#endregion

	}
		
}