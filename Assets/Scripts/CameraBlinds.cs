using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlinds : MonoBehaviour {
    public static CameraBlinds instance;

    public bool finished = true;

    int blindCount = 0; //max 80

    GameObject[] blinds;

	void Start () {
        instance = this;

        blinds = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            blinds[i] = transform.GetChild(i).gameObject;
        }
	}
	
	public void StartBlinds()
	{
        finished = false;
        blindCount = 0;
	}

    public void HideBlinds()
    {
        foreach (var blind in blinds)
        {
            blind.SetActive(false);
        }
    }

	void Update () {
		if(!finished)
		{
            blinds[blindCount*2].SetActive(true);
            blinds[transform.childCount - 1 - (blindCount * 2)].SetActive(true);

            blindCount++;
            
            if (blindCount == 40) finished = true;
		}
	}
}
