using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    private AudioSource aSource;
    public AudioClip mainMenuMusic;

	void Start () {
        aSource = GetComponentInChildren<AudioSource>();

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            aSource.loop = true;
            aSource.clip = mainMenuMusic;
            aSource.Play();
        }
        
	}

    public void PlaySound(AudioClip clip)
    {
        aSource.PlayOneShot(clip);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
