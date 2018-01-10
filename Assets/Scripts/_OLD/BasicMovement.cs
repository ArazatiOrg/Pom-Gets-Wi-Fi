using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

	float timeBetweenMoves = .1f;
	float timeoutAgainstWall = .05f;
	float moveTimeout = 0f;
	// Update is called once per frame
	void Update () {
		if (moveTimeout > 0f) moveTimeout -= Time.smoothDeltaTime;

		if (moveTimeout <= 0f) {
			var desiredMove = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0f);

			if (desiredMove.magnitude > .01f) {
				var ray = Physics2D.Raycast (transform.position + new Vector3(0f, -.5f, 0f), desiredMove, desiredMove.magnitude * .9f);
				Debug.DrawRay(transform.position + new Vector3(0f, -.5f, 0f), desiredMove * (desiredMove.magnitude * .9f), Color.red, .1f);

				if (ray.collider == null) {
					transform.position += desiredMove;
					moveTimeout += timeBetweenMoves;
				} else {
					Debug.Log ("HIT: " + ray.transform.name);
					moveTimeout += timeoutAgainstWall;
				}
			}
		}
	}
}
