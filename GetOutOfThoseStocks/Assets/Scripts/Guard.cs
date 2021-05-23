using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReynoldsAgent : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public Transform blood;
    public float avoidanceScalar = 1;
    public float goalBias;
    public Vector2 avoidance;

    public float speed;
    public bool stunned;

    public float turningScalar;




    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void MoveToTarget(Transform target)
    {
        if(!stunned)
        {
            Vector3 vec = (target.position - transform.position).normalized;
            Vector2 vel = new Vector2(vec.x, vec.y ) * goalBias;
            rigidbody.AddForce(vel.normalized * turningScalar);
            transform.right = rigidbody.velocity;
            //clamp velocity
           
      
            Debug.DrawRay(transform.position, vel.normalized, Color.green);
        //avoidance = Vector2.zero;
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
    Player player;

    public int checkpoint;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody2D>();
        transform.right =- (player.transform.position - transform.position).normalized;
        health = maxHealth;
    }


    void FixedUpdate()
    {
        if(player.checkpoint >= checkpoint)
        {
             MoveToTarget(player.transform);
        }
       
    
        if(health <= 0)
        {
            Die();
            Transform b = Instantiate(blood, transform.position, Quaternion.identity);
        }
    }

        void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Obstacle" && collider.relativeVelocity.magnitude > 4)
        {
            Debug.Log("Called");
            health -=  collider.relativeVelocity.magnitude;
            hb.SetScale(health, maxHealth);
            
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }


}
