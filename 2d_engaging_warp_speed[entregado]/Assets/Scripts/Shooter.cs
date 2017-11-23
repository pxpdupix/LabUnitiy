using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	public float fireSpeed;
	public GameObject bulletPrefab;
    public Transform bulletStart;
    public AudioClip shootSound;
	private bool _canShoot = true;
	private float _shootTimer;
    private AudioSource _audioS;

	[Header ("Control")]
	public bool useKey;
	public KeyCode fireKey;
	public bool useLeftClick;
	public bool useRightClick;

	[Header ("IA")]
	public bool hasIA;

    void Awake()
    {
        _audioS = GetComponent<AudioSource>();
        if (_audioS != null)
            _audioS.clip = shootSound;
    }

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
		if(_canShoot && ((useKey && Input.GetKey(fireKey))|| (useLeftClick && Input.GetMouseButton(0))||(useRightClick && Input.GetMouseButton(1))))
		{
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
			_canShoot = false;
			_shootTimer += 1/fireSpeed;
            if(_audioS != null)
                _audioS.Play();
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
