using UnityEngine;
using System.Collections;

public class BananaTouch : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        //Make sure you ALWAYS have a touch before trying to compute touches
	    if(Input.touchCount <= 0)
        {
            return;
        }

        foreach(Touch next in Input.touches)
        {
            if(next.phase == TouchPhase.Began)
            {
                //Moved - move the finger over the screen
                //Stationary -- holding the finger
                //Ended - self ex
                //canceled - error
                RaycastHit hit;
                Ray touchRay = Camera.main.ScreenPointToRay(next.position);

                if(Physics.Raycast(touchRay, out hit))
                {
                    if(hit.transform.parent != null)
                        hit.transform.parent.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}
}
