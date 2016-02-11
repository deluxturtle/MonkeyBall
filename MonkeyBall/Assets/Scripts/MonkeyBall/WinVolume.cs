using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinVolume : MonoBehaviour {

    public GameObject victoryText;
    public GameObject outOfTimeText;
    public GameObject monkeyBall;

    public Text timer;
    public float timeLimit = 60f;
    public float totalTime = 0;

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
            totalTime += Time.deltaTime;
            timer.text = timeLimit.ToString("0.00");
        }

        if(timeLimit <= 0f)
        {
            //MarkEndTime(); //Didn't want to record failed attempt times.
            outOfTimeText.SetActive(true);
            timer.gameObject.SetActive(false);
            monkeyBall.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
            countDown = false;
        }
    }
	
    /// <summary>
    /// Tell the analytics script to enter the end time.
    /// </summary>
    void MarkEndTime()
    {
        if(analytic != null)
        {
            analytic.LevelTime(totalTime);
        }
    }

	void OnTriggerEnter(Collider other)
    {
        if (countDown)
        {
            MarkEndTime();
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
