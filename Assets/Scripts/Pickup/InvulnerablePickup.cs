using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerablePickup : Pickup
{
    [SerializeField] private float invulnerabilityTime = 4;

    protected override void DoSomething()
    {
        Bubble.Instance.StartCoroutine(
            Bubble.Instance.Invulnerability(invulnerabilityTime)
        );
    }
}
