using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float minSize = 1;
    [SerializeField] private float maxSize = 5;
    [SerializeField] private Transform bubbleSprite;

    void Start()
    {
        // bubbleSprite.localScale = new Vector3(minSize, minSize, minSize);
    }

    // Update is called once per frame
    void Update()
    {
        //bubble grows in size based on time
        //float sizeAmt = GameTime.Instance.GetTime / maxSize;
        //float sizeAmt = time + minSize;
        // sizeAmt = Mathf.Clamp(sizeAmt, minSize, maxSize);
        // bubbleSprite.localScale = Vector3.one * sizeAmt;



    }

    public void Pop()
    {
        bubbleSprite.gameObject.SetActive(false);
        bubbleSprite.localScale = new Vector3(minSize, minSize, minSize);
        //lose
    }
}
