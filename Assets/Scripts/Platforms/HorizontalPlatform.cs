using System.Collections;
using System.Collections.Generic;
using System.Net;
using TreeEditor;
using UnityEngine;

public class HorizontalPlatform : Platform
{

    // Start is called before the first frame update
    void Start()
    {
        worldStartPos = transform.position.x + startOffset;
        worldEndPos = transform.position.x + endOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float currentXPos = transform.position.x;
        float moveDir = isAtStart ?
            currentXPos + speed * Time.deltaTime :
            currentXPos - speed * Time.deltaTime;

        transform.position = new Vector2(moveDir, transform.position.y);

        if (transform.position.x <= worldStartPos)
            isAtStart = true;
        if (transform.position.x >= worldEndPos)
            isAtStart = false;
    }
}
