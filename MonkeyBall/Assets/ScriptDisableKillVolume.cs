using UnityEngine;
using System.Collections;

public class ScriptDisableKillVolume : MonoBehaviour {

    public GameObject KillVolumeToDisable;
	void OnTriggerEnter()
    {
        KillVolumeToDisable.SetActive(false);
    }
}
