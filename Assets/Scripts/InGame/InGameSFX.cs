using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSFX : MonoBehaviour {

	public static InGameSFX instance;

	[Header("References")]
	private AudioSource source;
	[SerializeField] private AudioClip[] coinSound;
	[SerializeField] private AudioClip[] selectSound;
	[SerializeField] private AudioClip[] deathSound;
	[SerializeField] private AudioClip[] sacrificeSound;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(this);
		}
		source = GetComponent<AudioSource>();
	}

	public void PlayCoinSound(){
		source.PlayOneShot(coinSound[Random.Range(0, coinSound.Length)]);
	}

	public void PlaySelectSound(){
		source.PlayOneShot(selectSound[Random.Range(0, selectSound.Length)]);
	}

	public void PlayDeathSound(){
		source.PlayOneShot(deathSound[Random.Range(0, deathSound.Length)]);
	}

	public void PlaySacrificeSound(){
		source.PlayOneShot(sacrificeSound[Random.Range(0, sacrificeSound.Length)]);
	}
}
