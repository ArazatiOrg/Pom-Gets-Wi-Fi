using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisableRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }
}
