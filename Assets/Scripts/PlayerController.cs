using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10.3f; // Speed in metres per second
	public float jumpForce = 100.0f;
	public float jumpCollisionTolerance = 0.1f;
	public float nearWallTolerance = 0.5f;
	public float wallJumpSidewaysForce = 30.0f;
	public int airJumpsAllowed = 1;
	
	private int airJumpCount = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	void FixedUpdate()
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
	}
	
	void Update()
	{
		if (IsGrounded())
		{
			airJumpCount = 0;
		}	
		
		// Jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (IsGrounded() || NearWallDirection() != 0)
			{
				rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				airJumpCount = 0;
			}
			else if (airJumpCount < airJumpsAllowed)
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				airJumpCount++;
			}		
			
			// Add force in the opposite direction to where the wall is
			rigidbody.AddForce(Vector3.left * NearWallDirection() * wallJumpSidewaysForce, ForceMode.Impulse);
		}

	}
	
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + jumpCollisionTolerance);
	}
	
	// Returns -1 if near left wall, +1 if near right wall, 0 if not near a wall
	int NearWallDirection()
	{
		if (Physics.Raycast(transform.position, Vector3.left, collider.bounds.extents.x + nearWallTolerance))
		{
			return -1;
		}
		if (Physics.Raycast(transform.position, Vector3.right, collider.bounds.extents.x + nearWallTolerance))
		{
			return 1;
		}
		return 0; //@bjarnatar
	}
}
