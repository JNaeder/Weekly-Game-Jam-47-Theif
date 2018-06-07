using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public GameObject gameOverScreen, caughtScreen, winScreen, pauseScreen, controlsScreen;
	public GameObject restartButton, restartButton2, restartButton3, resumeButton, backButton;
	public EventSystem eS;

	public Transform[] checkpoints;
	public static int checkNum;

	Guy_Controller guy;
	CameraScript cam;
	Computer[] comps;

	public bool isPaused;

	// Use this for initialization
	void Start()
	{
		guy = FindObjectOfType<Guy_Controller>();
		cam = FindObjectOfType<CameraScript>();
		comps = FindObjectsOfType<Computer>();
	}

	// Update is called once per frame
	void Update()
	{
		Pause();
	}


	public void RestartScreen()
	{
		eS.SetSelectedGameObject(null);
		gameOverScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton);

	}


	public void CaughtScreen()
	{
		eS.SetSelectedGameObject(null);
		caughtScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton2);

	}

	public void RestartLevel()
	{
		guy.ResetEverything();
		guy.transform.position = checkpoints[checkNum].position;
		cam.transform.position = checkpoints[checkNum].position;
		foreach (Computer c in comps)
		{
			c.isActive = false;
			c.CloseDoor();
		}
		gameOverScreen.SetActive(false);
		caughtScreen.SetActive(false);
		winScreen.SetActive(false);

		//SceneManager.LoadScene(0);
	}


	public void WinScreen()
	{
        

		eS.SetSelectedGameObject(null);
		winScreen.SetActive(true);
		eS.SetSelectedGameObject(restartButton3);

	}


	public void ReLoadLevel()
	{
        checkNum = 0;
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		print("Quit Game");
		Application.Quit();
	}

	public void PauseScreen()
	{   if (!guy.isDead)
		{ if (!guy.isCaught)
			{
				Time.timeScale = 0;
				eS.SetSelectedGameObject(null);
				pauseScreen.SetActive(true);
				controlsScreen.SetActive(false);
				eS.SetSelectedGameObject(resumeButton);
				isPaused = true;
			}
		}

	}

	public void UnPause()
	{
		pauseScreen.SetActive(false);
        controlsScreen.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;

	}

	void Pause()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (!isPaused)
			{
				PauseScreen();
			}
			else
			{
				UnPause();
			}
		}

	}


	public void ShowControls(){
		eS.SetSelectedGameObject(null);
		pauseScreen.SetActive(false);
		controlsScreen.SetActive(true);
		eS.SetSelectedGameObject(backButton);


	}

	public void StartMenu(){

        eS.SetSelectedGameObject(null);
        pauseScreen.SetActive(true);
        controlsScreen.SetActive(false);
        eS.SetSelectedGameObject(resumeButton);

	}
}
