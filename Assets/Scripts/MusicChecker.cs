using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChecker : MonoBehaviour {
    public BGM simpleBGM = BGM.NONE;
    public ComplexBGMRoom complexBGMRoom = ComplexBGMRoom.None;
    
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D == Player.playerInstance.boxCollider)
        {
            var b = BGM.NONE;
            if (simpleBGM != BGM.NONE) b = simpleBGM;
            else
            {
                switch (complexBGMRoom)
                {
                    default:
                    case ComplexBGMRoom.None:
                        break;
                    case ComplexBGMRoom.Park: { b = Global.s.ParkState == 0 && Global.s.MachineChecked == 0 ? BGM.Eternal : BGM.Ending3; } break;
                }
            }

            if(b != BGM.NONE) AudioController.instance.PlayBGM((int)b, .4f, false);
        }
    }

    public enum ComplexBGMRoom
    {
        None,
        Park
    }
}
