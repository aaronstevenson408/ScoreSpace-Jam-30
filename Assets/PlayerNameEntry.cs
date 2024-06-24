using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class PlayerNameEntry : MonoBehaviour
{
    public void EnterName(string name)
    {


        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not Name Character");
                Debug.Log(response.errorData.ToString());
                return;
            }

            Debug.Log("CharacterNamed");
        });
    }
}
