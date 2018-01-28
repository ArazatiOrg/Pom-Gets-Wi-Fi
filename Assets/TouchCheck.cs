using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour {
    public GameObject touchElements;
    bool enabled = false;

    float lastTouch = 5f;
    float touchTimeout = 20f;

	// Update is called once per frame
	void Update () {
        if(lastTouch < 3600f) lastTouch += Time.smoothDeltaTime;

        lastTouch = 0f;
        if (Input.touchCount > 0)
        {
            lastTouch = 0f;
        }

        if(!enabled && lastTouch <= touchTimeout)
        {
            enabled = true;
            touchElements.SetActive(enabled);
        }
        else if(enabled && lastTouch > touchTimeout)
        {
            enabled = false;
            touchElements.SetActive(enabled);
        }
	}
}
