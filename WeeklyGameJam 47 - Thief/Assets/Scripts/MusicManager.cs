using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour {

    [FMODUnity.EventRef]
    public string musicEvent;

    FMOD.Studio.EventInstance musicInst;

    GameManager gM;

	// Use this for initialization
	void Start () {
        gM = FindObjectOfType<GameManager>();

        musicInst = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicInst.start();
	}
	
	// Update is called once per frame
	void Update () {
        musicInst.setParameterValue("CheckPointNum", gM.checkNum);
	}
}
