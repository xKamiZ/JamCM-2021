using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
	#region VARIABLES
	private bool m_canReloadScene = false;
	#endregion

	#region PROPIEDADES
	public bool _CanReloadScene
	{
		get => m_canReloadScene;
		set => m_canReloadScene = value;
	}
	#endregion

	#region METODOS UNITY
	private void Start()
	{
		m_canReloadScene = false;
	}
	private void Update()
	{
		if (m_canReloadScene)
		{
			StartCoroutine("IReloadScene");
		}
	}
	#endregion

	#region METODOS PROPIOS
	IEnumerator IReloadScene()
	{
		m_canReloadScene = false;
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene(1);
	}
	#endregion
}
