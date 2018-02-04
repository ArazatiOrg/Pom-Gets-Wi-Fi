using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    static Credits instance;
    
    public List<GameObject> slides;

	// Use this for initialization
	void Start () {
        instance = this;
	}

    public bool reset = false;

    public float startTime = 2.2f;
    public float offsetTime = 5.55f;
    
    int oldSlide = -1;
	void Update () {
        if(reset)
        {
            AudioController.instance.bgmSource.Stop();
            AudioController.instance.bgmSource.clip = null;

            reset = false;
            StartPlaying();
            return;
        }

        if (AudioController.instance.bgmSource.clip != AudioController.instance.music[(int)BGM.Credits]) return;
        
        var timer = AudioController.instance.bgmSource.time;
        var slide = (int)((timer+startTime)/offsetTime);
        if (slide < 0) slide = 0;

        if (slide != oldSlide)
        {
            if (slide < instance.slides.Count)
                KeepCameraInBounds.instance.objectToFollow = instance.slides[slide];
            
            if(slide == 0 && oldSlide == instance.slides.Count - 1)
            {
                Finished = true;
            }

            oldSlide = slide;
        }

        return;
        if (timer > 0)
        {
            timer -= Time.smoothDeltaTime;

            if (timer < 0) Finished = true;
        }
	}

    public static bool Finished = false;

    public static void StartPlaying()
    {
        instance.oldSlide = -1;
        Finished = false;

        KeepCameraInBounds.instance.objectToFollow = instance.slides[0];
        AudioController.instance.PlayBGM((int)BGM.Credits, .4f, true);
    }

    /*
     3.5

     */
}
