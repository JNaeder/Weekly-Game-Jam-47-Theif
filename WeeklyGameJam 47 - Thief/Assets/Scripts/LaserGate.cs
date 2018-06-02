using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour {

	public Transform laser;
	public float time;
	[Range(0, 10)]
	public float speed;

	bool isOn;
	Vector3 transScale, onScale, offScale;

	float startLength, triggerTime;

	// Use this for initialization
	void Start () {
		startLength = laser.localScale.y;

		onScale = new Vector3(1, startLength, 1);
		offScale = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transScale = laser.localScale;      
		UpdateLaser();      
		laser.localScale = transScale;


		if(Time.time > triggerTime + time){
			triggerTime = Time.time;
			isOn = !isOn;

		}

	}


	void UpdateLaser(){

		if (isOn)
        {
			transScale = Vector3.Lerp(transScale, onScale, speed * Time.deltaTime);

		} else {

			transScale = Vector3.Lerp(transScale, offScale, speed * Time.deltaTime);
		}
	}


}
