using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
	public static GameObject _mainMenu, _settingsMenu;

	public static bool IsInit { get; private set; }

	public static void Init()
	{
		GameObject m_canvas = GameObject.Find("MainCanvas");
		_mainMenu = m_canvas.transform.Find("MainMenu").gameObject;
		_settingsMenu = m_canvas.transform.Find("SettingsMenu").gameObject;

		IsInit = true;
	}
	public static void OpenMenu(MenuOptions t_menu, GameObject t_calledMenu)
	{
		if (!IsInit)
		{
			Init();
		}
		else
		{
			switch (t_menu)
			{
				case MenuOptions.MAIN_MENU:
					_mainMenu.SetActive(true);
					break;
				case MenuOptions.SETTINGS:
					_settingsMenu.SetActive(true);
					break;
			}
			t_calledMenu.SetActive(false);
		}
	}
}
