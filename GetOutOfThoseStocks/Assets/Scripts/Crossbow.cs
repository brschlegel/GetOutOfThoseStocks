using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public Transform arrow;
    public bool fired;

    public Sprite unloaded;
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
        if (fired)
        {
            Transform t = Instantiate(arrow, transform.position, transform.rotation);
            t.Rotate(new Vector3(0,0,-90));
            t.rotation = transform.rotation;
            Rigidbody2D r = t.GetComponent<Rigidbody2D>();
            r.velocity = transform.right * 41;
            // r.AddForce( transform.right * 100000);
            fired = false;
            GetComponent<SpriteRenderer>().sprite = unloaded;
        }
    }
}