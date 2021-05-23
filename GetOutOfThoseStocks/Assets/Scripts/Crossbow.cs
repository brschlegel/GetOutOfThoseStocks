using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public Transform arrow;
    public bool fired;
    void Start()
    {
        fired = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(fired)
        {
        Transform t = Instantiate(arrow, transform.position, Quaternion.identity);
        Rigidbody2D r = t.GetComponent<Rigidbody2D>();
        r.velocity =  transform.right * 31;
        // r.AddForce( transform.right * 100000);
        fired = false;
        }
    }
}
