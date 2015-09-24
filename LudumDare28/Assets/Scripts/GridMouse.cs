using UnityEngine;
using System.Collections;

public class GridMouse : MonoBehaviour 
{
	public GameObject reflectorPrefabBox;
	public GameObject reflectorPrefabNE;
	public GameObject reflectorPrefabNW;
	public GameObject reflectorPrefabSE;
	public GameObject reflectorPrefabSW;
	
	public enum Reflector
	{
		NONE, BOX, NE, NW, SE, SW
	};
	
	public Reflector reflector = Reflector.NONE;
	
	private GameObject placedReflector;
	private GameObject placedHighlight;
	private SoundManager sound;
	
	private ReflectorGUI refGui;
	
	void Start()
	{
		refGui = GameObject.Find("ReflectorGUI").GetComponent<ReflectorGUI>();
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (reflector != Reflector.NONE)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
				
			if(collider.Raycast(ray, out hitInfo, Mathf.Infinity))
			{
				float x = Mathf.Round(hitInfo.point.x);
				float z = Mathf.Round(hitInfo.point.z);
				
				Vector3 newPos = new Vector3(x, 1, z);
				
				if(!placedHighlight)
				{					
					//placedHighlight = Instantiate(highlightPrefab, newPos, Quaternion.identity) as GameObject;
					
					switch(reflector)
					{
						case Reflector.BOX:
							placedHighlight = Instantiate(reflectorPrefabBox, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
							break;
						case Reflector.NE:
							placedHighlight = Instantiate(reflectorPrefabNE, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
							break;
						case Reflector.NW:
							placedHighlight = Instantiate(reflectorPrefabNW, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
							break;
						case Reflector.SE:
							placedHighlight = Instantiate(reflectorPrefabSE, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
							break;
						case Reflector.SW:
							placedHighlight = Instantiate(reflectorPrefabSW, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
							break;
					}
				}
				else if(placedHighlight.transform.position != newPos)
				{
					placedHighlight.transform.position = newPos;
				}					
			}
			else
			{
				removePlacedHighlight();
			}
			
			if(Input.GetKeyDown(KeyCode.Mouse0))
			{
				//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//RaycastHit hitInfo;
				
				if(collider.Raycast(ray, out hitInfo, Mathf.Infinity))
				{
					placeReflector(hitInfo.point);
				}
			}
			else if (reflector != Reflector.NONE && Input.GetKeyDown(KeyCode.Mouse1))
			{
				reflector = Reflector.NONE;
			}
		}
	}
	
	private void placeReflector(Vector3 point)
	{
		float x = Mathf.Round(point.x);
		float z = Mathf.Round(point.z);
		
		switch(reflector)
		{
			case Reflector.BOX:
				placedReflector = Instantiate(reflectorPrefabBox, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
				break;
			case Reflector.NE:
				placedReflector = Instantiate(reflectorPrefabNE, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
				break;
			case Reflector.NW:
				placedReflector = Instantiate(reflectorPrefabNW, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
				break;
			case Reflector.SE:
				placedReflector = Instantiate(reflectorPrefabSE, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
				break;
			case Reflector.SW:
				placedReflector = Instantiate(reflectorPrefabSW, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
				break;
		}
		
		sound.playSelectSound();
		refGui.blockPlaced = true;
		reflector = Reflector.NONE;
		removePlacedHighlight();
	}
	
	public void removePlacedReflector()
	{
		GameObject.Destroy(placedReflector);
		placedReflector = null;
		refGui.blockPlaced = false;
	}
	
	private void removePlacedHighlight()
	{
		GameObject.Destroy(placedHighlight);
			placedHighlight = null;
	}
}
