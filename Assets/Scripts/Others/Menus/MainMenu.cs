using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ClickInitButton()
	{
		// iniciar partida
		SceneManager.LoadScene(1);
	}
	public void ClickSettingsButton()
	{
		// abrir menu opciones
		MenuManager.OpenMenu(MenuOptions.SETTINGS, gameObject);
	}
	public void ClickExitButton()
	{
		Application.Quit();
	}
}
