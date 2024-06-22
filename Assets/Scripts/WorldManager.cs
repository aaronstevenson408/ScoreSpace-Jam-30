using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, RUNNING, END }

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance;
    public static WorldManager Instance { get { return instance; } }

    [SerializeField] private float startTime = 40;

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
        timer -= Time.deltaTime;
        if (timer <= 0)
            End();
    }

    public void End()
    {
        gameState = GameState.END;
        Debug.Log("Game Ended");

        //leader board stuff
        //end screen ui

    }
}
