using System.Collections;
using UnityEngine;

public class SoapPickup : Pickup
{
    [SerializeField] private float timeIncrease = 20;

    protected override void DoSomething()
    {
        WorldManager.Instance.GetTime += timeIncrease;
        Debug.Log("Increased time: " + WorldManager.Instance.GetTime);
    }

}
