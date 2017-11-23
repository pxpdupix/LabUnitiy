using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotincreaser : MonoBehaviour {
	private ParticleSystem _particle;
	private ParticleSystem.EmissionModule emission;
	public float Value = 10.0f;
	// Use this for initialization
	void Start () {
		_particle= GetComponent <ParticleSystem>();
		emission = _particle.emission;
		StartCoroutine (Incremento ());
	}
	
	// Update is called once per frame
	void Update () {


	}

	private IEnumerator Incremento(){
		for (int i=0; i<300; i++){
		yield return new WaitForSeconds (2);
		Value = Value * 1.18f;
			emission.rateOverTime = Value;
		}
	}
}
