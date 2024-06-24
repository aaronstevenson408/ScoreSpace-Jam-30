using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject leaderboard;
    [SerializeField] LeaderboardManager leaderboardManager;

    [SerializeField] GameObject Options;
    bool updated;
    bool isEnabled;
    public PlayerManager playerManager;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    private void Update()
    {
        if (playerManager.playerDead)
            return;
        if (Input.GetKey(KeyCode.Tab) && !isEnabled)
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEnabled)
            {
                Options.SetActive(false);
                Time.timeScale = 1;
                isEnabled = false;
            }
            else
            {
                Options.SetActive(true);
                Time.timeScale = 0;
                isEnabled = true;
            }
        }
    }
    void LoadLeaderboardCanvas(bool load)
    {
        leaderboard.SetActive(load);
    }

    public void NolongerINPauseScreen()
    {
        Options.SetActive(false);
        isEnabled = false;
        Time.timeScale = 1;
    }

    public void SFXVolume(float value)
    {
        soundManager.SFX.volume = value / 100;
    }
    public void MusicVolume(float value)
    {

        soundManager.Music.volume = value / 100;
    }
}
