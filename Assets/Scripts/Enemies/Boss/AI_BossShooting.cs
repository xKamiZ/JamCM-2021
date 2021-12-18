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

	private GameObject m_playerExists;
	private bool m_isBasicShot, m_canShoot = true;
	private float m_nextShot;
	#endregion

	#region PROPIEDADES
	public bool _IsBasicShot
	{
		get => m_isBasicShot;
	}
	public bool _CanShoot
	{
		get => m_canShoot;
	}
	#endregion

	#region METODOS UNTIY
	private void Start()
	{
		m_nextShot = Time.time;
	}
	private void Update()
	{
		m_playerExists = GameObject.FindGameObjectWithTag("Player");
		if (m_playerExists != null)
		{
			m_canShoot = true;
		}
		else
		{
			m_canShoot = false;
		}
	}
	#endregion

	#region METODOS PROPIOS
	public void BasicShot()
	{
		if (Time.time > m_nextShot)
		{
			m_isBasicShot = true;
			Instantiate(m_normalBullet, m_basicShotSpawnPoint.position, Quaternion.identity);
			m_nextShot = Time.time + m_basicShotFireRate;
		}
		m_isBasicShot = false;
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
