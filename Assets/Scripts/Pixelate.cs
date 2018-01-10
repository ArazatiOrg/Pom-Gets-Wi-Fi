using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pixelate : MonoBehaviour {
    public static Pixelate instance;

    public Image image;

    public Material mat;
    public float cellSize = -1f;
    float oldCellSize = -1f;
    
    float cellMax = 32f;

    public float fadeSpeed = 3f;
    bool fadeToDark = true;
    public bool finishedFading = true;
    float fadePercentage = 0f;

    private void Start()
    {
        instance = this;
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

    private void Update()
    {
        if (!finishedFading)
        {
            fadePercentage += Time.smoothDeltaTime * fadeSpeed;

            if (fadePercentage >= 1f)
            {
                fadePercentage = 1f;
                finishedFading = true;
            }

            var fader = fadeToDark ? fadePercentage : 1f - fadePercentage;
            cellSize = cellMax * fader;
        }

        if (oldCellSize != cellSize)
        {
            oldCellSize = cellSize;

            if (cellSize > 0f)
            {
                image.enabled = true;
                mat.SetVector("_CellSize", new Vector4(cellSize / 320f, cellSize / 240f, 0, 0));
            }
            else
            {
                image.enabled = false;
            }
        }
    }
}
