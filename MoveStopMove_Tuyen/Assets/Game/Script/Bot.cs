using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " of " + (transform.parent == null ? "null" : transform.parent.name) + "  " + other.name + " of " + (other.gameObject.transform.parent == null ? "null" : other.gameObject.transform.parent.name));
    }
    private void Start()
    {
        base.rangeAttack.SetSize(base.originalRangeAttackSize);
    }
}
