using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;
    public float camSpeed;
    Vector3 diff;

	// Use this for initialization
	void Start () {
		if (target != null)
		{
			diff = transform.position - target.position;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target != null)
		{
			Vector3 transPos = transform.position;
			transPos = Vector3.Lerp(transPos, target.position + diff, camSpeed * Time.deltaTime);
			transform.position = transPos;
		}
	}
}
