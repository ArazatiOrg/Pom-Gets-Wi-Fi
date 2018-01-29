using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventSetGlobal : _BaseLogicEvent {
    Global.GlobalInt globalInt;
    int setToInt;

    Global.GlobalBool globalBool;
    bool setToBool;

    Operation op = Operation.Set;

    public static EventSetGlobal c(Global.GlobalInt globalVariable, int setTo)
    {
        return new EventSetGlobal() { setToInt = setTo, globalInt = globalVariable };
    }

    public static EventSetGlobal c(Global.GlobalBool globalVariable, bool setTo)
    {
        return new EventSetGlobal() { setToBool = setTo, globalBool = globalVariable };
    }

    public EventSetGlobal Add
    {
        get
        {
            op = Operation.Add;
            return this;
        }
    }

    public override IEnumerator Execute()
    {
        if (globalInt != null)
        {
            switch (op)
            {
                default:
                case Operation.Set:
                    globalInt.value = setToInt;
                    break;
                case Operation.Add:
                    globalInt.value += setToInt;
                    break;
            }
        }
        if (globalBool != null)
        {
            globalBool.value = setToBool;
        }

        Global.changedVariables = true;

        yield return null;
    }

    enum Operation
    {
        Set,
        Add
    }
}
