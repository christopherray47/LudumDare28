using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour 
{
	public Projectile.Dir upDir		= Projectile.Dir.DOWN;
	public Projectile.Dir downDir	= Projectile.Dir.UP;
	public Projectile.Dir leftDir	= Projectile.Dir.RIGHT;
	public Projectile.Dir rightDir	= Projectile.Dir.LEFT;
	
	public float maxX = 0;
	public float minX = 0;
	public float maxZ = 0;
	public float minZ = 0;
	
	public float speed = 2.5f;
	public Projectile.Dir dir = Projectile.Dir.UP;
	public Vector3 destination;
	
	void Start()
	{
		destination = transform.position;
	}
	
	void Update()
	{
		if(transform.position == destination)
		{
			if(transform.position.x >= maxX)
			{
				dir = rightDir;
			}
			else if(transform.position.x <= minX)
			{
				dir = leftDir;
			}
			else if(transform.position.z >= maxZ)
			{
				dir = upDir;
			}
			else if(transform.position.z <= minZ)
			{
				dir = downDir;
			}
			
			setNextDestination();
		}
		
		transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
	}
	
	private void setNextDestination()
	{
		float x = Mathf.Round(destination.x);
		float z = Mathf.Round(destination.z);
		
		switch(dir)
		{
			case Projectile.Dir.UP:
				z++;
				break;
			case Projectile.Dir.DOWN:
				z--;
				break;
			case Projectile.Dir.LEFT:
				x--;
				break;
			case Projectile.Dir.RIGHT:
				x++;
				break;
		}
		
		//Debug.Log("destination: " + x + "," + z);
		
		destination = new Vector3(x,1,z);
	}
}
