using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Hazards : MonoBehaviour
{
    [HideInInspector]
    public MovementType type;
    Rigidbody2D _rb;

    [Header("Two Point Movement")]
    public bool goingBetweenTwoPoints;
    [HideInInspector]
    public GameObject pointA;
    [HideInInspector]
    public GameObject pointB;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public bool isAtPointA;

    [Header("Two Point Movement")]
    public bool usingDropPoint;
    [HideInInspector]
    public GameObject dropPoint;
    [HideInInspector]
    public float _gravity;
    bool isDropped;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (goingBetweenTwoPoints)
        {
            usingDropPoint = false;
            Debug.Log("Going between two points");
            MoveBetweenTwoPoints();
        }
        else if(usingDropPoint)
        {

            DropHazard();
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
    public void DropHazard()
    {
        if(isDropped == false)
        {
            gameObject.transform.position = dropPoint.transform.position;
            _rb.gravityScale = _gravity;
            isDropped = true;
            Invoke("SelfDestruct", 5f);
        }
    }
    void SelfDestruct()
    {
        if (gameObject.transform.parent != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        hazards.usingDropPoint = EditorGUILayout.Toggle(hazards.usingDropPoint, "Drop Point");
        if (hazards.goingBetweenTwoPoints)
            {
            hazards.pointA = (GameObject)EditorGUILayout.ObjectField("Point A", hazards.pointA, typeof(GameObject),true);
            hazards.pointB = (GameObject)EditorGUILayout.ObjectField("Point B", hazards.pointB,typeof(GameObject),true);
            hazards.speed = EditorGUILayout.FloatField("Speed", hazards.speed);
        } else if (hazards.usingDropPoint)
        {
            hazards.dropPoint = (GameObject)EditorGUILayout.ObjectField("DropPoint", hazards.dropPoint, typeof(GameObject), true);
            hazards._gravity = EditorGUILayout.FloatField("Speed", hazards._gravity);
        }
    }
   
}
