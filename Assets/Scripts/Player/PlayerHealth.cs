using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	#region VARIABLES
	[Header("PARAMETROS")]
	[SerializeField, Range(1, 5)] private int m_numHearts;

	[Header("REFERENCIAS")]
	[SerializeField] private SceneReload m_sceneReload;
	[SerializeField] private Animator m_animator;
	[SerializeField] private Image[] m_heartsGraphics;
	[SerializeField] private Sprite m_fullHeart;
	[SerializeField] private Sprite m_emptyHeart;

	private GameObject m_projectile;
	private Bullet m_bullet;
	private int m_health;
	private static bool m_isPlayerDead = false;
	#endregion

	#region PROPIEDADES
	public static bool _IsPlayerDead
	{
		get => m_isPlayerDead;
		set => m_isPlayerDead = value;
	}
	#endregion	
	#region METODOS UNITY
	private void Start()
	{
		m_health = m_numHearts;
	}
	private void Update()
	{
		CheckHealth();
		SetHeartsVisuals();
		if (Bullet._IsPlayer)
		{
			TakeDamage(1);
			Bullet._IsPlayer = false;
		}
	}
	#endregion

	#region METODOS PROPIOS
	public void TakeDamage(int t_ammount)
	{
		if (m_health >= t_ammount)
		{
			m_health -= t_ammount;
		}
		else
		{
			t_ammount = 1;
		}
	}
	private void SetHeartsVisuals()
	{
		for (int i = 0; i < m_heartsGraphics.Length; ++i)
		{
			if (i < m_health)
			{
				m_heartsGraphics[i].sprite = m_fullHeart;
			}
			else
			{
				m_heartsGraphics[i].sprite = m_emptyHeart;
			}

			if (i < m_numHearts)
			{
				m_heartsGraphics[i].enabled = true;
			}
			else
			{
				m_heartsGraphics[i].enabled = false;
			}
		}
	} // establece en el ui el numero de corazones correspondientes a los puestos en m_numHearts
	private void CheckHealth()
	{
		if (m_health <= 0)
		{
			// anim de morir
			Destroy(gameObject);
			m_sceneReload._CanReloadScene = true;
		}
	}
	#endregion
}
