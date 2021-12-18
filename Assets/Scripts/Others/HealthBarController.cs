using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
	private HealthSystem m_healthSystem;
	public void Init(HealthSystem t_healthSystem)
	{
		m_healthSystem = t_healthSystem;
		m_healthSystem._OnHealthChanged += M_healthSystem__OnHealthChanged;
	}
	private void M_healthSystem__OnHealthChanged(object sender, System.EventArgs e)
	{
		transform.Find("HealthBarController").localScale = new Vector3(m_healthSystem._GetHealthPercent(), 1);
	}
}
