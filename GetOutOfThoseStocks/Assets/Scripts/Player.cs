using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Transform exit;
    Rigidbody2D rb;
    void Start()
    {
        exit = GameObject.FindGameObjectWithTag("Exit").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (exit.position - transform.position).normalized;
    }
}
