using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerLoginManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Login was successful");
                PlayerPrefs.SetString("ID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not Start Session");
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
