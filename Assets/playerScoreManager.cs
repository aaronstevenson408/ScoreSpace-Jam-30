using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScoreManager : MonoBehaviour
{
    [SerializeField] float distFromFloor;
    [SerializeField] float timer;
    [SerializeField] GameObject floor;



    private void Update()
    {
        CalcDistFromFloor();
    }

    void CalcDistFromFloor()
    {
        distFromFloor = Vector2.Distance(gameObject.transform.position, floor.transform.position);
    }
}
