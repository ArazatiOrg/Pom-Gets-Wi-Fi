using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingNumber : MonoBehaviour {
    public Text white;
    public Text red;
    
    float gravMultiplier = 5.75f;
    float curGrav = 1.45f;
    float lowerBound = -4f;
    float pos = 0f;
    Vector3 originalPos;

	// Use this for initialization
	public void InitText(string s) {
        white.text = s;
        red.text = s;
        originalPos = transform.position;
	}
    
	// Update is called once per frame
	void Update () {
        curGrav -= Time.smoothDeltaTime * gravMultiplier;
        pos += curGrav;

        transform.position = originalPos + new Vector3(0, pos/16f, 0);

        if(pos <= lowerBound)
        {
            Destroy(this.gameObject);
        }
	}
}
