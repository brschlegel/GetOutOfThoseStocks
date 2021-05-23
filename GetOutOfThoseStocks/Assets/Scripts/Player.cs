using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ReynoldsAgent
{
    // Flag to track win/lose conditions. Value observed by GameManager.
    public bool exited;
    public bool caught;
    Transform exit;

    public int checkpoint;

    Transform checkpoints;

    void Start()
    {
        ResetFlags();
        exit = GameObject.FindGameObjectWithTag("Exit").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        transform.right =- (exit.position - transform.position).normalized;
        checkpoint = 0;
        checkpoints = GameObject.Find("Checkpoints").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget(checkpoints.GetChild(checkpoint));
        if(Vector2.Distance(checkpoints.GetChild(checkpoint).position, transform.position) < .5f)
        {
            checkpoint++;
        }
         rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }

    /// @return boolean T/F based on whether the level is completed.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Exit")
            exited = true;

        if (collision.gameObject.tag == "Guard")
            caught = true;
    }

    /// Resets boolean flags.
    public void ResetFlags()
    {
        exited = caught = false;
    }
}
