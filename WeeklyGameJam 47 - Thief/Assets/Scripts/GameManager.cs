using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverScreen, caughtScreen, winScreen;
	public GameObject restartButton, restartButton2, restartButton3;
	public EventSystem eS;

    public Transform[] checkpoints;
    public int checkNum;

    Guy_Controller guy;
    CameraScript cam;
	Computer[] comps;

	// Use this for initialization
	void Start () {
        guy = FindObjectOfType<Guy_Controller>();
        cam = FindObjectOfType<CameraScript>();
		comps = FindObjectsOfType<Computer>();
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
		foreach(Computer c in comps){
			c.isActive = false;
			c.CloseDoor();
		}
        gameOverScreen.SetActive(false);
        caughtScreen.SetActive(false);
		winScreen.SetActive(false);
       
		//SceneManager.LoadScene(0);
	}


	public void WinScreen(){
		winScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton3);

	}


	public void ReLoadLevel(){

		SceneManager.LoadScene(0);
	}
}
