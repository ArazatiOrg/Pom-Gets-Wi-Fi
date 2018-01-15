using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventSetGlobal : _BaseLogicEvent {
    Global.GlobalInt globalInt;
    int setToInt;

    Global.GlobalBool globalBool;
    bool setToBool;

    public static EventSetGlobal c(Global.GlobalInt globalVariable, int setTo)
    {
        return new EventSetGlobal() { setToInt = setTo, globalInt = globalVariable };
    }

    public static EventSetGlobal c(Global.GlobalBool globalVariable, bool setTo)
    {
        return new EventSetGlobal() { setToBool = setTo, globalBool = globalVariable };
    }

    public override IEnumerator Execute()
    {
        if (globalInt != null)
        {
            globalInt.value = setToInt;
            //Debug.Log("Setting " + globalInt.name + " to " + globalInt.value);
        }
        if (globalBool != null)
        {
            globalBool.value = setToBool;
            //Debug.Log("Setting " + globalBool.name + " to " + globalBool.value);
        }



        yield return null;
    }

}
