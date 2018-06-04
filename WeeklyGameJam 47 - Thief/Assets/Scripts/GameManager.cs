using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverScreen, caughtScreen;
	public GameObject restartButton, restartButton2;
	public EventSystem eS;

    public Transform[] checkpoints;
    public int checkNum;

    Guy_Controller guy;
    CameraScript cam;


	// Use this for initialization
	void Start () {
        guy = FindObjectOfType<Guy_Controller>();
        cam = FindObjectOfType<CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void RestartScreen(){

		gameOverScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton);
       
	}


    public void CaughtScreen() {
        caughtScreen.SetActive(true);
        eS.SetSelectedGameObject(restartButton2);

    }

	public void RestartLevel(){
        guy.ResetEverything();
        guy.transform.position = checkpoints[checkNum].position;
        cam.transform.position = checkpoints[checkNum].position;
        gameOverScreen.SetActive(false);
        caughtScreen.SetActive(false);
       
		//SceneManager.LoadScene(0);
	}
}
