using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject mainCamera;
    public Rigidbody2D rb2D;

    //private Vector3 screenPoint;
    private Vector3 offset;

    // Variables to hold current and previous mouse coordinates
    private Vector2 mouseDelta = Vector2.zero;
    private Vector2 prevMousePos = Vector2.zero;

    private int frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Apply friction in opposite direction of movement.
        rb2D.velocity += new Vector2(-0.01f * rb2D.velocity.x, -0.01f * rb2D.velocity.y);
    }

    void OnMouseDown()
    {
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y/*, screenPoint.z*/);
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
        
        // Only sample once every few frames to prevent displacement being calculated as 0.
        if (++frameCounter % 5 == 0)
        {
            // Update mouse coordinate variables while item is being dragged.
            mouseDelta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - prevMousePos;
            prevMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            frameCounter = 0;
        }

        //Debug.Log(string.Format("mouseDelta: {0}, prevMousePos: {1}", mouseDelta, prevMousePos));
    }

    private void OnMouseUp()
    {
        //Debug.Log(string.Format("mouseDelta: {0}", mouseDelta));
        rb2D.velocity = Vector2.zero;

        // Multiply by scalar to amp up overall speed.
        rb2D.AddForce(mouseDelta * 3);
    }
}