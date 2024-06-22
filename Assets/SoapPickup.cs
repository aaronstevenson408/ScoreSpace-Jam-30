using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoapPickup : MonoBehaviour
{
    [SerializeField] private float timeIncrease = 20;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WorldManager.Instance.GetTime += timeIncrease;
            Debug.Log("Increased time: " + WorldManager.Instance.GetTime);
            Destroy(gameObject);
        }

    }
}
