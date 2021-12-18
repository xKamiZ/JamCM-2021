using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem
{
	#region VARIABLES
	private int m_health, m_maxHealth;
	public event EventHandler _OnHealthChanged;

	#endregion

	#region PROPIEDADES
	public int _GetHealth()
	{
		return m_health;
	}
	public float _GetHealthPercent()
	{
		return (float)m_health / m_maxHealth;
	}
	#endregion

	#region METODOS
	#region CONSTRUCTORES
	public HealthSystem(int t_maxHealth)
	{
		m_maxHealth = t_maxHealth;
		m_health = m_maxHealth;
	}
	#endregion
	#region OTROS METODOS
	public void TakeDamage(int t_ammount)
	{
		m_health -= t_ammount;
		if (m_health < 0)
		{
			m_health = 0;
		}
		if (_OnHealthChanged != null)
		{
			_OnHealthChanged(this, EventArgs.Empty);
		}
	}
	public void Heal(int t_ammount)
	{
		m_health += t_ammount;
		if (m_health > m_maxHealth)
		{
			m_health = m_maxHealth;
		}
		if (_OnHealthChanged != null)
		{
			_OnHealthChanged(this, EventArgs.Empty);
		}
	}
	#endregion
	#endregion
}
