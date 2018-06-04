using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {

    public int checkpointNum;
    GameManager gM;


    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            gM.checkNum = checkpointNum;

        }
    }
}
