using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public enum GameState { START, RUNNING, END }
public class WorldManager : MonoBehaviour
{
    private static WorldManager instance;

    [SerializeField] AudioClip MainMenu;
    [SerializeField] AudioClip GameMusic;
    [SerializeField] AudioClip GameOver;
    SoundManager soundManager;
    public static WorldManager Instance { get { return instance; } }

    [Header("Time")]
    [SerializeField] private float startTime = 40;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private bool canDecreaseTime = false;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject playerUICanvas;
    [Header("Test")]
    public float timeLeft;
    private GameState gameState = GameState.START;
    public float timer;

     bool mainMenuMusicisPlayed = false;
     bool gameMusicisPlayed = false;
     bool gameOverMusicIsPlayed = false;

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

    private void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    void Update()
    {
        ChangeMusic();
        if (canDecreaseTime)
            // DecreaseTime();
            test();
        if(timer <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().Dead();
        }
    }

    public void ChangeMusic()
    {
        //Debug.Log("Called");
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //mainmenu
            if (!mainMenuMusicisPlayed)
            {
                soundManager.ChangeMusic(MainMenu);
                mainMenuMusicisPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && gameState != GameState.END)
        {
            //Game is running and not dead
            if (!gameMusicisPlayed)
            {
                soundManager.ChangeMusic(GameMusic);
                gameMusicisPlayed = true;
            }

        }
    }
    public void DecreaseTime()
    {
        timer -= Time.deltaTime;
        string tText = timer.ToString();
        timeText.text = tText.Substring(0, tText.Length - 2);
        if (timer <= 0)
            GameObject.Find("Player").GetComponent<PlayerManager>().Dead();
    }
    public void StartGame()
    {
        gameState = GameState.RUNNING;
        SceneManager.LoadScene(1);
    }
    public void End()
    {
        gameState = GameState.END;
        if (!gameOverMusicIsPlayed)
        {
            soundManager.ChangeMusic(GameOver);
            gameOverMusicIsPlayed = true;
        }

        Debug.Log("Game Ended");
        playerUICanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        //leader board stuff
        //end screen ui
    }
    public void IncreaseTime(float timeIncreased)
    {
        timer += timeIncreased;
    }
    void test()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Timer(timer);
        }
    }
    void Timer(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("{0:00} : {1:00}", min, sec);
    }
}