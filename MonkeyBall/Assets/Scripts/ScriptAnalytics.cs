using UnityEngine;
using System.Collections;

public class ScriptAnalytics : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}

    void Start()
    {

    }
	
	// Update is called once per frame
	void OnLevelWasLoaded()
    {
        Debug.Log(Application.loadedLevelName);
    }
}
