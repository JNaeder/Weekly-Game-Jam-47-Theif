using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	GameManager gM;

	bool isPaused;

	// Use this for initialization
	void Start () {
		gM = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetButtonDown("Cancel")){
			if (!isPaused)
			{
				Time.timeScale = 0;
				isPaused = true;
				gM.PauseScreen();
			} else {
				Time.timeScale = 1;
				isPaused = false;
				gM.UnPause();
			}
		}
		
	}
}
