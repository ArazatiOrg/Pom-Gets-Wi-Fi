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
        { 105.971f, 105.971f }, //field4
        { 266.394f, 228.364f }, //EricSkiff_UnderStars
        { 096.007f, 084.008f }, //mystery3
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
        if (Global.ActiveSavefile != null)
        {
            Global.s.ActiveBGM.value = index;
            Global.s.ActiveBGMVolume.value = volume;
        }

        if (index == (int)BGM.none)
        {
            bgmSource.Stop();
            return;
        }

        loopAtTime = loopTimes[index, 0];
        rewindTime = loopTimes[index, 1];

        bgmSource.time = 0f;

        bgmSource.volume = volume;
        bgmSource.clip = music[index];
        bgmSource.loop = true;
        bgmSource.Play();

        //woo hacky stuff via code instead of clipping the actual audio file
        if (index == (int)BGM.village2) bgmSource.time = 2.20f;
    }

    public void PlaySFX(int index, float volume)
    {
        sfxSource.PlayOneShot(sfx[index],volume);
    }
}
