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
    [SerializeField] private float growSpeed = 1.5f;
    [SerializeField] private Transform bubbleSprite;

    float timer;
    float slowAmt;
    bool isSlow = false;

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
        timer += Time.deltaTime;
        //bubble grows in size based on time
        if (canGrow)
        {
            if (!isSlow) Grow(timer / maxSize * growSpeed);
            else Grow(slowAmt);
        }
    }

    void Grow(float amt)
    {
        Debug.Log(amt);
        amt = Mathf.Clamp(amt, minSize, maxSize);
        bubbleSprite.localScale = Vector3.one * amt;

    }

    public IEnumerator SlowSpeed(float slowAmt, float slowTime)
    {
        //slow bubble growth
        isSlow = true;
        Debug.Assert(true, "slow down---------------------------------------");
        this.slowAmt = slowAmt * growSpeed;
        yield return new WaitForSeconds(slowTime);
        isSlow = false;
        Debug.Assert(true, "slow down end---------------------------------------");


    }

    public IEnumerator Invulnerability(float invinsibilityTime)
    {
        canGrow = false;
        yield return new WaitForSeconds(invinsibilityTime);
        canGrow = true;
        StopCoroutine("Invulnerability");
    }

    public void Pop()
    {
        if (bubbleSprite != null)
        {
            bubbleSprite.gameObject.SetActive(false);
            bubbleSprite.localScale = new Vector3(minSize, minSize, minSize);
        }
        WorldManager.Instance.End();
        //lose
    }
}
