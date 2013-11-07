using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public int lives = 3;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	// TODO - Do something more clever when out of lives
	public void Die()
	{
		lives -= 1;

		if (lives >= 0)
		{
			// You still had lives left, so let's respawn
			gameObject.SendMessage("Respawn");
		}
		else
		{
			// You are out of lives, so you die
			Application.LoadLevel(0);
		}
	}
	
	public void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Lives left: " + lives);
	}
}
