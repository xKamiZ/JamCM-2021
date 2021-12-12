using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BossShooting : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private Transform m_basicShotSpawnPoint;
	[SerializeField] private Transform m_laserShotSpawnPoint;
	[SerializeField] private GameObject m_normalBullet;
	[SerializeField] private GameObject m_laserBullet;
	[Header("PARAMETROS")]
	[SerializeField] private float m_basicShotFireRate = 1.5f;
	[SerializeField] private float m_laserShotFireRate = 0.5f;

	private float m_nextShot;
	#endregion

	#region METODOS UNTIY
	private void Start()
	{
		m_nextShot = Time.time;
	}
	#endregion

	#region METODOS PROPIOS
	public void BasicShot()
	{
		if (Time.time > m_nextShot)
		{
			Instantiate(m_normalBullet, m_basicShotSpawnPoint.position, Quaternion.identity);
			m_nextShot = Time.time + m_basicShotFireRate;
		}
	}
	public void LaserShot()
	{
		if (Time.time > m_nextShot)
		{
			Instantiate(m_laserBullet, m_laserShotSpawnPoint.position, Quaternion.identity);
			m_nextShot = Time.time + m_laserShotFireRate;
		}
	}
	#endregion
}
