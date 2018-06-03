using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform camPoint, point1, point2, movingPoint;
	public LineRenderer lineRen;
	public float length;

	public float speed;
	public float thresh;

	bool moveForward;

	Quaternion transRot;
    Vector3 dir;
    float dist, newAngle;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		CheckForHit();

		MoveCam();
	}





	void MoveCam(){
        dir = movingPoint.position - camPoint.position;
        newAngle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 270;




        if (moveForward) {

            movingPoint.position = Vector3.MoveTowards(movingPoint.position, point2.position, speed * Time.deltaTime);
            dist = Vector3.Distance(point2.position, movingPoint.position);
            if (dist < thresh) {
                moveForward = !moveForward;
            }
            }
        else {
            movingPoint.position = Vector3.MoveTowards(movingPoint.position, point1.position, speed * Time.deltaTime);
            dist = Vector3.Distance(point1.position, movingPoint.position);
            if (dist < thresh)
            {
                moveForward = !moveForward;
            }
        }

        camPoint.rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

    }


	void CheckForHit(){
		float dist;

		RaycastHit2D hit = Physics2D.Raycast(camPoint.position, camPoint.up * length);
		dist = Vector3.Distance(camPoint.position, hit.point);
		lineRen.SetPosition(0, camPoint.position);
		lineRen.SetPosition(1, hit.point);
		Debug.DrawRay(camPoint.position, camPoint.up * dist, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                print("SEE PLAYER!");

            }
        }
	}
}
