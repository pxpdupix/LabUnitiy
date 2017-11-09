﻿using UnityEngine;
using System.Collections;

public class Shooter2D : MonoBehaviour 
{
	public float fireSpeed;
	public GameObject bulletPrefab;
    public Transform bulletStart;
	private bool _canShoot = true;
	private float _shootTimer;

	[Header ("Control")]
	public KeyCode fireKey;
	public bool useLeftClick;
	public bool useRightClick;

	[Header ("IA")]
	public bool hasIA;

	void Update()
	{
		if(hasIA)
		{
			CheckIA();
		}
		else
		{
			CheckFire();
		}
	}

	private void CheckFire()
	{
		if(_canShoot && (Input.GetKey(fireKey)|| (useLeftClick && Input.GetMouseButton(0))||(useRightClick && Input.GetMouseButton(1))))
		{
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
			_canShoot = false;
			_shootTimer += 1/fireSpeed;
		}
		if(!_canShoot)
		{
			_shootTimer -= Time.deltaTime;
			if(_shootTimer<=0)
			{
				_canShoot = true;
			}
		}
	}

	private void CheckIA()
	{
		if(_canShoot)
		{
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
			_canShoot = false;
			_shootTimer += 1/fireSpeed;
		}
		if(!_canShoot)
		{
			_shootTimer -= Time.deltaTime;
			if(_shootTimer<=0)
			{
				_canShoot = true;
			}
		}
	}
}
