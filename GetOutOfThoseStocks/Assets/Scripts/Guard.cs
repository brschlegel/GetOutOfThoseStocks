using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReynoldsAgent : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    public float avoidanceScalar = 1;
    public float goalBias;
    public Vector2 avoidance;
    public Vector2 vel;
    public float speed;
    public bool stunned;




    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void MoveToTarget(Transform target)
    {
        if(!stunned)
        {
            Vector3 vec = (target.position - transform.position).normalized;
            vel += new Vector2(vec.x, vec.y ) * goalBias;
            vel += avoidance;
            rigidbody.AddForce(vel.normalized);
            transform.right = rigidbody.velocity;
            //clamp velocity
            if(rigidbody.velocity.magnitude > 1)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * 3;
            }
            Debug.DrawRay(transform.position, transform.right, Color.green);
        //avoidance = Vector2.zero;
        }
    }

     void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Obstacle")
        {
        float distance = Vector2.Distance(transform.position, collider.gameObject.transform.position);
        Vector2 ctc = collider.gameObject.transform.position - transform.position;
        float dot = Vector2.Dot(ctc, transform.right);
        avoidance = transform.up * Mathf.Sign(dot) * (3/distance);
        Debug.DrawRay(transform.position, avoidance, Color.red);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        avoidance = Vector2.zero;
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.GetComponent<DragDrop>() != null && collider.relativeVelocity.magnitude > 2)
        {
            stunned = true;
            Invoke("Stun", 1.0f);
        }
    }

    void Stun()
    {
        stunned = false;
    }
}
public class Guard : ReynoldsAgent
{
    public float health = 10;
    public float maxHealth;

    public ObstacleAvoidance ob;
    public HealthBar hb;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        transform.right =- (player.position - transform.position).normalized;
        health = maxHealth;
        ob.target = player;
    }


    void FixedUpdate()
    {
        MoveToTarget(player);

        if(health <= 0)
            Die();
    }

        void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.GetComponent<DragDrop>() != null && collider.relativeVelocity.magnitude > 4)
        {
            health -=  collider.relativeVelocity.magnitude;
            hb.SetScale(health, maxHealth);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }


}
