using System.Collections;
using System.Collections.Generic;
using System.Net;
using TreeEditor;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
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

        transform.position = Vector2.up * moveDir;

        if (transform.position.y <= worldStartPos)
            isAtStart = true;
        if (transform.position.y >= worldEndPos)
            isAtStart = false;




    }
}
