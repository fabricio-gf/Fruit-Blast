using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public static SFXManager instance;

	[Header("References")]

	[SerializeField] private AudioSource musicManager;
	private AudioSource source;
	[SerializeField] private AudioClip[] coinSound;
	[SerializeField] private AudioClip[] selectSound;
	[SerializeField] private AudioClip[] deathSound;
	[SerializeField] private AudioClip[] sacrificeSound;
	[SerializeField] private AudioClip launchSound;

	private bool isMuted = false;
	[SerializeField] private UnityEngine.UI.Image muteImage;
	[SerializeField] private Sprite[] muteSprites;
	

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

	public void PlayLaunchSound(){
		source.PlayOneShot(launchSound);
	}

	public void ToggleMute(){
		isMuted = !isMuted;
		musicManager.mute = isMuted;
		source.mute = isMuted;
		if(isMuted){
			muteImage.sprite = muteSprites[1];
		}
		else{
			muteImage.sprite = muteSprites[0];
		}
	}
}
