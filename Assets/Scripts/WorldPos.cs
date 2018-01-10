using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldPos : MonoBehaviour {
	public Image gameCanvas;
	public GameObject mouseCursorObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var pos = new Vector3 (Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, mouseCursorObj.transform.position.z);
		pos.x = pos.x * 20f - 10f; //adjust for game canvas size and pixels-per-unit
		pos.y = pos.y * 15f - 7.5f;
		var multiplier = new Vector2 (Screen.width  / (gameCanvas.rectTransform.sizeDelta.x * gameCanvas.rectTransform.lossyScale.x),
									  Screen.height / (gameCanvas.rectTransform.sizeDelta.y * gameCanvas.rectTransform.lossyScale.y));
		pos.x = pos.x * multiplier.x; //adjust for dynamic window resizing
		pos.y = pos.y * multiplier.y;
		pos.x = pos.x + Camera.main.transform.position.x; //adjust for camera position in world
		pos.y = pos.y + Camera.main.transform.position.y;

		if(mouseCursorObj != null) mouseCursorObj.transform.position = pos;
	}
}
