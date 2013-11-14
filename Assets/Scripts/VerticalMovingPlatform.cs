using UnityEngine;
using System.Collections;

public class VerticalMovingPlatform : MonoBehaviour
{
	public float movementSpeed = 5f;
	public float movementAmplitude = 5f;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start ()
	{
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate()
	{
		transform.position = originalPosition 
			+ new Vector3(0, Mathf.Sin(Time.time * movementSpeed) * movementAmplitude, 0);
	}
}
