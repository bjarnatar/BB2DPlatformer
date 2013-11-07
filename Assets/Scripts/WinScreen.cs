using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour
{
	public float buttonWidth = 100f;
	public float buttonHeight = 30f;
	public float buttonYDistanceFromBottom = 100f;
	public string levelToLoad = "CubeScene";
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width * 0.5f - buttonWidth * 0.5f, 
			Screen.height - buttonYDistanceFromBottom, buttonWidth, buttonHeight), "Play Again!"))
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
