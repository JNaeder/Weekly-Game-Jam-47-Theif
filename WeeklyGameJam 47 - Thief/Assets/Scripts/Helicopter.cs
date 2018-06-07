using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	Animator anim;

	public Transform hangingTrans;
	public float speed;

    public bool flysRightAway;

    bool isFlying;

	Guy_Controller guy;

	Collider2D coll;
	GameManager gM;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
		gM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("isFlying", isFlying);
        if (!isFlying) {
            if (flysRightAway) {
                isFlying = true;
            }
        }

	}


	private void FixedUpdate()
	{
		if (isFlying == true)
        {
            if (hangingTrans != null)
            {
					guy.transform.position = hangingTrans.position;
				
            }


            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "PlayerMain"){
			guy = collision.gameObject.GetComponent<Guy_Controller>();
			coll.enabled = false;
			//print("HeliCopterStart!");
			guy.Hanging();
			
			isFlying = true;
			gM.WinScreen();

		}
	}
}
