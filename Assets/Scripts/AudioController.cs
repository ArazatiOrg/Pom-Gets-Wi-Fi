using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> sfx = new List<AudioClip>();

    // Use this for initialization
    void Start () {
        instance = this;
	}

    public void PlayBGM(int index, float volume)
    {
        bgmSource.volume = volume;
        bgmSource.clip = music[index];
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySFX(int index, float volume)
    {
        sfxSource.PlayOneShot(sfx[index],volume);
    }
}
