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

	// Use this for initialization
	void Awake ()
    {
        victoryText.SetActive(false);
        outOfTimeText.SetActive(false);
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
	

	void OnTriggerEnter(Collider other)
    {
        if (countDown)
        {
            victoryText.SetActive(true);
        }

        other.attachedRigidbody.isKinematic = true;
        countDown = false;
    }
}
