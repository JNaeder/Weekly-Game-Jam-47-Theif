using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Camera : MonoBehaviour {

	public Transform camPoint, point1, point2, movingPoint;
	public LineRenderer lineRen;
	public float length;

	public float speed;
	public float thresh;
    public float waitTime;

    float newTime;

	bool moveForward, camSoundStarted;

	Quaternion transRot;
    Vector3 dir;
    float dist, newAngle;

    [FMODUnity.EventRef]
    public string camMotorSound, camMoveStopSound;

    FMOD.Studio.EventInstance camMotorInst;

	// Use this for initialization
	void Start () {
        camMotorInst = FMODUnity.RuntimeManager.CreateInstance(camMotorSound);
        camMotorInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        StartCamSound();
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
            if (Time.time > newTime + waitTime)
            {
                if (camSoundStarted == false) {
                    StartCamSound();
                }

                movingPoint.position = Vector3.MoveTowards(movingPoint.position, point2.position, speed * Time.deltaTime);
                dist = Vector3.Distance(point2.position, movingPoint.position);
                if (dist < thresh)
                {
                    newTime = Time.time;
                    FMODUnity.RuntimeManager.PlayOneShot(camMoveStopSound, transform.position);
                    camMotorInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    camSoundStarted = false;
                    moveForward = !moveForward;
                }
            }
            }
        else {
            if (Time.time > newTime + waitTime)
            {
                if (camSoundStarted == false)
                {
                    StartCamSound();
                }
                movingPoint.position = Vector3.MoveTowards(movingPoint.position, point1.position, speed * Time.deltaTime);
                dist = Vector3.Distance(point1.position, movingPoint.position);
                if (dist < thresh)
                {
                    newTime = Time.time;
                    FMODUnity.RuntimeManager.PlayOneShot(camMoveStopSound, transform.position);
                    camMotorInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    camSoundStarted = false;
                    moveForward = !moveForward;
                }
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
                //  print("SEE PLAYER!");
                Guy_Controller guy = hit.collider.gameObject.GetComponent<Guy_Controller>();
                guy.GetCaught();

            }
        }
	}



    void StartCamSound() {
        camSoundStarted = true;
        camMotorInst.start();

    }
}
