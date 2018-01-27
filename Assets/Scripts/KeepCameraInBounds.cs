using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCameraInBounds : MonoBehaviour {
	public static KeepCameraInBounds instance;

	public GameObject objectToFollow;
	Vector3 objectToFollowLastPos;
	public GameObject BoundsList;
	GameObject bounds;

	Vector3 dumbHackyPosition;

	public bool disabledMapEdges = false;

    float shakeTime = 0f;
    float shakeStrength = 0f;
    float shakeSpeed = 0f;
    public float curShakeStrength = 0f;

    public GameObject UI;

	void Start() {
		dumbHackyPosition = transform.position;
		instance = this;

		UpdateBounds ();
	}

	void UpdateBounds()
	{
        if(objectToFollow == null) { bounds = null; return; }

		var objectToFollowPos = objectToFollow.transform.position + new Vector3 (0f, -.5f, 0f);
		for (int i = 0; i < BoundsList.transform.childCount; i++) {
			var child = BoundsList.transform.GetChild (i);
			var renderer = child.GetComponent<Renderer> ();
			if (renderer != null & renderer.bounds.Contains (objectToFollowPos)) {
				bounds = child.gameObject;
				return;
			}
		}

		bounds = null;
	}

	void Update () {
		if (objectToFollow != null) {
			if(objectToFollow.transform.position == objectToFollowLastPos && curShakeStrength == 0f && shakeTime <= 0f) return;

			objectToFollowLastPos = objectToFollow.transform.position;

			var z = dumbHackyPosition.z;
			var cameraWidthHalf = 10f;
			var cameraHeightHalf = 7.5f;

			var objectOffset = new Vector3 (.5f, 0f);

			dumbHackyPosition = objectToFollow.transform.position + objectOffset;
            dumbHackyPosition.z = z;
            
            UpdateBounds();

			if (disabledMapEdges || bounds == null) {
				transform.position = new Vector3(((int)(dumbHackyPosition.x*16)/16f), ((int)(dumbHackyPosition.y*16)/16f), z);
			}

            var newPos = dumbHackyPosition;

            //camera bounds
            if (bounds != null)
            {
                var pos = bounds.transform.position;
                var size = bounds.transform.lossyScale;

                var left = pos.x - (size.x / 2f);
                var right = pos.x + (size.x / 2f);
                var top = pos.y + (size.y / 2f);
                var bottom = pos.y - (size.y / 2f);

                if (newPos.x - cameraWidthHalf < left) newPos.x = left + cameraWidthHalf;
                if (newPos.x + cameraWidthHalf > right) newPos.x = right - cameraWidthHalf;
                if (newPos.y + cameraHeightHalf > top) newPos.y = top - cameraHeightHalf;
                if (newPos.y - cameraHeightHalf < bottom) newPos.y = bottom + cameraHeightHalf;
            }

			newPos.z = z;
			dumbHackyPosition = newPos;
            
            if (shakeTime > 0f) shakeTime -= Time.smoothDeltaTime;
            if(shakeStrength > 0f) curShakeStrength += shakeSpeed * Time.smoothDeltaTime * 4f;

            //fuck this is more complicated than it needs to be but whatever
            //sorry if you have to work on this in the future, whoever is reading this

            //3 phases, all based on curShakeStrength
            //Up to shakeStrength is moving to the right, shakeStrength -> 3x for moving to the far left from the far right
            //and then back to the center from the far left.

            //This if block just neatly rounds it back down
            if (shakeStrength > 0f && curShakeStrength >= shakeStrength * 4f)
            {
                if (shakeTime > 0f)
                {
                    curShakeStrength -= shakeStrength * 4f;
                }
                else
                {
                    //we're back at 0, and shakeTime has expired. Do a reset
                    shakeStrength = 0f;
                    shakeSpeed = 0f;
                    curShakeStrength = 0f;
                }
            }

            var shakeOffset = 0f;

            //don't shame me, I'm just getting stuff done
            //too tired right now to figure out the most elegant way to do this :V

            if (shakeStrength > 0f)
            {
                if (curShakeStrength < shakeStrength) //from middle to right
                    shakeOffset = curShakeStrength;
                else if (curShakeStrength < shakeStrength * 3f) //from right to far left
                    shakeOffset = shakeStrength - (curShakeStrength - shakeStrength);
                else //from far left back to middle
                    shakeOffset = -shakeStrength + (curShakeStrength - shakeStrength * 3f);
            }

            transform.position = new Vector3(((int)((dumbHackyPosition.x + shakeOffset) * 16) / 16f), ((int)(dumbHackyPosition.y * 16) / 16f), z);
            
            UI.transform.localPosition = new Vector3(-shakeOffset, UI.transform.localPosition.y, 10f);
		}
	}

    public void StartShake(float strength = 1f, float speed = 5f, float time = .4f)
    {
        shakeTime = time;
        shakeStrength = strength;
        shakeSpeed = speed;

        curShakeStrength = 0f;
    }

	void OnDrawGizmosSelected() {
		if (bounds != null) {
			var pos = bounds.transform.position;
			var size = bounds.transform.lossyScale;

			Gizmos.color = Color.red;
			Gizmos.DrawSphere (pos + new Vector3(-size.x/2f, -size.y/2f), 1f);
			Gizmos.DrawSphere (pos + new Vector3(size.x/2f, size.y/2f), 1f);

			Gizmos.DrawSphere (pos + new Vector3(-size.x/2f, size.y/2f), 1f);
			Gizmos.DrawSphere (pos + new Vector3(size.x/2f, -size.y/2f), 1f);
		}
	}
}
