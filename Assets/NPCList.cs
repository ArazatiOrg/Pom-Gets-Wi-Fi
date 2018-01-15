using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCList : MonoBehaviour {
    public static NPCController GetNPC(NPC npc)
    {
        return instance.npcs[(int)npc];
    }

    static NPCList instance;
    private void Start()
    {
        instance = this;
    }

    public List<NPCController> npcs = new List<NPCController>();
}

public enum NPC
{
    Pom,
    Shibe,
    Alma,
    Bernard,
    Bold,
    Chi,
    Corg,
    Crest,
    DavePointer,
    Dog,
    Glish,
    Goldie,
    Hus,
    Labra,
    Malti,
    Papi,
    Puddle,
    Sharpeii,
    Sherman,
    Ug,
    WittyFido,
    York
}
