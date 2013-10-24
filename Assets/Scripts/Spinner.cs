using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{

	public float speed = 10.3f;
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime);	
	}
}
