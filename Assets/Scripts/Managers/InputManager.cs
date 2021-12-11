using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	#region VARIABLES
	[Header("COMBATE")]
	[SerializeField, Tooltip("Ataque básico")] private KeyCode m_attackKey = KeyCode.Mouse0;

	// Variables no visibles
	private bool m_basicAttack;
	#endregion

	#region PROPIEDADES
	public bool _BasicAttack
	{
		get => m_basicAttack;
	}
	#endregion

	#region METODOS UNITY
	private void Update()
	{
		HandleInput();
	}
	#endregion

	#region METODOS PROPIOS
	protected void HandleInput()
	{
		m_basicAttack = Input.GetKeyDown(m_attackKey);
	}
	#endregion
}
