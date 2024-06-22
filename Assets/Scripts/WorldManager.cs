using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { START, RUNNING, END }

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance;
    public static WorldManager Instance { get { return instance; } }

    [SerializeField] private float startTime = 40;
    [SerializeField] private Text timeText;
    [SerializeField] private bool canDecreaseTime = false;

    private GameState gameState = GameState.START;
    private float timer;

    public float GetTime
    {
        get { return timer; }
        set { timer = value; }
    }

    void Awake()
    {
        instance = this;
        timer = startTime;
    }

    void Update()
    {
        if (canDecreaseTime)
            DecreaseTime();

    }

    public void DecreaseTime()
    {
        timer -= Time.deltaTime;
        string tText = timer.ToString();
        timeText.text = tText.Substring(0, tText.Length - 2);
        if (timer <= 0)
            End();
    }

    public void StartGame()
    {
        gameState = GameState.RUNNING;
        SceneManager.LoadScene(1);
    }

    public void End()
    {
        gameState = GameState.END;
        Debug.Log("Game Ended");

        //leader board stuff
        //end screen ui

    }
}
