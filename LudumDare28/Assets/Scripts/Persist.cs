using UnityEngine;
using System.Collections;

public class Persist : MonoBehaviour 
{
	int currentLevel = 0;
	public int maxLevel = 7;
	
	private static bool created = false;
	
	// Use this for initialization
	void Awake () 
	{		
		if(!created)
		{
			DontDestroyOnLoad(gameObject);
			created = true;
		}
		else
		{
			Destroy (this.gameObject);
		}
	}
	
	void OnGUI()
	{
		if(currentLevel != 0)
		{
			GUI.Box(new Rect(50, (Screen.height / 2) - 210, 140, 40), "REFLECTOR\nLevel: " + currentLevel);
			
			if(GUI.Button(new Rect(50, (Screen.height / 2) - 140, 140, 40), "Back to Menu"))
			{
				loadMenu();
			}
		}
	}
	
	public void loadLevel(int level)
	{
		//Debug.Log(currentLevel + " " + level);
		
		currentLevel = level;
		
		if(currentLevel <= maxLevel)
		{			
			Application.LoadLevel("Level" + currentLevel);
		}
		else
		{
			loadMenu();
		}
	}
	
	public void loadNextLevel()
	{
		loadLevel(currentLevel+1);
	}
	
	private void loadMenu()
	{
		currentLevel = 0;
		Application.LoadLevel("Menu");
	}
}
