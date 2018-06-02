using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{

	public GameObject laser;
	public float laserSpeed;
	[Range (0, 3)]
	public float fireRate;
	public Transform muzzle;

	Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}




	void PlayAnimation (){
		anim.Play("LaserGun_Shoot", 0,0);
	}


	public void StartGun(){
		InvokeRepeating("PlayAnimation", 0.01f, 1 / fireRate);

	}


	public void FireLaser(){

		GameObject firedLaser = Instantiate(laser, muzzle.position, transform.rotation);
		Rigidbody2D laserRB = firedLaser.GetComponent<Rigidbody2D>();
		laserRB.AddForce(-transform.up * laserSpeed, ForceMode2D.Impulse);

	}
}
