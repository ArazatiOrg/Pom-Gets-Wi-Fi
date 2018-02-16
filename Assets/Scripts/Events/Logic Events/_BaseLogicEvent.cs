using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseLogicEvent {
    public virtual IEnumerator Execute() { yield return null; }
}
