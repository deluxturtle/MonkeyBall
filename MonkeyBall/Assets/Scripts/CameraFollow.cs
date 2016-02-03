using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform ball;


	void LateUpdate()
	{
		transform.position = ball.position;
	}
}
