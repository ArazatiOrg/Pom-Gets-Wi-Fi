using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventFade : _BaseLogicEvent {
    float time = .1f;
    Color col = Color.black;
    bool noYield = false;

    public static EventFade c(float time, Color? col = null)
    {
        if (col == null) col = Color.black;

        return new EventFade() { time = time, col = col.Value };
    }

    public EventFade NoYield { get { noYield = true; return this; } }

    public override IEnumerator Execute()
    {
        var cameraFader = Camera.main.GetComponentInChildren<CameraFader>();

        var beforeColor = cameraFader.col;
        cameraFader.col = col;
        var beforeSpeed = cameraFader.fadeSpeed;
        cameraFader.fadeSpeed = time == 0 ? 0f : (1f / Mathf.Abs(time));

        if (time > 0f)
        {
            cameraFader.StartFading();

            if(!noYield)
                yield return new WaitUntil(() => cameraFader.finishedFading);
        }
        else if(time < 0f)
        {
            cameraFader.StartUnfading();

            if (!noYield)
                yield return new WaitUntil(() => cameraFader.finishedFading);
        }
        else
        {
            cameraFader.fadePercentage = 1f;
            cameraFader.fadeToDark = col.a > .01f;
            cameraFader.finishedFading = false;
        }

        if (!noYield)
        {
            cameraFader.col = beforeColor;
            cameraFader.fadeSpeed = beforeSpeed;
        }

        yield return null;
    }

}
