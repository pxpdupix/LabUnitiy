using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

	public float maxSpeed=50f;
	public float currentSpeed;
	public Image uIBar;
	public UnityEvent onMax;
	// Use this for initialization
	void Start () {
		currentSpeed = 0;
		UpdateUIBar();
	}
	
	// Update is called once per frame
	void Update () {
		currentSpeed += Time.deltaTime;
		UpdateUIBar();
		if (currentSpeed >= 50f) {
		} 
	}
	public float GetPercentageSpeed()
	{
		return currentSpeed / maxSpeed;
	}
	public void Win()
	{
		onMax.Invoke();
	}
	public void UpdateUIBar()
	{
		if (uIBar != null)
		{
			uIBar.fillAmount = GetPercentageSpeed();
		}
	}
}
