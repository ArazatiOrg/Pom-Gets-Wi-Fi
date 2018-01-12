using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventFlashScreen : _BaseLogicEvent {
    float time = .1f;
    Color col = Color.white;

    public static EventFlashScreen c(float time, Color? col = null)
    {
        if (col == null) col = Color.white;

        return new EventFlashScreen() { time = time, col = col.Value };
    }

    public override IEnumerator Execute()
    {
        var cameraFader = Camera.main.GetComponentInChildren<CameraFader>();

        var beforeColor = cameraFader.col;
        cameraFader.col = col;
        var beforeSpeed = cameraFader.fadeSpeed;
        cameraFader.fadeSpeed = time <= 0f ? 0f : (1f / time);

        if (time > 0f)
        {
            cameraFader.StartUnfading();

            yield return new WaitUntil(() => cameraFader.finishedFading);
        }
        else
        {
            cameraFader.fadePercentage = 1f;
            cameraFader.fadeToDark = col.a > .01f;
            cameraFader.finishedFading = false;
        }
        
        cameraFader.col = beforeColor;
        cameraFader.fadeSpeed = beforeSpeed;

        yield return null;
    }

}
