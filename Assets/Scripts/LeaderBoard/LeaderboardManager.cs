using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
     public string leaderBoardKey = "test_score";

    private void Update()
    {
    }
    private void Start()
    {
        
    }
    public void SubmitScore(int _score)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, _score, leaderBoardKey, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not submit score!");
                Debug.Log(response.errorData.ToString());
                return;
            }
            Debug.Log("Successfully submitted score!");
        });
    }
    }
