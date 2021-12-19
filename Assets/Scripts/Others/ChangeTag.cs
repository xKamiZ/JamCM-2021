using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Untagged")
		{
			TagChanger.ChangeTag(collision.gameObject, "Projectile");
		}
	}
}
