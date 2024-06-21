using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScoreManager : MonoBehaviour
{
    [SerializeField] float distFromFloor;
    [SerializeField] float timer;
    [SerializeField] GameObject floor;

    [SerializeField] int finalScore;

    private void Update()
    {
        CalcDistFromFloor();
        timer += Time.deltaTime;
        CalcScore();
    }

    void CalcDistFromFloor()
    {
        distFromFloor = Vector2.Distance(gameObject.transform.position, floor.transform.position);
    }

    void CalcScore()
    {
        finalScore = Mathf.RoundToInt((distFromFloor / 100) + (timer / 2));
    }
}
