using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour {

    [FMODUnity.EventRef]
    public string musicEvent;

    FMOD.Studio.EventInstance musicInst;

    GameManager gM;
	public static MusicManager musicMan;


	private void Awake()
	{
        
		if(musicMan == null){
			musicMan = this;
		} else {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        gM = FindObjectOfType<GameManager>();

        musicInst = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicInst.start();
	}
	
	// Update is called once per frame
	void Update () {
        musicInst.setParameterValue("CheckPointNum", GameManager.checkNum);
	}
}
