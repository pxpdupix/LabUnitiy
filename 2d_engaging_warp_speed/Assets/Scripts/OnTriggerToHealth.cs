using UnityEngine;
using System.Collections;

public class OnTriggerToHealth : MonoBehaviour {

	public int damage;
	public LayerMask layermask;

	void Start()
	{

	}

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (layermask == (layermask | (1 << col.gameObject.layer)))
		{
			if(col.GetComponent<Health>() != null)
			{
				col.GetComponent<Health>().TakeDamage(damage);
			}
			Destroy(gameObject);
		}
	}
}
