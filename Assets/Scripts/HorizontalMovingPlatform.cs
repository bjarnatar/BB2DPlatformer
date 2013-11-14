using UnityEngine;
using System.Collections;

public class HorizontalMovingPlatform : MonoBehaviour
{
	public float movementSpeed = 5f;
	public float movementAmplitude = 5f;

	private Vector3 originalPosition;
	private Vector3 previousPosition;

	// Use this for initialization
	void Start ()
	{
		originalPosition = transform.position;
		previousPosition = originalPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	void FixedUpdate()
	{
		previousPosition = transform.position;
		transform.position = originalPosition + new Vector3(Mathf.Sin(Time.time * movementSpeed) * movementAmplitude, 0, 0);

	}

	public Vector3 MovementLastFrame()
	{
		return transform.position - previousPosition;
	}
}
