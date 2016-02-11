using UnityEngine;
using System.Collections;

public class ScriptRotateAround : MonoBehaviour {

    [Tooltip("Place the object you want to rotate around.")]
    public Transform toRotateAround;
    public float distance;
    public float rotateSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        distance = Vector3.Distance(transform.position, toRotateAround.position);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(toRotateAround);
        
        transform.Translate(Vector3.right * rotateSpeed * Time.deltaTime );
	}
}
