using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    static GameOver instance;

    public GameObject gameOverScreenObject;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    float timer = 0f;
    void Update()
    {
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
        instance.timer = 15f;
        Finished = false;

        instance.StartCoroutine(instance.GameOverPlay());
        //KeepCameraInBounds.instance.objectToFollow = instance.gameOverScreenObject;
    }

    IEnumerator GameOverPlay()
    {
        yield return EventWait.c(1f).Execute();
        yield return EventFade.c(1f).Execute();

        KeepCameraInBounds.instance.objectToFollow = instance.gameOverScreenObject;
        yield return EventBGM.c(BGM.GameOver, .4f).Execute();

        yield return EventFade.c(-.4f).Execute();

        yield return new WaitUntil(() => InputController.JustPressed(Action.Any));

        yield return EventFade.c(2f).Execute();

        yield return EventBGM.c(BGM.NONE).Execute();
        yield return EventWait.c(.2f).Execute();

        //KeepCameraInBounds.instance.objectToFollow = WorldspaceUI.instance.MainMenu_Selected.transform.parent.gameObject;
        
        Global.ResetLevel();
    }
}
