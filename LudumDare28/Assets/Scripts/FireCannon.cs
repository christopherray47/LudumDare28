using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour 
{
	public GameObject projectilePrefab;
	
	public bool charged = true;
	
	private GameObject projectile;
	private SoundManager sound;
	
	// Use this for initialization
	void Start () 
	{
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(charged)
			{
				spawnProjectile();
			}
			else
			{
				destroyProjectile();
			}
		}
	}
	
	void spawnProjectile()
	{
		charged = false;
		sound.playFireSound();
		projectile = Instantiate(projectilePrefab, new Vector3(transform.position.x, 1, transform.position.z + 1.5f), Quaternion.identity) as GameObject;
	}
	
	void destroyProjectile()
	{
		Projectile projectileScript = projectile.GetComponent<Projectile>();
		
		if(projectileScript) 
		{
			projectileScript.destroyProjectile();
			projectile = null;
		}
		
		sound.playFailSound();
		charged = true;
	}
	
	void OnGUI()
	{
		if(charged)
		{
			if(GUI.Button(new Rect(50, (Screen.height / 2) + 100,140,40), "Fire"))
			{
				spawnProjectile();
			}
		}
		else
		{
			if(GUI.Button(new Rect(50, (Screen.height / 2) + 100,140,40), "Abort"))
			{
				destroyProjectile();
			}
		}
	}
}
