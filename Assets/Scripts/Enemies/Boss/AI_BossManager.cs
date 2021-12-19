using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum BossStates { Basic, Aggressive }

public class AI_BossManager : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private AI_BossShooting m_bossShooting;
	[SerializeField] private Animator m_animator;
	[SerializeField] private HealthBarController m_healthBarController;

	[SerializeField] private int m_currentState = (int)BossStates.Basic;
	private bool m_canBasicShot = true;
	private bool m_canLaserShot = false;
	private bool m_canMove = true;

	private HealthSystem m_healthSystem = new HealthSystem(100);
	#endregion

	#region PROPIEDADES
	public bool _CanBasicShot
	{
		get => m_canBasicShot;
		set => m_canBasicShot = value;
	}
	public bool _CanLaserShot
	{
		get => m_canLaserShot;
		set => m_canLaserShot = value;
	}
	public bool _CanMove
	{
		get => m_canMove;
		set => m_canMove = value;
	}
	#endregion

	#region METODOS UNITY
	private void Start()
	{
		m_bossShooting._CanShoot = true;
		m_healthBarController.Init(m_healthSystem);
	}
	private void Update()
	{
		if (m_bossShooting._CanShoot)
		{
			if (m_currentState == (int)BossStates.Basic)
			{
				m_canBasicShot = true;
				m_canLaserShot = false;
				if (m_canBasicShot && !m_canLaserShot)
				{
					m_bossShooting.BasicShot();
					if (m_bossShooting._IsBasicShot)
					{
						m_animator.SetBool("isAttacking", true);
					}
					else
					{
						m_animator.SetBool("isAttacking", false);
					}
				}
			}
			else if (m_currentState == (int)BossStates.Aggressive)
			{
				m_canBasicShot = false;
				m_canLaserShot = true;
				if (m_canLaserShot && !m_canBasicShot)
				{
					m_bossShooting.LaserShot();
				}
			}
			if (m_healthSystem._GetHealth() <= 0)
			{
				m_bossShooting._CanShoot = false;
				BossDie();
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Projectile")
		{
			m_animator.SetTrigger("isHit");
			m_healthSystem.TakeDamage(10);
			Debug.Log(m_healthSystem._GetHealth()); 
		}
	}
	private void BossDie()
	{
		Destroy(gameObject);
		SceneManager.LoadScene(0);
	}
	#endregion
}
