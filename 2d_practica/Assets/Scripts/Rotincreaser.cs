using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotincreaser : MonoBehaviour {
	private ParticleSystem _particle;
	public float instantiateTime;
	public float hSliderValue = 5.0f;
	public float scale = 10.0f;
	private AnimationCurve curva;
	private ParticleSystem.EmissionModule emission;
	// Use this for initialization
	void Start () {
		_particle= GetComponent <ParticleSystem>();
		emission = _particle.emission;

	}
	
	// Update is called once per frame
	void Update () {
		
		curva = new AnimationCurve ();
		curva.AddKey (0.0f, 0.0f);
		curva.AddKey (1.0f, 1.0f);
		emission.rateOverTime = new ParticleSystem.MinMaxCurve (scale, curva);
		Invoke ("ModifyCurve", 5.0f);
	}
	void ModifyCurve(){
		curva.AddKey (0.5f, 0.0f);
		emission.rateOverTime = new ParticleSystem.MinMaxCurve (scale, curva);
	}
}
