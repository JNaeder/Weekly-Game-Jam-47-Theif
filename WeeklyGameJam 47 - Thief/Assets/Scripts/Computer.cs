using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

	Animator anim;
	public Animator door;

	public bool isActive;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetBool("isActive", isActive);
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (Input.GetButton("Fire1"))
			{
				//print("Access Computer!");
				isActive = true;
				door.Play("Door_Move");
			}
		}
	}


	public void CloseDoor()
	{
		door.Play("Door_Still");

	}

}
