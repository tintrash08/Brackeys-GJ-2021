using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    private AudioSource musicSource;
    private AudioSource sfxSource;
    private AudioSource sfxLoopSource;

    public void PlayMusic(AudioClip musicClip, float volume = 1f) {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip, float volume = 1f) {
        sfxSource.PlayOneShot(sfxClip, volume);
    }

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
        } else {
            Destroy (gameObject);
        }
    }
}
