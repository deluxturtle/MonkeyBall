using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinVolume : MonoBehaviour {

    public GameObject victoryText;
    public GameObject outOfTimeText;
    public GameObject monkeyBall;

    public Text timer;
    public float timeLimit = 60f;

    private bool countDown = true;
    ScriptAnalytics analytic;

	// Use this for initialization
	void Awake ()
    {
        victoryText.SetActive(false);
        outOfTimeText.SetActive(false);
        if(GameObject.Find("Analytic"))
            analytic = GameObject.Find("Analytic").GetComponent<ScriptAnalytics>();
        else
        {
            Debug.Log("Analytics Disabled. (Please Start Game from Main Menu.");
            analytic = null;
        }
	}

    void Update()
    {
        if (countDown)
        {
            timeLimit -= Time.deltaTime;
            timer.text = timeLimit.ToString("0.00");
        }

        if(timeLimit <= 0f)
        {
            outOfTimeText.SetActive(true);
            timer.gameObject.SetActive(false);
            monkeyBall.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
            countDown = false;
        }
    }
	
    void MarkEndTime()
    {
        if(analytic != null)
        {
            analytic.SetEndTime();
        }
    }

	void OnTriggerEnter(Collider other)
    {
        if (countDown)
        {
            victoryText.SetActive(true);
        }

        other.attachedRigidbody.isKinematic = true;
        countDown = false;

        //Save our progress.
        if (analytic != null)
        {
            analytic.SetLevelComplete(Application.loadedLevelName);
        }
        else
        {
            Debug.Log("No Progress Saved. Start game from Main Menu Scene!");
        }
    }
}
