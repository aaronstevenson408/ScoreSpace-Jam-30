using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// please disregard, this class does notseem to work very well
/// </summary>
public class OldPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float speed;

    bool isAtStart = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currXPos = transform.position.x;
        float currYPos = transform.position.y;
        float xOffset = 0, yOffset = 0;

        float moveX = isAtStart ?
            currXPos + speed * Time.deltaTime :
            currXPos + speed * Time.deltaTime;
        float moveY = isAtStart ?
            currYPos + speed * Time.deltaTime :
            currYPos + speed * Time.deltaTime;
        /*
                if (isAtStart)
                {
                    xOffset = endPos.y == 0 ? 1 : 1 / endPos.y;
                    yOffset = startPos.y == 0 ? 1 : 1 / startPos.y;

                    moveX = currXPos + speed * Time.deltaTime * xOffset;
                    moveY = currYPos + speed * Time.deltaTime * yOffset;
                }
                else
                {
                    xOffset = endPos.y == 0 ? 1 : 1 / endPos.y;
                    yOffset = startPos.y == 0 ? 1 : 1 / startPos.y;

                    moveX = currXPos - speed * Time.deltaTime * xOffset;
                    moveY = currYPos - speed * Time.deltaTime * yOffset;
                }
        */


        //have to check for 0

        //if at start, go towards end 
        //if at end, go towards start


        transform.position = new Vector2(moveX, moveY);

        if (((Vector2)transform.position - startPos).magnitude <= 0.3f)
            isAtStart = true;
        if (((Vector2)transform.position - endPos).magnitude <= 0.3f)
            isAtStart = false;

        Debug.Log(Vector2.Distance(transform.position, startPos) + " p: " + transform.position + " e: " + startPos + (((Vector2)transform.position - startPos).magnitude <= 0.3f));
    }
}
