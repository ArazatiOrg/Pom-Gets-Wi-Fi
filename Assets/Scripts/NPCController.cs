using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    public bool ConstantlyWalk = false;

    public bool AllowMovement = true;
    public float moveSpeed = 1f;

    public float animSpeed = 1f;

    [HideInInspector]
    public CharaAnim anim;
    [HideInInspector]
	public BoxCollider2D boxCollider;

    public SpriteDir facingDir = SpriteDir.Down;

    public bool standingStill = true;
	public bool stoppedOnTile = false;

    public List<TextboxFace> faces = new List<TextboxFace>();

    float movePercentage = 0f;

    float animClock = 0f;

	public float moveTimeout = 0f;
	float moveTimeoutTime = .1f;

    void Start() { InitController(); }
    void Update() { UpdateMovement(); }

    // Use this for initialization
    public void InitController() {
        anim = GetComponentInChildren<CharaAnim>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();

        if(anim == null) Debug.LogWarning("[" + name + "] has a missing CharaAnim component in children.", this);
        if(boxCollider == null) Debug.LogWarning("[" + name + "] has a missing BoxCollider2D component in children.", this);
    }

	int standingStillForXFrames = 0;

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
                transform.position = boxCollider.transform.position;
                boxCollider.transform.localPosition = Vector3.zero;
                anim.transform.localPosition = Vector3.zero;
                standingStill = true;
				stoppedOnTile = true;
            }
        }
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
            if(alertHitOfBump) rayHit.collider.gameObject.SendMessage ("Bumped", gameObject, SendMessageOptions.DontRequireReceiver);
            
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

		//boxCollider.gameObject.GetComponent<Rigidbody2D> ().MovePosition ( (Vector2)transform.position + direction );
		//boxCollider.transform.Translate (direction);
        boxCollider.transform.localPosition = direction;
    }

    public void SetFacingDirection(SpriteDir direction)
    {
		if (facingDir == direction) return;

        facingDir = direction;
        anim.SetSprite(direction, 0);
    }

	public void StallMovement(float timeout = -1f)
	{
        if (timeout == -1f) timeout = moveTimeoutTime;

		moveTimeout = timeout;

		if (movePercentage == 0) {
			standingStill = true;
			boxCollider.transform.localPosition = transform.position;
		}
	}

    public void UnStallMovement()
    {
        moveTimeout = -1f;

        if (movePercentage == 0)
        {
            standingStill = true;
            boxCollider.transform.localPosition = transform.position;
        }
    }

    [System.Serializable]
    public struct TextboxFace
    {
        public string name;
        public Sprite face;
    }
}
