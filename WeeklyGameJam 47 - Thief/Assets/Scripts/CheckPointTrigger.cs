using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {

    public int checkpointNum;
    GameManager gM;

	SpriteRenderer sP;
	ParticleSystem[] pS;


    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
		sP = GetComponentInChildren<SpriteRenderer>();
		pS = GetComponentsInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
			gM.checkNum = checkpointNum;
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

			Destroy(gameObject, 5f);
        }
            
    }
}
