using UnityEngine;
using System.Collections;

public class ScriptEnablePlat : MonoBehaviour {

    public GameObject platToEnable;

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

	void OnTriggerExit()
    {
        platToEnable.SetActive(true);
        Destroy(gameObject);
    }
}
