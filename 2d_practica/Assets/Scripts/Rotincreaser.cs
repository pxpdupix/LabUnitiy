using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotincreaser : MonoBehaviour {
	private ParticleSystem _particle;
	private ParticleSystem.EmissionModule _emission;
	private float _instantiateTimer;
	public float instantiateTime;
	// Use this for initialization
	void Start () {
		_particle= GetComponent <ParticleSystem>();
		_emission = _particle.emission;
	}
	
	// Update is called once per frame
	void Update () {
		_instantiateTimer -= Time.deltaTime;
		if (_instantiateTimer <= 0) {
			if (instantiateTime >= 1) {
				instantiateTime -= 0.05f;
				//_emission.rateOverTime += 1f;

			}
		}
		_instantiateTimer = instantiateTime;
	}
}
