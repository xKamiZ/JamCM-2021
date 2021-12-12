using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private Rigidbody2D m_rb2d;
	[SerializeField] private GameObject m_target;
	[Header("ATRIBUTOS")]
	[SerializeField] private float m_bulletForce = 20.0f;

	private Vector2 m_directionToTarget;
	#endregion

	#region METODOS UNITY
	private void Start()
	{
		m_target = GameObject.FindGameObjectWithTag("Player");
		m_directionToTarget = (m_target.transform.position - transform.position).normalized * m_bulletForce;
		m_rb2d.velocity = new Vector2(m_directionToTarget.x, m_directionToTarget.y);
	}
	#endregion
}
