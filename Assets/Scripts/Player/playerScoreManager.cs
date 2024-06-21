using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] float distFromFloor;
    [SerializeField] float timer;
    [SerializeField] GameObject floor;

    public int finalScore;
    [SerializeField] Text score;

    private void Awake()
    {
    }
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
        score.text = finalScore.ToString();
    }
}
