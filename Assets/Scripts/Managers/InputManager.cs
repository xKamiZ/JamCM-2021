using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	#region VARIABLES
	[Header("COMBATE")]
	[SerializeField, Tooltip("Ataque básico")] private KeyCode m_attackKey = KeyCode.Mouse0;
	[SerializeField, Tooltip("Salto")] private KeyCode m_jumpKey = KeyCode.Space;
	[SerializeField, Tooltip("Deslizamiento")] private KeyCode m_dashKey = KeyCode.LeftShift;

	private string m_yAxis = "Vertical";
	private string m_xAxis = "Horizontal";

	// Variables no visibles
	private bool m_isAttacking;
	private bool m_isJumping;
	private bool m_isDashing;

	private float m_horizontal;
	private float m_vertical;
	#endregion

	#region PROPIEDADES
	public bool _BasicAttack
	{
		get => m_isAttacking;
	}
	public bool _JumpKey
	{
		get => m_isJumping;
	}
	public bool _DashKey
	{
		get => m_isDashing;
	}
	public float _Horizontal
	{
		get => m_horizontal;
	}
	public float _Vertical
	{
		get => m_vertical;
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
		m_horizontal = Input.GetAxisRaw(m_xAxis);
		m_vertical = Input.GetAxisRaw(m_yAxis);
		m_isAttacking = Input.GetKeyDown(m_attackKey);
		m_isJumping = Input.GetKeyDown(m_jumpKey);
		m_isDashing = Input.GetKeyDown(m_dashKey);
	}
	#endregion
}
