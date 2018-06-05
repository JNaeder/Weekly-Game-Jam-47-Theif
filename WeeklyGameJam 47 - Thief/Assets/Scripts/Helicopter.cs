using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	Animator anim;

	public Transform hangingTrans;
	public float speed;

	Guy_Controller guy;

	Collider2D coll;
	GameManager gM;


	bool isFlying;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
		gM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("isFlying", isFlying);


	}


	private void FixedUpdate()
	{
		if (isFlying == true)
        {
            guy.transform.position = hangingTrans.position;


            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player"){
			guy = collision.gameObject.GetComponent<Guy_Controller>();
			coll.enabled = false;
			print("HeliCopterStart!");
			guy.Hanging();
			isFlying = true;
			gM.WinScreen();

		}
	}
}
