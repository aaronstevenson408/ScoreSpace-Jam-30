using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerManager playerManager;
    [HideInInspector]
    public Animator animatorLink;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorLink = GetComponent<Animator>();
    }
    private void Update()
    {
        //animatorLink.SetBool("IsDead", playerManager.playerDead);
    }
}
