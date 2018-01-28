using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    public static InputController instance;

    public Image gameCanvas;

	// Use this for initialization
	void Start () {
        instance = this;

        for (int i = 0; i < (int)Action.COUNT; i++)
        {
            curJustPressed.Add(false);
            curIsDown.Add(false);
        }

        Input.simulateMouseWithTouches = false;

        
    }
    
    List<bool> curJustPressed = new List<bool>();
    List<bool> curIsDown = new List<bool>();

    Touch[] lastTouches = new Touch[0];
    Touch? lastMoveTouch = null;

    Vector2 startClick = Vector2.zero;

    Vector2 lastMousePos = Vector2.zero;
    bool lastMousePressed = false;

    // Update is called once per frame
    void Update () {
        var curTouches = Input.touches;
        var curMouse = ScreenToPercentage(Input.mousePosition);
        var curMousePressed = Input.GetMouseButton(0) || //left click
                              Input.GetMouseButton(1);   //right click

        if (curMousePressed && !lastMousePressed) startClick = curMouse;

        Vector2 averageRightTouchPos = Vector2.zero;
        float rightTouches = 0f;
        
        //sort touches
        foreach (var touch in curTouches)
        {
            var percentage = ScreenToPercentage(touch.position);
            if (percentage.x > 0)
            {
                if (touch.phase != TouchPhase.Ended)
                {
                    rightTouches++;
                    averageRightTouchPos += percentage;
                }
            }
            else
            {
                if(lastMoveTouch == null && touch.phase == TouchPhase.Began)
                {
                    startClick = percentage;
                    lastMoveTouch = touch;
                }
                else if(touch.fingerId == lastMoveTouch.Value.fingerId)
                {
                    lastMoveTouch = touch;

                    if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
                        lastMoveTouch = null;
                }
            }
        }

        //TODO: Re-look at all the touch stuff, it seems to be fairly glitchy.
        //look up how people normally do it

        if (Input.touchCount == 0) lastMoveTouch = null;

        if(rightTouches > 0)
        {
            curMouse = averageRightTouchPos / rightTouches;
            curMousePressed = true;
        }

        SpriteDir dirPressed = SpriteDir.None;
        Vector2? diff = null;
        var minMoveDistance = .1f;

        if (curMousePressed && lastMousePressed && startClick.x < 0)
        {
            diff = curMouse - startClick;
        }
        else if (lastMoveTouch != null)
        {
            diff = ScreenToPercentage(lastMoveTouch.Value.position) - startClick;
        }
        
        if (diff != null && diff.Value.magnitude > minMoveDistance)
        {
            var absPercentages = new Vector2(Mathf.Abs(diff.Value.x), Mathf.Abs(diff.Value.y));

            if (absPercentages.x > absPercentages.y)
            {
                if (diff.Value.x > 0f) dirPressed = SpriteDir.Right;
                else dirPressed = SpriteDir.Left;
            }
            else
            {
                if (diff.Value.y > 0f) dirPressed = SpriteDir.Up;
                else dirPressed = SpriteDir.Down;
            }
        }

        var maxCount = (int)Action.COUNT;
        for (int i = 0; i < maxCount; i++)
        {
            var lastDown = curIsDown[i];
            var curDown = false;
            
            switch ((Action)i)
            {
                case Action.Cancel:
                    curDown = Input.GetKey(KeyCode.Escape) ||
                              Input.GetKey(KeyCode.X) ||
                              (curMousePressed && !lastMousePressed && curMouse.x > 0 && curMouse.y > 0);
                    break;
                case Action.Confirm:
                    curDown = Input.GetKey(KeyCode.Return) ||
                              Input.GetKey(KeyCode.Z) ||
                              (curMousePressed && !lastMousePressed && curMouse.x>0 && curMouse.y < 0);
                    break;
                case Action.Up:
                    curDown = Input.GetKey(KeyCode.UpArrow) ||
                              Input.GetKey(KeyCode.W) ||
                              dirPressed == SpriteDir.Up;
                    break;
                case Action.Down:
                    curDown = Input.GetKey(KeyCode.DownArrow) ||
                              Input.GetKey(KeyCode.S) ||
                              dirPressed == SpriteDir.Down;
                    break;
                case Action.Left:
                    curDown = Input.GetKey(KeyCode.LeftArrow) ||
                              Input.GetKey(KeyCode.A) ||
                              dirPressed == SpriteDir.Left;
                    break;
                case Action.Right:
                    curDown = Input.GetKey(KeyCode.RightArrow) ||
                              Input.GetKey(KeyCode.D) ||
                              dirPressed == SpriteDir.Right;
                    break;
                case Action.Any:
                    curDown = Input.anyKey || Input.touchCount > 0;
                    break;
                case Action.DEBUG_SaveState:
                    curDown = Input.GetKey(KeyCode.PageUp);
                    break;
            }

            curIsDown[i] = curDown;
            curJustPressed[i] = !lastDown && curDown;
        }

        lastTouches = curTouches;
        lastMousePos = curMouse;
        lastMousePressed = curMousePressed;
    }

    Vector2 ScreenToPercentage(Vector2 pos)
    {
        return new Vector2((pos.x / Screen.width * 2f) - 1f, (pos.y / Screen.height * 2f) - 1f);
    }

    Vector2 ScreenToWorld(Vector2 screenPos)
    {
        var pos = ScreenToPercentage(screenPos);
        pos.x = pos.x * 20f - 10f; //adjust for game canvas size and pixels-per-unit
        pos.y = pos.y * 15f - 7.5f;
        var multiplier = new Vector2(Screen.width / (gameCanvas.rectTransform.sizeDelta.x * gameCanvas.rectTransform.lossyScale.x),
                                      Screen.height / (gameCanvas.rectTransform.sizeDelta.y * gameCanvas.rectTransform.lossyScale.y));
        pos.x = pos.x * multiplier.x; //adjust for dynamic window resizing
        pos.y = pos.y * multiplier.y;
        pos.x = pos.x + Camera.main.transform.position.x; //adjust for camera position in world
        pos.y = pos.y + Camera.main.transform.position.y;

        return Vector2.zero;
    }

    public static bool JustPressed(Action action)
    {
        return instance.curJustPressed[(int)action];
    }

    public static bool IsDown(Action action)
    {
        return instance.curIsDown[(int)action];
    }
}

public enum Action
{
    Confirm,
    Cancel,
    Up,
    Down,
    Left,
    Right,
    Any,
    DEBUG_SaveState,
    COUNT
}
