using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class LeaderBoardCanvas : MonoBehaviour
{
    public string leaderboardKey = "timebased_leaderboardKey";
    public bool test;
    [SerializeField] GameObject entry;
    [SerializeField] GameObject content;

    private void Awake()
    {
    }
    private void Update()
    {
        if (test)
        {
            LoadLeaderBoard();
            FillLeaderBoard();
            test = false;
        }
    }
    public void LoadLeaderBoard()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not get scores!");
                Debug.Log(response.errorData.ToString());
                return;
            }

            foreach (var entries in response.items)
            {

            }
        });
        }

    public void FillLeaderBoard()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
              {
                  if (response.success)
                  {
                      LootLockerLeaderboardMember[] members = response.items;
                      for (int i=0; i<members.Length; i++)
                      {
                          var clone = Instantiate(entry, content.transform);
                          if(members[i].player.name != "")
                          {
                              clone.GetComponent<LeaderBoardEntry>().playerName.text = members[i].player.name;
                          }
                          else
                          {
                              clone.GetComponent<LeaderBoardEntry>().playerName.text = members[i].player.id.ToString();
                          }
                          clone.GetComponent<LeaderBoardEntry>().playerScore.text = members[i].score.ToString();
                      }

                  }
              });
    }
}
