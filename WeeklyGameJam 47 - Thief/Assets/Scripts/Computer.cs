using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Computer : MonoBehaviour
{

	Animator anim;
	public Animator door;

	public bool isActive;

    [FMODUnity.EventRef]
    public string compHum, compHacking;
    FMOD.Studio.EventInstance compHumInst;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();

        compHumInst = FMODUnity.RuntimeManager.CreateInstance(compHum);
        compHumInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        compHumInst.start();
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetBool("isActive", isActive);
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerMain")
		{
			if (Input.GetButton("Fire1"))
			{
                if (!isActive)
                {
                    //print("Access Computer!");
                    isActive = true;
                    FMODUnity.RuntimeManager.PlayOneShot(compHacking, transform.position);
                    compHumInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    
                }
			}
		}
	}

    public void OpenDoor() {
        door.Play("Door_Move");
        MovingDoor moveDoor = door.gameObject.GetComponent<MovingDoor>();
        moveDoor.PlayDoorSound();

    }


    public void CloseDoor()
	{
		door.Play("Door_Still");
        compHumInst.start();
        anim.Play("Computer_Idle");

	}




}
