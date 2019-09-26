using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {
	public static SoundSystem instance;
	public AudioSource audioSource;
	public AudioClip click;
	
	private void Awake(){
		if(SoundSystem.instance == null){
			SoundSystem.instance = this;
			// DontDestroyOnLoad(SoundSystem.instance);
			}else if(SoundSystem.instance != this){
			Destroy(gameObject);
		}
	}
	private void OnDestroy(){
		if(SoundSystem.instance == this){
			SoundSystem.instance = null;
		}
	}
	public void PlayClickSound(){
		audioSource.clip = click;
		audioSource.Play();
	}
}
