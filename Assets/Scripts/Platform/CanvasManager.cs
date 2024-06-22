using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject leaderboard;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            LoadLeaderboardCanvas(true);
        }
        else
        {
            LoadLeaderboardCanvas(false);
        }
    }
    void LoadLeaderboardCanvas(bool load)
    {
        leaderboard.SetActive(load);
    }
}
