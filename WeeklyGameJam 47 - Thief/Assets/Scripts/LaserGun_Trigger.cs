using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun_Trigger : MonoBehaviour {

	LaserGun laserGun;
	BoxCollider2D trig;

	// Use this for initialization
	void Start () {
		laserGun = GetComponentInParent<LaserGun>();
		trig = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		trig.enabled = false;
		laserGun.StartGun();
	}
}
