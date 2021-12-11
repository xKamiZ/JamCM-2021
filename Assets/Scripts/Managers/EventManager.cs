using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	#region VARIABLES
	[SerializeField] private InputManager m_inputManager;
	#endregion

	#region EVENTOS
	public event EventHandler OnLeftClickPressed;
	#endregion

	#region METODOS UNITY
	private void Update()
    {
		if (m_inputManager._BasicAttack)
		{
			OnLeftClickPressed?.Invoke(this, EventArgs.Empty);
		}
    }
	#endregion
}
