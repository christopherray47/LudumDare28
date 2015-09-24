using UnityEngine;
using System.Collections;

public class ReflectorGUI : MonoBehaviour 
{
	public Texture reflectorBox;
	public Texture reflectorNE;
	public Texture reflectorNW;
	public Texture reflectorSE;
	public Texture reflectorSW;
	
	private GridMouse gridMouse;
	private SoundManager sound;
	
	public bool blockPlaced = false;
	
	void Start()
	{
		gridMouse = GameObject.Find("Grid").GetComponent<GridMouse>();
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	void Update()
	{
		if(blockPlaced && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Z)))
		{
			gridMouse.removePlacedReflector();
			sound.playSelectSound();
		}			
	}
	
	void OnGUI()
	{
		int yOff = (Screen.height) / 2 - 20;
		
		if(blockPlaced)
		{
			if(GUI.Button(new Rect(50,yOff,140,40), "Remove Reflector"))
			{
				gridMouse.removePlacedReflector();
				sound.playSelectSound();
			}
		}
		else
		{
			if(GUI.Button(new Rect(100,yOff,40,40), reflectorBox))
			{
				gridMouse.reflector = GridMouse.Reflector.BOX;
				sound.playSelectSound();
			}
			
			if(GUI.Button(new Rect(150,yOff-50,40,40), reflectorNE))
			{
				gridMouse.reflector = GridMouse.Reflector.NE;
				sound.playSelectSound();
			}
			
			if(GUI.Button(new Rect(50,yOff-50,40,40), reflectorNW))
			{
				gridMouse.reflector = GridMouse.Reflector.NW;
				sound.playSelectSound();
			}
			
			if(GUI.Button(new Rect(150,yOff+50,40,40), reflectorSE))
			{
				gridMouse.reflector = GridMouse.Reflector.SE;
				sound.playSelectSound();
			}
			
			if(GUI.Button(new Rect(50,yOff+50,40,40), reflectorSW))
			{
				gridMouse.reflector = GridMouse.Reflector.SW;
				sound.playSelectSound();
			}
		}
	}
}
