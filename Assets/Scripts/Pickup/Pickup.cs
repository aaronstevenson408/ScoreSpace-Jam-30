using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Pickup : MonoBehaviour
{
    Camera cam;
    Vector2 screenView;
    [SerializeField] AudioClip pickup;
    SoundManager soundManager;
    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        CameraViewToScreen();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            soundManager.ChangeSFX(pickup);
            DoSomething();
            Destroy(gameObject);
        }
    }
    protected virtual void DoSomething() { }
    public void CameraViewToScreen()
    {
        screenView = cam.WorldToViewportPoint(transform.position);
        if (screenView.y < 0)
        {
            Destroy(gameObject);
            // Debug.Log("Destroyed");
        }
    }
}