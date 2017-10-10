using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIfKey : MonoBehaviour
{
    public float speed;

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey (KeyCode.W))
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.S))
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.A))
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.D))
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.Q))
			transform.Translate (-1.0f * speed * Time.deltaTime, 0, 1.0f * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.E))
			transform.Translate (1.0f * speed * Time.deltaTime, 0, 1.0f * speed * Time.deltaTime);
	}
}
