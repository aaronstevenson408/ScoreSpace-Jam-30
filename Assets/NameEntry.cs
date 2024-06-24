using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class NameEntry : MonoBehaviour
{
public void PlayerName(string name)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("player could not be named");
                Debug.Log(response.errorData.ToString());
                return;
            }

            Debug.Log("Player Named");
        });
    }
}
