using UnityEngine;
using System.Collections;

public class ScriptShootBall : MonoBehaviour {

    public float force = 15f;
    public Vector3 direction;

	void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = direction.normalized * force;


    }
}
