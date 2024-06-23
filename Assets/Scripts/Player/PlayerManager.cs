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
    public GameManager gameManager;
    [HideInInspector]
    public Rigidbody2D _rb;

    [SerializeField] LeaderboardManager leaderBoard;

    [Header("Flags")]
    [HideInInspector]
    public bool playerDead;
    [SerializeField] GameObject playerCamera;
    Collider2D _collider;

    private void Awake()
    {
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
        playerDead = true;
    }
}
