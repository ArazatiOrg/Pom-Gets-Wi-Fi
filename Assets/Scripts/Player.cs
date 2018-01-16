using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NPCController {
	public static Player playerInstance;
	
	// Use this for initialization
	void Start () {
        base.InitController();

		playerInstance = this;
	}

	SpriteDir? moveDirPriority = null;
	// Update is called once per frame
	void Update () {
        if(standingStill && AllowMovement)
        {
			SpriteDir? moveDir = null;

			var pressingRight = Input.GetButton("Right");
			var pressingLeft = Input.GetButton("Left");
			var pressingUp = Input.GetButton("Up");
			var pressingDown = Input.GetButton("Down");

			var dirsPressed = new List<SpriteDir>();
			if (pressingRight) dirsPressed.Add(SpriteDir.Right);
			if (pressingLeft) dirsPressed.Add(SpriteDir.Left);
			if (pressingUp) dirsPressed.Add(SpriteDir.Up);
			if (pressingDown) dirsPressed.Add(SpriteDir.Down);

			#region Mobile Touch and Mouse
			List<Vector2> touchPos = new List<Vector2>();
			
			if(Input.GetMouseButton(0))
			{
				touchPos.Add(Input.mousePosition);
			}

			if(Input.touchCount > 0)
			{
				foreach (var touch in Input.touches)
				{
					if(touch.phase != TouchPhase.Ended)
					{
						touchPos.Add(touch.position);
					}
				}
			}

			foreach (var pos in touchPos)
			{
				var percentages = new Vector2((pos.x / Screen.width * 2f) - 1f, (pos.y / Screen.height * 2f) - 1f);
				var absPercentages = new Vector2(Mathf.Abs(percentages.x), Mathf.Abs(percentages.y));

				if(absPercentages.x > absPercentages.y)
				{
					if(percentages.x > 0f) dirsPressed.Add(SpriteDir.Right);
					else dirsPressed.Add(SpriteDir.Left);
				}
				else
				{
					if(percentages.y > 0f) dirsPressed.Add(SpriteDir.Up);
					else dirsPressed.Add(SpriteDir.Down);
				}
			}
			#endregion

			if (dirsPressed.Count == 0) {
				moveDirPriority = null;
			}
			else if (dirsPressed.Count == 1) {
				moveDir = dirsPressed [0];
			}
			else
			{
				if (moveDirPriority.HasValue && dirsPressed.Contains (moveDirPriority.Value))
					moveDir = moveDirPriority;
				else
					moveDir = dirsPressed [0];
			}

			if (moveDir.HasValue) {
                if(Global.devMode && Input.GetKey(KeyCode.RightShift) && !(!AllowMovement || moveTimeout > 0f))
                {
                    SetFacingDirection(moveDir.Value);
                    ForceMove(VectorFromSpriteDir(moveDir.Value));
                }
                else
                {
                    TryMove(moveDir.Value, true);
                }
                
                if(!standingStill)
                {
                    Global.PlayerPosX.value = boxCollider.transform.localPosition.x;
                    Global.PlayerPosY.value = boxCollider.transform.localPosition.y;
                }
			}
            else
            {
                //not moving, let's check for Activated
                var activated = false;

                //check for Enter or Z to be pressed
                //TODO: mouse only/touch only activation
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) activated = true;

                if (activated)
                {
                    var rayHit = CanMoveRayhit(facingDir);

                    if (rayHit.collider != null)
                    {
                        rayHit.collider.gameObject.SendMessage("Activated", gameObject, SendMessageOptions.DontRequireReceiver);
                    }

                    StallMovement();
                }
            }

			moveDirPriority = moveDir;
        }

        var beforeSpeed = moveSpeed;
        if (Global.devMode && Input.GetKey(KeyCode.RightControl)) moveSpeed = 80;

		base.UpdateMovement();

        moveSpeed = beforeSpeed;
    }
}