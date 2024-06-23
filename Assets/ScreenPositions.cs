using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositions : MonoBehaviour
{
    public float leftSide;
    public float rightSide;
    public float topSide;
    public float bottomSide;

    private void Update()
    {
        CameraViewToScreen();
    }
    public void CameraViewToScreen()
    {
        Camera main = Camera.main;
        leftSide = main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightSide = main.ScreenToWorldPoint(new Vector3(main.pixelWidth,0, 0)).x;
        topSide = main.ScreenToWorldPoint(new Vector3(0, main.pixelHeight, 0)).y;
        bottomSide = main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }
}
