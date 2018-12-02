using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	private AudioSource source;
	[SerializeField] private AudioClip actualLoop;

	void Awake(){
		source = GetComponent<AudioSource>();
	}

	void Update(){
		if(!source.isPlaying){
			source.clip = actualLoop;
			source.Play();
			source.loop = true;
		}
	}
}
