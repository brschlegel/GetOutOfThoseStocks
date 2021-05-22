using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ReynoldsAgent
{
    // Flag to track win/lose conditions. Value observed by GameManager.
    public bool exited;
    public bool caught;
    Transform exit;

    void Start()
    {
        ResetFlags();
        exit = GameObject.FindGameObjectWithTag("Exit").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        transform.right =- (exit.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(exit);
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
