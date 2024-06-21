using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public PlayerMovement playerMovement;
    [HideInInspector]
    public PlayerAnimation playerAnimations;
    public GameObject leftPoint;
    public GameObject rightPoint;
    [HideInInspector]
    public Rigidbody2D _rb;

    [Header("Flags")]
    [HideInInspector]
    public bool playerDead;
    [SerializeField] GameObject playerCamera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
}
