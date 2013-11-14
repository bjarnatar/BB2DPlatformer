using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	public int score = 10;
	public float rotationSpeed = 100f; // Degrees pr second
	public ParticleSystem pickupParticleEffect;
	public AudioClip pickupSound;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed, Space.World);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.SendMessage("AddScore", score);
			if (pickupParticleEffect != null)
			{
				GameObject.Instantiate(pickupParticleEffect, transform.position, Quaternion.identity);
			}

			AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);

			Destroy(gameObject);
		}
	}

}
