using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private EventManager m_eventManager;
	[SerializeField] private Animator m_animator;
	[SerializeField] private Transform m_attackPoint;

	[Header("ATRIBUTOS")]
	[SerializeField, Tooltip("Retraso entre cada ataque")] private float m_attackDelay = 1.5f; // poner tiempo que dure la animacion de ataque
	[SerializeField, Tooltip("Área de ataque")] private float m_attackRange = 0.5f;
	[SerializeField, Tooltip("Máscara de los afectados por el ataque")] private LayerMask m_enemyLayer;

	// Variables no visibles
	private float m_nextAttack = 0.0f;
	#endregion

	#region METODOS UNITY
	private void Start()
	{
		// SUSCRIPCIONES A EVENTOS
		m_eventManager.OnLeftClickPressed += M_eventManager_OnLeftClickPressed;
		// OTROS
	}
	#endregion

	#region METODOS PROPIOS
	#region EVENTOS
	private void M_eventManager_OnLeftClickPressed(object sender, System.EventArgs e)
	{
		if (Time.time >= m_nextAttack)
		{
			BasicAttack();
			m_nextAttack = Time.time + 1.0f / m_attackDelay;
		} // el evento ejecuta una función determinada
	} // se llama al evento con la condicion correspondiente (mirar event manager)
	#endregion
	#region OTROS METODOS
	private void BasicAttack()
	{
		m_animator.SetBool("isAttacking", true);
		Collider2D[] m_hitEnemyLayer = Physics2D.OverlapCircleAll(m_attackPoint.position, m_attackRange, m_enemyLayer); // obtiene el contacto con el collider de un enemigo en la capa de enemigos
		foreach (Collider2D enemyHit in m_hitEnemyLayer)
		{
			// dañar enemigo
			Debug.Log("Enemigo golpeado: " + enemyHit.name);
		}
	}
	#endregion
	#region METODOS DE DEBUG
	private void OnDrawGizmosSelected()
	{
		if (m_attackPoint == null) return;

		Gizmos.DrawWireSphere(m_attackPoint.position, m_attackRange);
	} // debug de la esfera que indica el area de ataque
	#endregion
	#endregion
}
