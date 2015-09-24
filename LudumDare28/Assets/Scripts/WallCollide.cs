using UnityEngine;
using System.Collections;

public class WallCollide : MonoBehaviour 
{
	private SoundManager sound;
	
	void Start()
	{
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		//Debug.Log ("Hit Wall");
		
		Projectile projectileScript = col.gameObject.GetComponent<Projectile>();
		
		if(projectileScript) 
		{
			projectileScript.destroyProjectile();
		}
		
		FireCannon cannonScript = GameObject.Find("Cannon").GetComponent<FireCannon>();
		
		if(cannonScript) 
		{
			cannonScript.charged = true;
		}
		
		sound.playFailSound();
	}
}
