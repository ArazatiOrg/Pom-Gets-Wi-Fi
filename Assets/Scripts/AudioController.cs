using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> sfx = new List<AudioClip>();

    public float[,] loopTimes = new float[,]
    {
        { 084.662f, 055.876f }, //village2
        { 000.000f, 000.000f }, //Burning
        { 034.732f, 033.757f }, //memories
        { 151.244f, 149.941f }, //eternal
    };

    float loopAtTime = 0f;
    float rewindTime = 0f;

    // Use this for initialization
    void Start () {
        instance = this;
	}

    private void Update()
    {
        if (loopAtTime > 0f && bgmSource.time > loopAtTime)
        {
            bgmSource.time -= rewindTime;
        }
    }

    public void PlayBGM(int index, float volume)
    {
        loopAtTime = loopTimes[index, 0];
        rewindTime = loopTimes[index, 1];

        bgmSource.time = 0f;

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
