using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPickup : Pickup
{
    [SerializeField] private float slowAmt = 0.4f;
    [SerializeField] private float slowTime = 3;

    protected override void DoSomething()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().SlowSpeed(slowTime,slowAmt);
    }
}
