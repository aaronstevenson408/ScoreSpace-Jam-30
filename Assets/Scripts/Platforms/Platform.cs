using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //all start offsets should be negative
    //all end offsets should be positive
    [SerializeField] protected float startOffset;
    [SerializeField] protected float endOffset;
    [SerializeField] protected float speed;

    protected bool isAtStart;
    protected float worldStartPos, worldEndPos;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<Bubble>().Pop();
        }
    }


}
