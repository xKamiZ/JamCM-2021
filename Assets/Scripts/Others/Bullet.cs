using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float m_bulletForce = 20.0f;
	[SerializeField] private Rigidbody2D m_rb2d;
	[SerializeField] private GameObject m_target;

	private Vector2 m_directionToTarget;

	private void Start()
	{
		m_target = GameObject.FindGameObjectWithTag("Player");
		m_directionToTarget = (m_target.transform.position - transform.position).normalized * m_bulletForce;
		m_rb2d.velocity = new Vector2(m_directionToTarget.x, m_directionToTarget.y);
	}
}
