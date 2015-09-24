using UnityEngine;
using System.Collections;

public class TargetCollide : MonoBehaviour 
{
	private Persist persist;
	private SoundManager sound;
	
	void Start()
	{
		persist = GameObject.Find("Persist").GetComponent<Persist>();
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	void OnTriggerEnter()
	{
		//Debug.Log("Hit Target");
		
		sound.playWinSound();
		StartCoroutine(nextLevel());
	}
	
	private IEnumerator nextLevel()
	{
		yield return new WaitForSeconds(1);
		persist.loadNextLevel();
	}
}
