using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10.3f; // Speed in metres per second
	public float jumpForce = 100.0f;
	public float jumpCollisionTolerance = 0.1f;
	public float nearWallTolerance = 0.5f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Sideways movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(speed * Time.deltaTime, 0, 0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) // The else means right arrow takes priority if both are pressed
		{
			transform.Translate(-speed * Time.deltaTime, 0, 0);
		}
		
		// Jump
		// If the user pressed space AND the player is grounded or near a wall - THEN Jump
		if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || IsNearWall()))
		{
			rigidbody.AddForce(Vector3.up * jumpForce);				
		}
	}
	
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + jumpCollisionTolerance);
	}
	
	bool IsNearWall()
	{
		if (Physics.Raycast(transform.position, Vector3.left, collider.bounds.extents.x + nearWallTolerance))
		{
			return true;
		}
		if (Physics.Raycast(transform.position, Vector3.right, collider.bounds.extents.x + nearWallTolerance))
		{
			return true;
		}
		return false; //@bjarnatar
	}
}
