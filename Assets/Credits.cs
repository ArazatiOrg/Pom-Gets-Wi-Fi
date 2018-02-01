using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    static Credits instance;

    public GameObject creditsObject;

	// Use this for initialization
	void Start () {
        instance = this;
	}

    float timer = 0f;
	void Update () {
        if (timer > 0)
        {
            timer -= Time.smoothDeltaTime;

            if (timer < 0) Finished = true;
        }
	}

    public static bool Finished = false;

    public static void StartPlaying()
    {
        instance.timer = 15f;

        KeepCameraInBounds.instance.objectToFollow = instance.creditsObject;
    }
}
