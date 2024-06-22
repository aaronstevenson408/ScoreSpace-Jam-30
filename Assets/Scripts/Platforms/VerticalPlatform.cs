using System.Collections;
using System.Collections.Generic;
using System.Net;
using TreeEditor;
using UnityEngine;

public class VerticalPlatform : Platform
{
    // Start is called before the first frame update
    void Start()
    {
        worldStartPos = transform.position.y + startOffset;
        worldEndPos = transform.position.y + endOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float currentYPos = transform.position.y;
        float moveDir = isAtStart ?
            currentYPos + speed * Time.deltaTime :
            currentYPos - speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x, moveDir);

        if (transform.position.y <= worldStartPos)
            isAtStart = true;
        if (transform.position.y >= worldEndPos)
            isAtStart = false;




    }
}
