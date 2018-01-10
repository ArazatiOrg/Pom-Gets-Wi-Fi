using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousPan : MonoBehaviour {
	Vector3 startPos;

	public float speed = 4f;
	float moved = 0f;

	Sprite sprite;

	void Start () {
		startPos = transform.position;
		sprite = GetComponent<SpriteRenderer> ().sprite;
	}

	void Update () {
		moved += speed * Time.smoothDeltaTime;

		if(moved >= sprite.bounds.size.y) moved -= sprite.bounds.size.y;

		transform.position = startPos + Vector3.down * moved;
	}

	void OnDisable () {
		
	}
}
