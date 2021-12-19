using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
	public static void ChangeTag(GameObject t_gameObj, string t_tag)
	{
		if (t_gameObj.CompareTag(t_tag))
		{
			t_gameObj.gameObject.tag = ("Untagged");
		}
		else if (t_gameObj.CompareTag("Untagged"))
		{
			t_gameObj.gameObject.tag = (t_tag);
		}
	}
}
