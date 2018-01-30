using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    public bool ConstantlyWalk = false;

    public bool AllowMovement = true;
    public float moveSpeed = 8f;

    public float animSpeed = 1f;

    [HideInInspector]
    public CharaAnim anim;
    [HideInInspector]
	public BoxCollider2D boxCollider;

    public SpriteDir facingDir = SpriteDir.Down;

    public bool standingStill = true;
	public bool stoppedOnTile = false;
    
    public float movePercentage = 0f;

    float animClock = 0f;

	public float moveTimeout = 0f;
	float moveTimeoutTime = .1f;

    void Start() { InitController(); }
    void Update() { UpdateMovement(); }

    // Use this for initialization
    public void InitController() {
        anim = GetComponentInChildren<CharaAnim>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

	int standingStillForXFrames = 0;

    Vector3 oldPos = Vector3.zero;

	public void UpdateMovement() {

		if (moveTimeout >= 0) moveTimeout -= Time.smoothDeltaTime;

		if (standingStill) {
			standingStillForXFrames++;

			if (standingStillForXFrames > 3 && !ConstantlyWalk) {
				animClock = 0f;
				anim.SetSprite (facingDir);
			}

            if(ConstantlyWalk) UpdateAnim();
		}
		else
        {
			stoppedOnTile = false;

			standingStillForXFrames = 0;

            movePercentage += Time.smoothDeltaTime * moveSpeed;

            UpdateAnim();

            if (movePercentage < 1f)
            {
                var pos = Vector3.Lerp(transform.position, boxCollider.transform.position, movePercentage);

                //snap to the 16 pixel grid
                anim.transform.position = new Vector3(((int)(pos.x*16)/16f), ((int)(pos.y*16)/16f), anim.transform.position.z);
            }
            else
            {
                movePercentage = 1f;
                transform.position = boxCollider.transform.position;
                boxCollider.transform.localPosition = Vector3.zero;
                anim.transform.localPosition = Vector3.zero;
                standingStill = true;
				stoppedOnTile = true;
            }
        }

        if (oldPos != transform.position && anim != null && anim.spriteRenderer != null) anim.spriteRenderer.sortingOrder = 16384 - (int)(transform.position.y * 2);

        oldPos = transform.position;
    }

    private void UpdateAnim()
    {
        animClock += Time.smoothDeltaTime * animSpeed;

        if (animClock <= .25f) anim.SetSprite (facingDir, 0);
        else if (animClock <= .50f) anim.SetSprite (facingDir, 1);
        else if (animClock <= .75f) anim.SetSprite (facingDir, 0);
        else if (animClock <= 1f) anim.SetSprite (facingDir, 2);
        else { anim.SetSprite (facingDir, 0); animClock -= 1f; }
    }

    public Vector2 VectorFromSpriteDir(SpriteDir dir)
    {
        switch (dir)
        {
            case SpriteDir.Left: return new Vector2(-1f, 0f);
            case SpriteDir.Right: return new Vector2(1f, 0f);
            case SpriteDir.Up: return new Vector2(0f, 1f);
            case SpriteDir.Down: return new Vector2(0f, -1f);
            default: return Vector2.zero;
        }
    }

    public RaycastHit2D CanMoveRayhit(SpriteDir direction)
    {
        var moveDir = VectorFromSpriteDir(direction);

        var pos = transform.position + new Vector3(0f, -.5f, 0f);
        var dist = 1f;
        
		var rayHit = Physics2D.Raycast(pos, moveDir, dist);
        Debug.DrawRay(pos, moveDir * dist, Color.red, .1f);

        return rayHit;
    }

    public bool CanMove(SpriteDir direction)
    {
		if (!AllowMovement) return false;

		return CanMoveRayhit (direction).collider == null;
    }

    public bool TryMove(SpriteDir direction, bool alertHitOfBump)
    {
		if (!AllowMovement || moveTimeout > 0f) return false;

        var rayHit = CanMoveRayhit(direction);

		SetFacingDirection(direction);
		if (rayHit.collider != null) {
            if (alertHitOfBump)
            {
                if(gameObject != Player.playerInstance.gameObject )
                {
                    if(rayHit.collider.transform.parent.gameObject == Player.playerInstance.gameObject)
                    {
                        //send message to self if we're not the player and we just bumped into the player
                        gameObject.SendMessage("Bumped", Player.playerInstance.gameObject, SendMessageOptions.DontRequireReceiver);
                    }
                }
                else rayHit.collider.gameObject.SendMessage("Bumped", gameObject, SendMessageOptions.DontRequireReceiver);
            }
            
            //I forget why I added this, but it was breaking bump events so..
            //StallMovement ();
			return false;
		} else {
			ForceMove(VectorFromSpriteDir(direction));
			return true;
		}
    }

    public void ForceMove(Vector2 direction)
    {
        standingStill = false;
        movePercentage = 0f;

        stoppedOnTile = false;
        
        boxCollider.transform.localPosition = direction;
    }

    public void SetFacingDirection(SpriteDir direction)
    {
		if (facingDir == direction) return;

        facingDir = direction;
        anim.SetSprite(direction, 0);
    }

    public void LookAt(GameObject obj)
    {
        var dir = obj.transform.position - transform.position;
        var dirAbs = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

        if (dir.magnitude < 0.01f) return;

        var lookDir = dirAbs.x > dirAbs.y ? ( dir.x > 0 ? SpriteDir.Right : SpriteDir.Left ) : ( dir.y > 0 ? SpriteDir.Up : SpriteDir.Down );

        SetFacingDirection(lookDir);
    }

    public SpriteDir DirFromVector(Vector2 vec)
    {
        var dir = vec;
        var dirAbs = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

        if (vec.magnitude < 0.01f) return SpriteDir.None;

        var lookDir = dirAbs.x > dirAbs.y ? (dir.x > 0 ? SpriteDir.Right : SpriteDir.Left) : (dir.y > 0 ? SpriteDir.Up : SpriteDir.Down);

        return lookDir;
    }

	public void StallMovement(float timeout = -1f)
	{
        if (timeout == -1f) timeout = moveTimeoutTime;

		moveTimeout = timeout;

		if (movePercentage == 0) {
			standingStill = true;
			boxCollider.transform.position = transform.position;
		}
	}

    public void UnStallMovement()
    {
        moveTimeout = -1f;

        if (movePercentage == 0)
        {
            standingStill = true;
            boxCollider.transform.position = transform.position;
        }
    }

    public void ResetMovement()
    {
        transform.position = boxCollider.transform.position;
        boxCollider.transform.localPosition = Vector3.zero;
        anim.transform.localPosition = Vector3.zero;
        standingStill = true;
        stoppedOnTile = true;
        movePercentage = 1f;
    }

    public void SetSpeed(Speed speed)
    {
        switch (speed)
        {
            case Speed.OneEighthNormal: moveSpeed = 1f; break;
            case Speed.OneFourthNormal: moveSpeed = 2f; break;
            case Speed.HalfNormal: moveSpeed = 4f; break;
            case Speed.Normal: moveSpeed = 8f; break;
            case Speed.TwiceNormal: moveSpeed = 16f; break;
            case Speed.FourTimesNormal: moveSpeed = 64f; break;
        }
    }
}
