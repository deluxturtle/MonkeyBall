using UnityEngine;
using System.Collections;

public class ScriptShootBall : MonoBehaviour {

    public float force = 15f;

	void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * force;


    }
}
