using UnityEngine;
using System.Collections;

public class BaddieAttack : MonoBehaviour
{
	public int killScore = 10; // Score this baddie gives when killed

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
				collision.gameObject.SendMessage("AddScore", killScore);
			}
			else
			{
				collision.gameObject.SendMessage("Die");
			}
		}
		
		
	}
}
