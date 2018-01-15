using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseEvent : MonoBehaviour {

	//Note; you can't have all 3 -actually- active at a time. If the collider is set to be a trigger, only steppedOn works.
	//Otherwise, Bumped and Activated both work.
	public bool triggerBySteppedOn = true;
	public bool triggerByBumped = true;
	public bool triggerByActivated = true;
	
	bool playerEntered = false;

	public virtual void Update () {
		if (playerEntered && triggerBySteppedOn && Player.playerInstance.stoppedOnTile) {
			playerEntered = false;
			StartCoroutine(TriggeredEvent(Player.playerInstance.gameObject));
		}
	}

	public virtual IEnumerator TriggeredEvent(GameObject triggeredBy){yield return null;}

	void OnTriggerEnter2D (Collider2D collision2D) { if (triggerBySteppedOn && collision2D == Player.playerInstance.boxCollider) { playerEntered = true; } }
	void Bumped(GameObject gameObject) { if (triggerByBumped && gameObject == Player.playerInstance.gameObject) { StartCoroutine(TriggeredEvent(gameObject)); } }
	public void Activated(GameObject triggeredBy) { if(triggerByActivated) StartCoroutine(TriggeredEvent(triggeredBy)); }
}
