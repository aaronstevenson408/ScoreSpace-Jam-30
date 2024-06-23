using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] float distFromFloor;
    [SerializeField] float timer;
    [SerializeField] GameObject floor;

    public int finalScore;
    [SerializeField] TextMeshProUGUI score;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (playerManager.playerDead)
            return;
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
