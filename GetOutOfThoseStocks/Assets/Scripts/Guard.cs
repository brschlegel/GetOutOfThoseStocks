using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed;
    Transform player;
    Rigidbody2D rigidbody;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rigidbody.velocity = (player.position - transform.position).normalized;
    }
}
