using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverScreen;
	public GameObject restartButton;
	public EventSystem eS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void RestartScreen(){

		gameOverScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton);
       
	}

	public void RestartLevel(){

		SceneManager.LoadScene(0);
	}
}
