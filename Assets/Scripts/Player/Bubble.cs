using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //there is only one bubble in the scene
    PlayerManager playerManager;
    private static Bubble instance;
    public static Bubble Instance { get { return instance; } }
    [SerializeField] private Transform bubbleSprite;
      float growamount;

    void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        instance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Grow();
        //bubble grows in size based on time
    }
    public void Grow()
    {
        growamount += .00005f;
        if (growamount <5)
        {
            if (growamount > 2)
            {
                transform.localScale = new Vector3(growamount, growamount, growamount);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
        } else
        {
            transform.localScale = new Vector3(5, 5, 5);
        }
       
    }
    public void Pop()
    {
        if (bubbleSprite != null)
        {
            bubbleSprite.gameObject.SetActive(false);
            bubbleSprite.localScale = new Vector3(2, 2, 2);
        }
        WorldManager.Instance.End();
        //lose
    }
}
