using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnim : MonoBehaviour {
    public List<Sprite> sprites = new List<Sprite>();
    public float speed = .4f;

    int index = 0;
    float curSpeed = .4f;

    public SpriteRenderer renderer;
    //263, 285, 308, 324 

    // Update is called once per frame
    void Update () {
        curSpeed -= Time.smoothDeltaTime;

        if(curSpeed <= 0f)
        {
            curSpeed += speed;
            index++;

            if (index >= sprites.Count) index = 0;

            renderer.sprite = sprites[index];
        }
	}
}
