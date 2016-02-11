using UnityEngine;
using System.Collections;

public class BananaBounce : MonoBehaviour {

    public float bobSpeed = 1.5f;
    public float bobHeight = 0.75f;
    public float spinSpeed = 180f;

    public Transform bobber;

    bool collideInstedOfTouch = false;

    public int health = 3;
    public float divider = 2f;
    public int worth = 1;

    GameObject panelBanana;

    void Start()
    {
        panelBanana = GameObject.Find("PanelBanana");
    }

	// Update is called once per frame
	void Update () {
	    if(bobber != null)
        {
            float newPos = Mathf.PingPong(Time.time * bobSpeed, bobHeight);
            bobber.localPosition = Vector3.up * newPos;
        }

        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
	}

    public void Touched()
    {
        health--;
        bobSpeed /= divider;
        spinSpeed /= divider;

        if(health <= 0)
        {
            panelBanana.GetComponent<ScriptAddBanana>().IncreaseBanana(worth);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (collideInstedOfTouch)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
