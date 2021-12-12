using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BossBasicShoot : MonoBehaviour
{
	#region VARIABLES
	[SerializeField] private Transform m_shootPoint;
	[SerializeField] private GameObject m_bullet;
	[SerializeField] private Transform m_target;

	private float m_fireRate = 1.5f;
	private float m_nextShot;
	#endregion

	#region METODOS UNTIY
	private void Start()
	{
		m_nextShot = Time.time;
	}
	private void Update()
	{
		CheckShot();
	}
	#endregion

	#region METODOS PROPIOS
	private void CheckShot()
	{
		if (Time.time > m_nextShot)
		{
			BossShoot();
			m_nextShot = Time.time + m_fireRate;
		}
	}
	private void BossShoot()
	{
		Instantiate(m_bullet, m_shootPoint.position, Quaternion.identity);
	}
	#endregion
}
