using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReynoldsAgent : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    public Vector2 avoidance;
    public Vector2 vel;
    public float speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveToTarget(Transform target)
    {
        vel = (target.position - transform.position).normalized;
        vel += avoidance;
        transform.right = vel.normalized;
        rigidbody.velocity = transform.right;
        //avoidance = Vector2.zero;
    }

    public Vector2 AvoidObstacles()
    {
        return Vector2.zero;
    }
     void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Obstacle")
        {
        float distance = Vector2.Distance(transform.position, collider.gameObject.transform.position);
        Vector2 ctc = collider.gameObject.transform.position - transform.position;
        float dot = Vector2.Dot(ctc, transform.right);
        avoidance = transform.up * Mathf.Sign(dot) * (1/distance);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        avoidance = Vector2.zero;
    }
}
public class Guard : ReynoldsAgent
{
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        MoveToTarget(player);
    }

    void OnTriggerEnter2d(Collider2D collider)
    {
        Debug.Log("Collider");
    }
}
