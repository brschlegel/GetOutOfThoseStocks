using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ReynoldsAgent
{

    Transform exit;

    void Start()
    {
        exit = GameObject.FindGameObjectWithTag("Exit").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(exit);
    }
}
