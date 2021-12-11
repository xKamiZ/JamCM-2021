using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BossPatrol : MonoBehaviour
{
	#region VARIABLES
	[SerializeField] private float m_speed = 5.0f;
	[SerializeField] private List<Transform> m_waypoints;

	private float m_distanceToChange = 0.1f;
	private byte m_index = 0;
	#endregion

	#region METODOS UNITY
	private void Update()
	{
		MoveBoss();
		GetNextWaypoint();
	}
	#endregion

	#region METODOS PROPIOS
	private void GetNextWaypoint()
	{
		if (Vector3.Distance(transform.position, m_waypoints[m_index].transform.position) < m_distanceToChange)
		{
			++m_index;
			if (m_index >= m_waypoints.Count)
			{
				m_index = 0;
			}
		}
	}
	private void MoveBoss()
	{
		transform.position = Vector3.MoveTowards(transform.position, m_waypoints[m_index].transform.position, m_speed * Time.deltaTime);
	}
	#endregion
}
