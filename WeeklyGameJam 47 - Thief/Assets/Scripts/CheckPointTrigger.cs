using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {

    public int checkpointNum;
	public SpriteRenderer checkpointSignColor;
    GameManager gM;

	SpriteRenderer sP;
	ParticleSystem[] pS;
	Collider2D coll;


    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
		sP = GetComponentInChildren<SpriteRenderer>();
		pS = GetComponentsInChildren<ParticleSystem>();
		coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
			gM.checkNum = checkpointNum;
			checkpointSignColor.color = Color.green;

			if (sP != null)
			{
				sP.enabled = false;
			}
			if (pS != null)
			{
				foreach (ParticleSystem p in pS)
				{
					p.Stop();
				}
			}
			coll.enabled = false;

        }
            
    }
}
