using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private InputManager m_inputManager;
	[SerializeField] private Animator m_playerAnimator;
	[SerializeField] private Transform m_attackPoint;

	[Header("ATRIBUTOS")]
	[SerializeField] private float m_attackRange = 0.5f;
	[SerializeField] private LayerMask m_enemyLayer;

	// Variables no visibles
	private float m_maxTimeAttack = 1.0f; // poner tiempo que dure la animacion de ataque
	private float m_nextAttack = 0.0f;
	#endregion

	#region METODOS UNITY
	private void Update()
	{
		m_nextAttack = Time.deltaTime;
		if (m_inputManager._BasicAttack && m_nextAttack >= m_maxTimeAttack)
		{
			Debug.Log("Jugador atacando!");
			BasicAttack();
			m_nextAttack = 0.0f;
		}
	}
	#endregion

	#region METODOS PROPIOS
	private void BasicAttack()
	{
		// activar animacion de ataque basico
		// obtiene el contacto con el collider de un enemigo en la capa de enemigos
		Collider2D[] m_hitEnemyLayer = Physics2D.OverlapCircleAll(m_attackPoint.position, m_attackRange, m_enemyLayer);
		foreach (Collider2D enemyHit in m_hitEnemyLayer)
		{
			Debug.Log("Enemigo golpeado: " + enemyHit.name);
		}
	}

	#region METODOS DE DEBUG
	private void OnDrawGizmosSelected()
	{
		if (m_attackPoint == null) return;

		Gizmos.DrawWireSphere(m_attackPoint.position, m_attackRange);
	} // debug de la esfera que indica el area de ataque
	#endregion
	#endregion
}
