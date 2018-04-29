using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloopRandomizer : MonoBehaviour {
	public AudioSource src;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void PlayRandomBloop ()
	{
		int checker = Random.Range (1, 4);
		if (checker == 1) 
		{
			src.clip = clip1;
		}
		if (checker == 2) 
		{
			src.clip = clip2;
		}
		if (checker == 3) 
		{
			src.clip = clip3;
		}
		src.Play();
	}
}
