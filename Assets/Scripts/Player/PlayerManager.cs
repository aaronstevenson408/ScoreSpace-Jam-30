using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public PlayerMovement playerMovement;
    [HideInInspector]
    public PlayerScore playerScoreManager;
    [HideInInspector]
    public PlayerAnimation playerAnimations;
    [HideInInspector]
    public Rigidbody2D _rb;
    Bubble bubble;

    [SerializeField] LeaderboardManager leaderBoard;

    [Header("Flags")]
    [HideInInspector]
    public bool playerDead;
    [SerializeField] GameObject playerCamera;
    Collider2D _collider;

    private void Awake()
    {
        bubble = GetComponentInChildren<Bubble>();
        playerMovement = GetComponent<PlayerMovement>();
        playerScoreManager = GetComponent<PlayerScore>();
        playerAnimations = GetComponent<PlayerAnimation>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (playerDead)
            return;
        SyncCamera();
    }

    void SyncCamera()
    {
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, playerCamera.transform.position.z);
    }

    public void Dead()
    {
        _rb.gravityScale = 1;
        _collider.enabled = false;
        leaderBoard.SubmitScore(playerScoreManager.finalScore);
        bubble.Pop();
        playerDead = true;
    }

    public void Invulnerability(float time)
    {
        time -= Time.deltaTime;
        if(time> 0)
        {
            _collider.enabled = false;
        }
    }
}
