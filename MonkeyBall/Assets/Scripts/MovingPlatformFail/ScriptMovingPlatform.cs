using UnityEngine;
using System.Collections;

public class ScriptMovingPlatform : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            other.transform.GetComponent<ScriptMoveWithPlatform>().onPlatform = true;
            other.transform.GetComponent<ScriptMoveWithPlatform>().platform = transform;
            other.transform.GetComponent<ScriptMoveWithPlatform>().SetOnPlatform();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetComponent<ScriptMoveWithPlatform>().onPlatform = false;
            other.transform.GetComponent<ScriptMoveWithPlatform>().platform = null;
            other.transform.GetComponent<ScriptMoveWithPlatform>().SetOnPlatform();
        }
    }
}
