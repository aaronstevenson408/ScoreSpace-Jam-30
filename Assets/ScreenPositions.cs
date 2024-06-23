using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositions : MonoBehaviour
{
    public float leftSide;
    public float rightSide;
    public float topSide;
    public float BottomSide;
    private void Update()
    {
        Camera cam = Camera.main;
        leftSide = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightSide = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, 0)).x;
        topSide = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0)).y;
        BottomSide = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }
}
