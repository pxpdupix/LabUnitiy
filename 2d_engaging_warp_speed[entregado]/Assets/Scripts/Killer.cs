using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Killer : MonoBehaviour 
{
    public List<string> tagsToKill;
	void OnCollisionEnter2D(Collision2D col)
	{
		if(tagsToKill.Contains(col.gameObject.tag))
		{
            if(col.gameObject.GetComponent<Health>() != null)
            {
                col.gameObject.GetComponent<Health>().Die();
            }
		}
	}
}
