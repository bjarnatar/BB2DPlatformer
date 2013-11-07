using UnityEngine;
using System.Collections;

public class BaddieAttack : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (collision.transform.position.y - transform.position.y > 0.8f)
			{ // Player wins, I die
				Destroy(gameObject);
			}
			else
			{
				collision.gameObject.SendMessage("Die");
			}
		}
		
		
	}
}
