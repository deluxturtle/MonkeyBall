using UnityEngine;
using System.Collections;

public class MonkeyBall : MonoBehaviour {
	public Rigidbody body;
	public float minTilt = 5f;
	public float sensitivity = 1f;

	public Transform monkeyPivot;
	public float monkeyLookSpeed = 10f;

	private Vector3 totalRotation = Vector3.zero;

	void Awake()
	{
        Input.gyro.enabled = true;
        Debug.Log(SystemInfo.supportsGyroscope);
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 rotation = Input.gyro.rotationRate * Mathf.Rad2Deg;

		if(Mathf.Abs(rotation.x) < minTilt)
		   rotation.x = 0f;

		if(Mathf.Abs(rotation.y) < minTilt)
			rotation.y = 0f;

		if(Mathf.Abs(rotation.z) < minTilt)
			rotation.z = 0f;

		totalRotation += new Vector3 (-rotation.x, rotation.z, -rotation.y) * Time.deltaTime;
	}

	void LateUpdate()
	{
		if (monkeyPivot != null) 
		{
			//Which direction is the ball moving
			Vector3 velocity = body.velocity;
			//Zero out the y so monkey does look up and down
			velocity.y = 0f;

			//Determine direction monkey is facing
			Vector3 forward = monkeyPivot.forward;
			forward.y = 0f;

			//Frame-Rate Independent
			float step = monkeyLookSpeed * Time.deltaTime;

			//Rotate the monkey in the new direction
			//Vector3.RotateTowards(current facing, desire movement, speed, ignore this);
			Vector3 newFacing = Vector3.RotateTowards (forward, velocity, step, 0f);

			monkeyPivot.rotation = Quaternion.LookRotation (newFacing);
		}

	}

	void FixedUpdate()
	{
		body.AddTorque (totalRotation * sensitivity);
	}
}
