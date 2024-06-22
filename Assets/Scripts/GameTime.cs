using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    private static GameTime instance;
    public static GameTime Instance { get { return instance; } }

    private float time;

    public float GetTime { get { return time; } }

    void Awake()
    {
        instance = this;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
