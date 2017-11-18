using UnityEngine;
using System.Collections;

public class CollisionDmgToHealth : MonoBehaviour {

	public int damage;
	public LayerMask layermask;


	void Start()
	{

	}

	void Update () 
	{
		//transform.Translate (transform.right * BulletSpeed * Time.deltaTime,Space.World);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (layermask == (layermask | (1 << col.gameObject.layer)))
		{
			if(col.gameObject.GetComponent<Health>() != null)
			{
				col.gameObject.GetComponent<Health>().TakeDamage(damage);
			}
			//Destroy(gameObject);

		}
	}
}
