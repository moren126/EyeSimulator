using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using EyeSimulator.Anatomy.Data;
using EyeSimulator.Anatomy.UI;

namespace EyeSimulator.Anatomy {

	public class AnatomyClicksManager : MonoBehaviour {

		private AnatomyModes whichMode;
		private AnatomyTextsManager textManagerInstance;
		private AnatomyUIManager anatomyUIManager;
		private AnatomyPinsManager pinsManager;

		private GameObject positionBefore1, positionBefore2;
		private RaycastHit hit;
		private GameObject hitObject1, hitObject2;
		private Toggle hitToggle;
		private Color color;

		private bool rayHitSthg;
		private bool stopEyeRotation;
		private bool isHighlighted;

		private float rotationSpeedH = -30f; 
		private float rotationSpeedV = -30f; 

		private float doubleClickTime = 1f;
		private float lastClickTime = 10f;

		private float fovBefore;
		private float minFov = 50f;

		private bool wasSpace;

		private int index, index3;


		void Start () {
			anatomyUIManager = FindObjectOfType<AnatomyUIManager> ();
			pinsManager = FindObjectOfType<AnatomyPinsManager> ();
			textManagerInstance = FindObjectOfType<AnatomyTextsManager> (); 
			whichMode = FindObjectOfType<AnatomyModes>();

			AssignToLists (AnatomySceneManager.Instance.EyeSocketModel);
			AssignToLists (AnatomySceneManager.Instance.EyeSocketHalfModel);

			isHighlighted = false;
			rayHitSthg = false;
			stopEyeRotation = false;
			wasSpace = false;

			positionBefore1 = new GameObject ();
			positionBefore2 = new GameObject ();

			hitObject1 = AnatomySceneManager.Instance.EmptyGameObject;
			hitObject2 = AnatomySceneManager.Instance.EmptyGameObject;

			index = index3 = 0;
		}
			
		void Update () {

			// what the cursor points to
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				foreach (var list in AnatomySceneManager.Instance.EyeElements.AllLists) {

					foreach (var m in list) {

						if (hit.transform.name == m.DescriptionFileName) {
							hitObject1 = AnatomySceneManager.Instance.GetPart (true, m.DescriptionFileName); 
							hitObject2 = AnatomySceneManager.Instance.GetPart (false, m.DescriptionFileName);

							color = hitObject1.GetComponent<HighlightObject> ().GetColor();
							rayHitSthg = true;

							foreach (Toggle t in anatomyUIManager.TogglesList) {
								if (t.name == m.DescriptionFileName) {
									hitToggle = t;
									break;
								}
							}

							break;
						}

					}


				}
			} else {
				
				if (!isHighlighted) { 
					hitObject1 = AnatomySceneManager.Instance.EmptyGameObject;
					hitObject2 = AnatomySceneManager.Instance.EmptyGameObject;
				}
			}


			// cursor points to the object with the collider
			if (rayHitSthg && (hitObject1 != AnatomySceneManager.Instance.EmptyGameObject || hitObject2 != AnatomySceneManager.Instance.EmptyGameObject)) {

				// deactivation of clicked objects - double LMB
				if (Input.GetMouseButtonDown (0)) {

					float timeDelta = Time.time - lastClickTime;

					if (!isHighlighted) {

						if (timeDelta < doubleClickTime) {
							
							// memorizing the color of the element before highlighting
							hitObject1.GetComponent<Renderer> ().material.color = color;
							hitObject2.GetComponent<Renderer> ().material.color = color;
					
							// adding to the list and deactivation of double-clicked elements
							if (!ElementsVisibility.nonVisibility.Contains(hitObject1))
								ElementsVisibility.nonVisibility.Add (hitObject1);
							if (!ElementsVisibility.nonVisibilityH.Contains(hitObject2))
								ElementsVisibility.nonVisibilityH.Add (hitObject2);
							
							hitObject1.SetActive (false);
							hitObject2.SetActive (false);

							// adding to the list and deactivating the toggle corresponding to the double-clicked element
							if (!ElementsVisibility.nonVisibleToggles.Contains(hitToggle))
								ElementsVisibility.nonVisibleToggles.Add (hitToggle);
							hitToggle.isOn = false;

							lastClickTime = 0;

						} else
							lastClickTime = Time.time;
					}
				}

				// highlighting element - space key pressed once
				if (Input.GetKeyUp (KeyCode.Space) && !wasSpace) {

					if (!isHighlighted) {
						// removing highlighted elements (nonHighlited contain all elements of the model)
						ElementsVisibility.nonHighlited.Remove (hitObject1);
						ElementsVisibility.nonHighlitedH.Remove (hitObject2);

						// deactivation of all elements except highlighted
						for (int x = 0; x < ElementsVisibility.nonHighlited.Count; x++)
							ElementsVisibility.nonHighlited[x].SetActive(false);

						for (int x = 0; x < ElementsVisibility.nonHighlitedH.Count; x++)
							ElementsVisibility.nonHighlitedH[x].SetActive(false);

						isHighlighted = true;
					}


					fovBefore = Camera.main.fieldOfView;
					Camera.main.fieldOfView = minFov;

					positionBefore1.transform.position = new Vector3 (hitObject1.transform.position.x, hitObject1.transform.position.y, hitObject1.transform.position.z);
					positionBefore1.transform.eulerAngles = new Vector3 (hitObject1.transform.eulerAngles.x, hitObject1.transform.eulerAngles.y, hitObject1.transform.eulerAngles.z);
					positionBefore2.transform.position = new Vector3 (hitObject2.transform.position.x, hitObject2.transform.position.y, hitObject2.transform.position.z);
					positionBefore2.transform.eulerAngles = new Vector3 (hitObject2.transform.eulerAngles.x, hitObject2.transform.eulerAngles.y, hitObject2.transform.eulerAngles.z);

					hitObject1.transform.position = Vector3.zero;
					hitObject2.transform.position = Vector3.zero;

					// the condition of stopping the rotation of the whole model, only the highlited element is rotated
					stopEyeRotation = true;

					wasSpace = true;

					textManagerInstance.ShowFullDescription (hitObject1.name);
					textManagerInstance.SettOffLeftMenu ();

					if (whichMode.PinsMode)
						pinsManager.PinsOn ();
				}
					
			}


