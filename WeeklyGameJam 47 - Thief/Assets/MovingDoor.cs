using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MovingDoor : MonoBehaviour {

    [FMODUnity.EventRef]
    public string doorMove;

    public void PlayDoorSound() {
        Debug.Log("PlayDoorSound");
        FMODUnity.RuntimeManager.PlayOneShot(doorMove, transform.position);

    }
}
