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

    [HideInInspector]
     public float gravityScale = -1;
     float slowSpeedTimer;
     float invulnTimer;

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
        invulnTimer = time;
        invulnTimer -= 1;
        if(invulnTimer > 0)
        {
            _collider.enabled = false;
            bubble.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(CallInvuln(invulnTimer));
        }
        else
        {
            _collider.enabled = true;
            bubble.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void SlowSpeed(float time,float amount)
    {
        slowSpeedTimer = time;
        slowSpeedTimer -= 1;
        if (slowSpeedTimer > 0)
        {
            _rb.gravityScale = amount;

            StartCoroutine(CallSlowSpeed(slowSpeedTimer, amount));
        }
        else
        {
            if (gravityScale < -1)
            {
                _rb.gravityScale = gravityScale;
            }
            else
            {
                _rb.gravityScale = -1;
            }
           
        }
    }
    IEnumerator CallSlowSpeed(float time, float amount)
    {
        yield return new WaitForSeconds(1);
            SlowSpeed(time, amount);
    }
    IEnumerator CallInvuln(float time)
    {
        yield return new WaitForSeconds(1);
        Invulnerability(time);
    }
}
