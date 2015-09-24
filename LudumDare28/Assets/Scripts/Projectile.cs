using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public enum Dir
	{
		UP,DOWN,LEFT,RIGHT
	};
	
	public float speed = 10f;
	public Dir dir = Dir.UP;
	public Vector3 destination;
	public GameObject lastCollision;
	
	void Start()
	{
		destination = transform.position;
	}
	
	void Update()
	{
		if(transform.position == destination)
		{
			setNextDestination();
		}
		
		transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
	}
	
	public void setNextDestination()
	{
		float x = Mathf.Round(destination.x);
		float z = Mathf.Round(destination.z);
		
		switch(dir)
		{
			case Dir.UP:
				z++;
				break;
			case Dir.DOWN:
				z--;
				break;
			case Dir.LEFT:
				x--;
				break;
			case Dir.RIGHT:
				x++;
				break;
		}
		
		//Debug.Log("destination: " + x + "," + z);
		
		destination = new Vector3(x,1,z);
	}
	
	
	public void destroyProjectile()
	{
		Destroy(gameObject);
	}
}
