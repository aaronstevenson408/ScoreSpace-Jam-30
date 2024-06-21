using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager playerManager;
    [Header("Movement")]
    [HideInInspector]
    public float inputX;
    [SerializeField] float speed;

    float sideMovement;
    bool flipped;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (playerManager.playerDead)
            return;
        MoveSideways();
    }
    public void MoveSideways()
    {
        inputX = Input.GetAxis("Horizontal");

        sideMovement = inputX * speed + Time.deltaTime;
        playerManager._rb.velocity = new Vector2(sideMovement, playerManager._rb.velocity.y);

       // playerManager.playerAnimations.animatorLink.SetFloat("Speed", sideMovement);
       // playerManager.playerAnimations.animatorLink.SetBool("Flipped", flipped);

        if (inputX < 0)
        {
            flipped = true;
            //Debug.Log("Going Left");
            transform.localScale = new Vector2(-1, 1);

        }
        else if (inputX > 0)
        {
            flipped = false;
            //Debug.Log("Going Right");
            transform.localScale = new Vector2(1, 1);
        }
    }
}
