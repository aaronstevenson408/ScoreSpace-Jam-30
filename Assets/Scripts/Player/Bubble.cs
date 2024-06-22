using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //there is only one bubble in the scene
    private static Bubble instance;
    public static Bubble Instance { get { return instance; } }

    [SerializeField] private bool canGrow;
    [SerializeField] private float minSize = 1;
    [SerializeField] private float maxSize = 5;
    [SerializeField] private float growSpeed = .02f;
    [SerializeField] private Transform bubbleSprite;

    float timer;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (canGrow)
            bubbleSprite.localScale = new Vector3(minSize, minSize, minSize);
    }

    // Update is called once per frame
    void Update()
    {
        //bubble grows in size based on time
        if (canGrow) Grow();
    }

    void Grow()
    {
        timer += Time.deltaTime;
        float sizeAmt = timer / maxSize * growSpeed;
        sizeAmt = Mathf.Clamp(sizeAmt, minSize, maxSize);
        bubbleSprite.localScale = Vector3.one * sizeAmt;
        //Debug.Log(bubbleSprite.localScale);

    }

    public void Pop()
    {
        bubbleSprite.gameObject.SetActive(false);
        bubbleSprite.localScale = new Vector3(minSize, minSize, minSize);
        WorldManager.Instance.End();
        //lose
    }
}
