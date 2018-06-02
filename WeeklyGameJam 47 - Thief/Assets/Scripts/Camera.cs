using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform camPoint;
	public LineRenderer lineRen;
	public float length;

	public float speed;
	public float movementDegree;
	public float thresh;

	bool moveForward;

	Quaternion transRot;
	Vector3 startAngle, newAngle;

	// Use this for initialization
	void Start () {
		startAngle = camPoint.rotation.eulerAngles;
		newAngle = new Vector3(0, 0, movementDegree);
		moveForward = true;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForHit();

		MoveCam();
	}





	void MoveCam(){
		transRot = camPoint.rotation;
		float diff;
		if(moveForward){
			transRot.eulerAngles = Vector3.Lerp(transRot.eulerAngles, newAngle, speed * Time.deltaTime);
			diff = newAngle.z - transRot.eulerAngles.z;
			if(diff < thresh){
				moveForward = !moveForward;
			}

		} else {
			transRot.eulerAngles = Vector3.Lerp(transRot.eulerAngles,startAngle, speed * Time.deltaTime);
			diff = transRot.eulerAngles.z - startAngle.z;
			if (diff < thresh)
            {
				moveForward = !moveForward;

            }
		}

		camPoint.rotation = transRot;



	}


	void CheckForHit(){
		float dist;

		RaycastHit2D hit = Physics2D.Raycast(camPoint.position, camPoint.up * length);
		dist = Vector3.Distance(camPoint.position, hit.point);
		lineRen.SetPosition(0, camPoint.position);
		lineRen.SetPosition(1, hit.point);
		Debug.DrawRay(camPoint.position, camPoint.up * dist, Color.red);
        if (hit.collider.gameObject.tag == "Player")
        {
            print("SEE PLAYER!");

        }
	}
}