			// the whole model rotates
			if (!stopEyeRotation) {

				AnatomySceneManager.Instance.EyeSocketModel.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
				AnatomySceneManager.Instance.EyeSocketModel.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);

				AnatomySceneManager.Instance.EyeSocketHalfModel.transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeedH * Time.deltaTime, 0);
				AnatomySceneManager.Instance.EyeSocketHalfModel.transform.Rotate (Input.GetAxis ("Vertical") * rotationSpeedV * Time.deltaTime, 0, 0);


			} // only the highlited element is rotated
			else if (stopEyeRotation) {
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

			// RMB 
			if (Input.GetMouseButtonDown(1)) {

				// undo the element's highlight
				if (isHighlighted) {

					for (int x = 0; x < ElementsVisibility.nonHighlited.Count; x++)
						ElementsVisibility.nonHighlited[x].SetActive(true);

					for (int x = 0; x < ElementsVisibility.nonHighlitedH.Count; x++)
						ElementsVisibility.nonHighlitedH[x].SetActive(true);

					if (!ElementsVisibility.nonHighlited.Contains(hitObject1))
						ElementsVisibility.nonHighlited.Add (hitObject1);
					if (!ElementsVisibility.nonHighlitedH.Contains(hitObject2))
						ElementsVisibility.nonHighlitedH.Add (hitObject2);

					foreach (GameObject item in ElementsVisibility.nonVisibility)
						item.SetActive (false);
					foreach (GameObject item in ElementsVisibility.nonVisibilityH)
						item.SetActive (false);

					Camera.main.fieldOfView = fovBefore;
					hitObject1.transform.position = new Vector3 (positionBefore1.transform.position.x, positionBefore1.transform.position.y, positionBefore1.transform.position.z);
					hitObject1.transform.eulerAngles = new Vector3 (positionBefore1.transform.eulerAngles.x, positionBefore1.transform.eulerAngles.y, positionBefore1.transform.eulerAngles.z);
					hitObject2.transform.position = new Vector3 (positionBefore2.transform.position.x, positionBefore2.transform.position.y, positionBefore2.transform.position.z);
					hitObject2.transform.eulerAngles = new Vector3 (positionBefore2.transform.eulerAngles.x, positionBefore2.transform.eulerAngles.y, positionBefore2.transform.eulerAngles.z);

					stopEyeRotation = false;

					wasSpace = false;

					isHighlighted = false;

					textManagerInstance.SettOffFullDescription ();
					textManagerInstance.SettOnLeftMenu ();
				}

				// undo the deactivation of elements (1 click - one element)
				else if (ElementsVisibility.nonVisibility.Count > 0) {
					index = ElementsVisibility.nonVisibility.Count - 1;

					GameObject undo = ElementsVisibility.nonVisibility [index];
					if (undo) { 
						undo.SetActive (true);
						ElementsVisibility.nonVisibility.RemoveAt (index);
					}

					index = ElementsVisibility.nonVisibilityH.Count - 1;
					undo = ElementsVisibility.nonVisibilityH [index];

					if (undo) {
						undo.SetActive (true);
						ElementsVisibility.nonVisibilityH.RemoveAt (index);
					}
						
					if (ElementsVisibility.nonVisibleToggles.Count >= 0) {
						index3 = ElementsVisibility.nonVisibleToggles.Count - 1;
						Toggle undo3 = ElementsVisibility.nonVisibleToggles [index3];
						undo3.isOn = true;

						if (undo3.transform.parent.GetChild (0).GetComponent<Toggle> ().isOn == false)
							undo3.transform.parent.GetChild (0).GetComponent<Toggle> ().isOn = true;

						if (index3 >= 0 && index3 < ElementsVisibility.nonVisibleToggles.Count)
							ElementsVisibility.nonVisibleToggles.RemoveAt (index3);

					}
						
				} else if (ElementsVisibility.nonVisibility.Count == 0) {
					ElementsVisibility.nonVisibility.Clear ();
					ElementsVisibility.nonVisibilityH.Clear ();
				}
			}	
		}
			
		private void AssignToLists(GameObject model) {
			
			if (model.name == "EyeSocket") {
				foreach (Transform child in model.transform) {
					if (!child.name.StartsWith ("p"))
						ElementsVisibility.nonHighlited.Add (child.gameObject);
				}
			} else if (model.name == "EyeSocketHalf") {
				foreach (Transform child in model.transform) {
					if (!child.name.StartsWith ("p"))
						ElementsVisibility.nonHighlitedH.Add (child.gameObject);
				}
			}
		}

	}
}