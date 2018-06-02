using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWheel : MonoBehaviour {

	public float speed;
	public Transform laser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion transRot = laser.rotation;
		transRot.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime * 100);
		laser.rotation = transRot;


	}
}
