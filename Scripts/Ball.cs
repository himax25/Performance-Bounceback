using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{

	// Use this for initialization
	public Rigidbody rigidbody;
	private Vector3 vector3_init = Vector3.zero;
	public bool ballStopped = true;
	private float currentSpeed = 0;
	private float minmumSpeed = 1.0f;

	void Awake() 
	{
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(rigidbody.isKinematic == false)
		{
			currentSpeed = rigidbody.velocity.magnitude;
			if(currentSpeed < minmumSpeed && ballStopped == false)
			{
				ballStopped = true;
			}
			else if (currentSpeed >= minmumSpeed && ballStopped)
			{
				ballStopped = false;
			}
		}
		else if(ballStopped)
		{
			ballStopped = false;
		}
	}
	public void Activate(Vector3 setPosition)
	{
		rigidbody.velocity = vector3_init;
		rigidbody.angularVelocity = vector3_init;
		transform.position = setPosition;
		gameObject.SetActive(true);
		ballStopped = false;
	}
}
