using UnityEngine;
using System.Collections;

public class BaddieMovement : MonoBehaviour
{
	public int movementDirection = -1;
	public float movementSpeed = 5.0f;
	public float lookDownDistance = 1.0f;
	public float groundedTolerance = 0.1f;
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void FixedUpdate()
	{
		if (IsDropAheadWrittenNicely())
		{
			movementDirection = movementDirection * -1; // Can also be written as movementDirection *= -1;
		}

		transform.Translate(movementDirection * movementSpeed * Time.fixedDeltaTime, 0, 0, Space.World);
	}
	
	bool IsDropAhead()
	{
		return !Physics.Raycast(transform.position + new Vector3((collider.bounds.extents.x * movementDirection), 0, 0),
			Vector3.down, collider.bounds.extents.y + lookDownDistance);
	}
	
	bool IsDropAheadWrittenNicely()
	{
		Vector3 lookFromPosition = transform.position;
		lookFromPosition += new Vector3((collider.bounds.extents.x * movementDirection), 0, 0);
		
		float lookDownRayLength = collider.bounds.extents.y + lookDownDistance;
		
		if (Physics.Raycast (lookFromPosition, Vector3.down, lookDownRayLength))
		{
			return false; // The ray hit something, so we do not have a drop ahead
		}
		else
		{
			return true; // The ray did not hit something, we do indeed have a drop ahead
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			transform.parent = collision.gameObject.transform;
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			transform.parent = null;
		}
	}

}
