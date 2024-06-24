using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject leaderboard;
    [SerializeField] LeaderboardManager leaderboardManager;
    bool updated;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            LoadLeaderboardCanvas(true);
            if (!updated)
            {
                leaderboardManager.LoadLeaderBoard();
                updated = true;
            }
        }
        else
        {
            LoadLeaderboardCanvas(false);
            updated = false;
        }
    }
    void LoadLeaderboardCanvas(bool load)
    {
        leaderboard.SetActive(load);
    }
}
