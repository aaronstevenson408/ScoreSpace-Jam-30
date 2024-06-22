using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Hazards : MonoBehaviour
{
    [HideInInspector]
    public MovementType type;
    public bool goingBetweenTwoPoints;

    [Header("Two Point Movement")]
    [HideInInspector]
    public GameObject pointA;
    [HideInInspector]
    public GameObject pointB;
    [HideInInspector]
    public int speed;
    [HideInInspector]
    public bool isAtPointA;
    private void Awake()
    {
    }
    private void Update()
    {
        if (goingBetweenTwoPoints)
        {
            Debug.Log("Going between two points");
            MoveBetweenTwoPoints();
        }
        else
        {

        }
    }

    public void MoveBetweenTwoPoints()
    {
        if (isAtPointA)
        {
            Debug.Log("Going To B");
            gameObject.transform.Translate(Vector2.right * speed/100);
            gameObject.transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            Debug.Log("Going To A");
            gameObject.transform.Translate(-Vector2.right * speed/100);
            gameObject.transform.localScale = new Vector2(1, 1);
        }

        if (pointA.name != "PointA")
        {
            pointA.name = "PointA";
        }
        if (pointB.name != "PointB")
        {
            pointB.name = "PointB";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerManager>().Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goingBetweenTwoPoints)
        {
            if (collision.gameObject.name == "PointA")
            {
                isAtPointA = true;
            }
            if (collision.gameObject.name == "PointB")
            {
                isAtPointA = false;
            }
        }
    }
}

[CustomEditor(typeof(Hazards))]
public class MovementType: Editor
{


    private void OnEnable()
    {
        
    }
    public override void OnInspectorGUI()
    {
        var hazards = (Hazards)target;
        hazards.type = this;
        base.OnInspectorGUI();
        hazards.goingBetweenTwoPoints = EditorGUILayout.Toggle(hazards.goingBetweenTwoPoints, "Going Between Two Points");
            if (hazards.goingBetweenTwoPoints)
            {
            hazards.pointA = (GameObject)EditorGUILayout.ObjectField("Point A", hazards.pointA, typeof(GameObject),true);
            hazards.pointB = (GameObject)EditorGUILayout.ObjectField("Point B", hazards.pointB,typeof(GameObject),true);
            hazards.speed = EditorGUILayout.IntField("Speed", hazards.speed);
        }
    }
   
}
