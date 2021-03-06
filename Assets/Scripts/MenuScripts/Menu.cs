﻿using UnityEngine;
using System.Collections;

namespace EyeSimulator.Menu {

	public class Menu : MonoBehaviour {

		private Animator animator;
		private CanvasGroup canvasGroup;

		public bool isOpen {
			get { return animator.GetBool ("IsOpen"); }
			set { animator.SetBool ("IsOpen", value); }
		}
			
		void Awake () {
			animator = GetComponent<Animator> ();
			canvasGroup = GetComponent<CanvasGroup> ();

			var rect = GetComponent<RectTransform> ();
			rect.offsetMax = rect.offsetMin = new Vector2 (0,0);
		}

		void Update () {
			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
			} else {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
			}
		}
	}

}