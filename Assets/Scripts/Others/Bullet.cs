using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
	[SerializeField] private Rigidbody2D m_rb2d;
	[Header("ATRIBUTOS")]
	[SerializeField] private float m_bulletForce = 20.0f;
	[SerializeField] private float m_timerBala=3;

	private GameObject m_target;
	private Vector2 m_directionToTarget;
	private bool m_canBounce = false;
	private static bool m_isPlayer = false, m_isEnemy = false;
	#endregion

	#region PROPIEDADES
	public bool _CanBounce
	{
		get => m_canBounce;
	}
	public static bool _IsPlayer
	{
		get => m_isPlayer;
		set => m_isPlayer = value;
	}
	public static bool _IsEnemy
	{
		get => m_isEnemy;
		set => m_isEnemy = value;
	}
	#endregion

	#region METODOS UNITY
	private void Start()
	{
		m_target = GameObject.FindGameObjectWithTag("Target");
		m_directionToTarget = (m_target.transform.position - transform.position).normalized * m_bulletForce;
		m_rb2d.velocity = new Vector2(m_directionToTarget.x, m_directionToTarget.y);
		TagChanger.ChangeTag(gameObject, "Projectile");
	}
    private void Update()
    {
		DestruirBala();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "TriggerReturn")
		{
			m_canBounce = true;
			if (PlayerAttack._IsAttacking)
			{
				m_target = GameObject.FindGameObjectWithTag("Boss");
				m_directionToTarget = (m_target.transform.position - transform.position).normalized * m_bulletForce;
				m_rb2d.velocity = new Vector2(m_directionToTarget.x, m_directionToTarget.y);
			}
		}
        if (collision.tag == "DamageTarget")
        {
			m_isPlayer = true;
			Destroy(gameObject);
        }
		if (collision.tag == "DamageEnemy")
		{
			m_isEnemy = true;
			Destroy(gameObject);
		}
	}
	#endregion

	#region METODOS PROPIOS
	private void DestruirBala()
	{
		m_timerBala = m_timerBala - Time.deltaTime;
		if (m_timerBala <= 0)
		{
			Destroy(gameObject);
		}
	}
	#endregion
}
