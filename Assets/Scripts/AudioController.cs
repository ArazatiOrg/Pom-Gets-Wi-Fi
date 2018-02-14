using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> music = new List<AudioClip>();
    public List<AudioClip> sfx = new List<AudioClip>();

    public AudioMixer Mixer;
    public AnimationCurve MixerTransitionFallof;

    public float[,] loopTimes = new float[,]
    {
        { 084.662f, 055.876f }, //village2
        { 000.000f, 000.000f }, //Burning
        { 034.732f, 033.757f }, //memories
        { 151.244f, 149.941f }, //eternal
        { 105.971f, 105.971f }, //field4
        { 266.394f, 228.364f }, //EricSkiff_UnderStars
        { 096.007f, 084.008f }, //mystery3
        { 091.632f, 091.632f }, //castle3
        { 131.315f, 131.315f }, //ending3
        { 098.628f, 096.068f }, //interlude
        { 119.457f, 115.852f }, //mechaBase
        { 133.606f, 117.537f }, //sadness
        { 029.162f, 027.825f }, //shop3
        { 048.613f, 048.111f }, //solace3
        { 000.000f, 000.000f }, //gymnopedieNo1
        { 261.384f, 257.973f }, //forgiveMeGreatSpirit
        { 0f, 0f }, //rain
        { 0f, 0f }, //credits
        { 059.206f, 054.862f }, //gameOver
    };

    float loopAtTime = 0f;
    float rewindTime = 0f;

    // Use this for initialization
    void Start () {
        instance = this;
	}

    private void Update()
    {
        SongTransitionUpdate();
        
        if (loopAtTime > 0f && bgmSource.time > loopAtTime)
        {
            bgmSource.time -= rewindTime;
        }
    }

    int desiredBGM = -2;
    float desiredVolume = -1;
    float oldVolume = -1;
    float percentage = 0f;
    public float bgmTransitionSpeed = 16f;

    void SongTransitionUpdate()
    {
        if (desiredBGM >= -1 && percentage < 1f)
        {
            percentage -= Time.smoothDeltaTime * bgmTransitionSpeed;

            if (percentage <= 0f)
            {
                if (desiredBGM == (int)BGM.NONE)
                {
                    bgmSource.Stop();
                }
                else
                {
                    loopAtTime = loopTimes[desiredBGM, 0];
                    rewindTime = loopTimes[desiredBGM, 1];

                    bgmSource.time = 0f;

                    bgmSource.volume = desiredVolume;
                    bgmSource.clip = music[desiredBGM];
                    bgmSource.loop = desiredBGM != (int)BGM.Credits;
                    bgmSource.Play();

                    //woo hacky stuff via code instead of clipping the actual audio file (removes empty space at the start of the song
                    if (desiredBGM == (int)BGM.Village2) bgmSource.time = 2.20f;
                }

                desiredBGM = -2;
                percentage = 0f;
            }
            
            Mixer.SetFloat("Vol_Music", Mathf.Lerp(-79f, 0f, MixerTransitionFallof.Evaluate(percentage))); //-80db is muted, but it suspends the audio mixer, which we don't want
            //bgmSource.volume = percentage * oldVolume;
        }

        if (desiredBGM == -2 && percentage < 1f)
        {
            percentage += Time.smoothDeltaTime * bgmTransitionSpeed;

            if (percentage >= 1f)
            {
                percentage = 1f;
                Mixer.SetFloat("Vol_Music", 0f); //0f is "0 change in db", which means default volume
                //bgmSource.volume = desiredVolume;
                desiredVolume = -1f;
                oldVolume = -1f;
            }
            else
            {
                Mixer.SetFloat("Vol_Music", Mathf.Lerp(-79f, 0f, MixerTransitionFallof.Evaluate(percentage))); //-80db is muted, but it suspends the audio mixer, which we don't want
                //bgmSource.volume = percentage * desiredVolume;
            }
        }
    }

    public void PlayBGM(int index, float volume, bool restartIfSame = true)
    {
        if (!restartIfSame && bgmSource.clip == music[index]) return;

        if (Global.ActiveSavefile != null)
        {
            Global.s.ActiveBGM.value = index;
            Global.s.ActiveBGMVolume.value = volume;
        }

        desiredBGM = index;
        desiredVolume = volume;
        oldVolume = bgmSource.volume;
        percentage = .99f;

        if (!bgmSource.isPlaying) percentage = 0f;
    }

    public void PlaySFX(int index, float volume, float pitch = 1f)
    {
        var oldPitch = sfxSource.pitch;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(sfx[index],volume);
        sfxSource.pitch = oldPitch;
    }
}
