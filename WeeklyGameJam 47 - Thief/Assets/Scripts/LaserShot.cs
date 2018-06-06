using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

	SpriteRenderer sP;
	Collider2D coll;

	// Use this for initialization
	void Start () {
		//sP = GetComponent<SpriteRenderer>();
		//coll = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlayerMain")
        {

            Guy_Controller guy = collision.gameObject.GetComponent<Guy_Controller>();
			if (guy != null)
			{
				guy.Death();
			}
        }
		//coll.enabled = false;
		//sP.enabled = false;

        Destroy(gameObject);
    }
}
