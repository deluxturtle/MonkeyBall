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
        analytic = GameObject.Find("Analytic").GetComponent<ScriptAnalytics>();
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
        if (GameObject.Find("Analytic"))
        {
            ScriptAnalytics analytic = GameObject.Find("Analytic").GetComponent<ScriptAnalytics>();
            analytic.SetLevelComplete(Application.loadedLevelName);
        }
        else
        {
            Debug.Log("No Progress Saved. Start game from Main Menu Scene!");
        }
    }
}
