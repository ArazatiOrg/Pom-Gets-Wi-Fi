using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class BuildtimeInfo : MonoBehaviour{
    static string time = "";

    public static string DateTimeString()
    {
        if (string.IsNullOrEmpty(time)) time = DateTime.Now.ToString();

        return time;
    }
}
#endif
