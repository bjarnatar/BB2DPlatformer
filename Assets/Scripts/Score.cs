using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	private int score = 0;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void AddScore(int points)
	{
		score += points;
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect(Screen.width - 100, 10, 80, 20), "Score: " + score);
	}
}
