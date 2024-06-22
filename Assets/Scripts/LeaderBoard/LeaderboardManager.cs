using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
     public string leaderboardKey = "test_score";
    public bool test;

    public int testScore;
    [SerializeField] GameObject entry_prefab;
    [SerializeField] GameObject content;
    [SerializeField] List<Entry> entry;

    private void Update()
    {
        if (test)
        {
            SubmitScore(testScore);
            test = false;
        }
    }
    private void Start()
    {
        LoadLeaderBoard();
    }
    public void SubmitScore(int _score)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, _score, leaderboardKey, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not submit score!");
                Debug.Log(response.errorData.ToString());
                return;
            }
            LoadLeaderBoard();
            Debug.Log("Successfully submitted score!");
        });
    }

    public void LoadLeaderBoard()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;
                for (int i = 0; i < members.Length; i++)
                {
                    Debug.Log("Player is: " + members[i].player.id.ToString());
                    if (members[i].player.name != "")
                    {
                        TryToAddItem(members[i].player.name, members[i].score);
                    }
                    else
                    {
                        TryToAddItem(members[i].player.id.ToString(), members[i].score);
                    }
                       
                }
            }
        });
    }
    public void TryToAddItem( string name, int score)
    {
        Debug.Log("Checking01");
        bool entryExists = false;
        if (entry.Count > 0)
        {
            foreach (var item in entry)
            {
                Debug.Log("Checking");
                if (item.playerName == name)
                {
                    Debug.Log("Does Exit");
                    entryExists = true;
                    if (item.score < score)
                    {
                        item.ChangeScore(score);
                        break;
                    }
                }
            }
        }

            if (entryExists==false)
            {
                Debug.Log("DoesntExits");
                Entry newSlot = new Entry(name, score);
               entry.Add(new Entry(name, score));
                    var clone = Instantiate(entry_prefab, content.transform);
                    clone.GetComponent<LeaderBoardEntry>().playerName.text = name;
                    clone.GetComponent<LeaderBoardEntry>().playerScore.text = score.ToString();
            }
        
    }

}

[System.Serializable]
public class Entry
{
    public string playerName;
    public int score;
    public int rank;
    public Entry(string _name, int _score)
    {
        playerName = _name;
        score = _score;
    }
    public void ChangeScore(int _score)
    {
        score = _score;
    }
}
