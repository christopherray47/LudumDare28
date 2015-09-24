using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioClip bump1Sound;
	public AudioClip bump2Sound;
	public AudioClip failSound;
	public AudioClip fireSound;
	public AudioClip selectSound;
	public AudioClip winSound;
	
	private bool bumpNum = true;
	
	public float volume = 0.5f;
	
	public void playBumpSound()
	{
		if(bumpNum)
		{
			AudioSource.PlayClipAtPoint(bump1Sound, Camera.main.transform.position, volume);
		}
		else
		{
			AudioSource.PlayClipAtPoint(bump2Sound, Camera.main.transform.position, volume);
		}
		bumpNum = !bumpNum;
	}
	
	public void playFailSound()
	{
		AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, volume);
	}
	
	public void playFireSound()
	{
		AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, volume);
	}
	
	public void playSelectSound()
	{	
		AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, volume);
	}
	
	public void playWinSound()
	{
		AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, volume);
	}
}
