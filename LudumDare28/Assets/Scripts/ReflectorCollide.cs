using UnityEngine;
using System.Collections;

public class ReflectorCollide : MonoBehaviour 
{
	public Projectile.Dir upDir		= Projectile.Dir.DOWN;
	public Projectile.Dir downDir	= Projectile.Dir.UP;
	public Projectile.Dir leftDir	= Projectile.Dir.RIGHT;
	public Projectile.Dir rightDir	= Projectile.Dir.LEFT;
	
	private Patrol patrolScript;
	private SoundManager sound;
	
	void Start()
	{
		patrolScript = gameObject.GetComponent<Patrol>();
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		Projectile projectileScript = col.gameObject.GetComponent<Projectile>();
		
		if(projectileScript.lastCollision == null || !projectileScript.lastCollision.Equals(gameObject)) 
		{	
			projectileScript.lastCollision = gameObject;
			sound.playBumpSound();
			
			switch(projectileScript.dir)
			{
				case Projectile.Dir.UP:
					projectileScript.dir = upDir;
					if(patrolScript)
					{
						projectileScript.destination.z = transform.position.z;
					}
					break;
				case Projectile.Dir.DOWN:
					projectileScript.dir = downDir;
					if(patrolScript)
					{
						projectileScript.destination.z = transform.position.z;
					}
					break;
				case Projectile.Dir.LEFT:
					projectileScript.dir = leftDir;
					if(patrolScript)
					{
						projectileScript.destination.x = transform.position.x;
					}
					break;
				case Projectile.Dir.RIGHT:
					projectileScript.dir = rightDir;
					if(patrolScript)
					{
						projectileScript.destination.x = transform.position.x;
					}
					break;
			}
		}
	}
}
