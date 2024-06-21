using System.Collections;
using System.Collections.Generic;
using System.Net;
using TreeEditor;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    //all start offsets should be negative
    //all end offsets should be positive
    [SerializeField] private float startOffset;
    [SerializeField] private float endOffset;
    [SerializeField] private float speed;

    bool isAtStart;
    float worldStartPos, worldEndPos;

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

        transform.position = Vector2.right * moveDir;

        if (transform.position.x <= worldStartPos)
            isAtStart = true;
        if (transform.position.x >= worldEndPos)
            isAtStart = false;




    }
}
