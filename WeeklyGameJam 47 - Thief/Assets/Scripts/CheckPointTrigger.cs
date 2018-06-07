using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CheckPointTrigger : MonoBehaviour {

    public int checkpointNum;
	public SpriteRenderer checkpointSignColor;
    GameManager gM;

	SpriteRenderer sP;
	ParticleSystem[] pS;
	Collider2D coll;

    [FMODUnity.EventRef]
    public string emeraldAmb, emerladGet;

    FMOD.Studio.EventInstance emeraldInst;


    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
		sP = GetComponentInChildren<SpriteRenderer>();
		pS = GetComponentsInChildren<ParticleSystem>();
		coll = GetComponent<Collider2D>();
        if (emeraldAmb != null)
        {
            emeraldInst = FMODUnity.RuntimeManager.CreateInstance(emeraldAmb);
            emeraldInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            emeraldInst.start();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
			GameManager.checkNum = checkpointNum;
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

            if (emeraldAmb != null) {
                FMODUnity.RuntimeManager.PlayOneShot(emerladGet, transform.position);
                emeraldInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
			coll.enabled = false;

        }
            
    }
}
