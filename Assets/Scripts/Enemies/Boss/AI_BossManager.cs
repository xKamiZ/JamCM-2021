using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BossStates { Basic, Aggressive }

public class AI_BossManager : MonoBehaviour
{
	#region VARIABLES
	[Header("REFERENCIAS")]
    [SerializeField] private AI_BossShooting m_bossShooting;

	[SerializeField] private int m_currentState = (int)BossStates.Basic;
	private bool m_canBasicShot = true;
	private bool m_canLaserShot = false;
	private bool m_canMove = true;
	#endregion

	#region PROPIEDADES
	public bool _CanBasicShot
	{
		get => m_canBasicShot;
		set => m_canLaserShot = value;
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
	private void Update()
	{
		if (m_currentState == (int)BossStates.Basic)
		{
			m_canBasicShot = true;
			m_canLaserShot = false;
			if (m_canBasicShot && !m_canLaserShot)
			{
				m_bossShooting.BasicShot();
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
	}
	#endregion
}
