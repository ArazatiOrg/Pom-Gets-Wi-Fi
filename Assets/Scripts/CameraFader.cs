using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFader : MonoBehaviour {
	public float fadeSpeed = 1f;
	public bool finishedFading = true;

	public bool fadeToDark = true;
	public float fadePercentage = 0f;

	SpriteRenderer spriteRenderer;
    public Color col = Color.black;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public void StartFading()
	{
		fadePercentage = 0f;
		fadeToDark = true;
		finishedFading = false;
	}

	public void StartUnfading()
	{
		fadePercentage = 0f;
		fadeToDark = false;
		finishedFading = false;
	}

	void Update () {
		if(!finishedFading)
		{
			fadePercentage += Time.smoothDeltaTime * fadeSpeed;

			if(fadePercentage >= 1f)
			{
				fadePercentage = 1f;
				finishedFading = true;
			}

			var fader = fadeToDark ? fadePercentage : 1 - fadePercentage;
			spriteRenderer.color = new Color(col.r, col.g, col.b, fader);
		}
	}
}
