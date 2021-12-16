using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void ClickBackButton()
	{
		// volver menu principal
		MenuManager.OpenMenu(MenuOptions.MAIN_MENU, gameObject);
	}
}
