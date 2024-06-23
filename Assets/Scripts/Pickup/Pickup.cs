using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Camera cam;
    Vector2 screenView;
    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        CameraViewToScreen();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
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
