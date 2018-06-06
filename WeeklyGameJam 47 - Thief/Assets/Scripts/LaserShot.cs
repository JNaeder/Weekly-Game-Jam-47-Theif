using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {

            Guy_Controller guy = collision.gameObject.GetComponent<Guy_Controller>();
            guy.Death();
        }

        Destroy(gameObject, 0.01f);
    }
}
