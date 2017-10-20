using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource source;

	void Start ()
	{
		source = GetComponent<AudioSource>();
		source.Play();
	}

	void Update()
	{
		if (PlayerPrefs.GetInt("sound_on") == 1)
		{
			source.volume = 1;
		}
		else
		{
			source.volume = 0;
		}
	}
}
