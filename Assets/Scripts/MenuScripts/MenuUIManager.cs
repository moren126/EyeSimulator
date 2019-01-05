using UnityEngine;
using System.Collections;

namespace EyeSimulator.Menu { 

	public class MenuUIManager : MonoBehaviour {

		public Menu currentMenu;

		public void Start () {
			ShowMenu (currentMenu);
		}

		public void ShowMenu(Menu menu) {
			if (currentMenu != null)
				currentMenu.isOpen = false;

			currentMenu = menu;
			currentMenu.isOpen = true; 
		}

	}

}