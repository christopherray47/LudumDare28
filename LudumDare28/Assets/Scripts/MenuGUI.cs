using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour 
{
	private Persist persist;
	private SoundManager sound;
	
	void Start()
	{
		persist = GameObject.Find("Persist").GetComponent<Persist>();
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	void OnGUI()
	{
		float xOffset = (Screen.width/2) - 100;
		
		GUI.Box(new Rect(xOffset-40, 80, 280, 50), "REFLECTOR");
				
		if(GUI.Button(new Rect(xOffset, 140, 200, 30), "Level 1"))
		{				
			sound.playSelectSound();
			persist.loadLevel(1);
		}	
		
		if(GUI.Button(new Rect(xOffset, 180, 200, 30), "Level 2"))
		{				
			sound.playSelectSound();
			persist.loadLevel(2);
		}
		
		if(GUI.Button(new Rect(xOffset, 220, 200, 30), "Level 3"))
		{				
			sound.playSelectSound();
			persist.loadLevel(3);
		}
		
		if(GUI.Button(new Rect(xOffset, 260, 200, 30), "Level 4"))
		{				
			sound.playSelectSound();
			persist.loadLevel(4);
		}
		
		if(GUI.Button(new Rect(xOffset, 300, 200, 30), "Level 5"))
		{				
			sound.playSelectSound();
			persist.loadLevel(5);
		}
		
		if(GUI.Button(new Rect(xOffset, 340, 200, 30), "Level 6"))
		{				
			sound.playSelectSound();
			persist.loadLevel(6);
		}
		
		if(GUI.Button(new Rect(xOffset, 380, 200, 30), "Level 7"))
		{				
			sound.playSelectSound();
			persist.loadLevel(7);
		}
	}
}
