using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour
{
    #region Scalars
    public float frictionCoefficient = -0.05f;
    public int frameSampleUnit = 5;
    public float forceMultiplier = 3.5f;
    #endregion

    public GameObject mainCamera;
    public Rigidbody2D rb2D;
    public UnityEvent releaseEvent;
    //private Vector3 screenPoint;
    private Vector3 offset;

    // Variables to hold current and previous mouse coordinates
    private Vector2 mouseDelta;
    private Vector2 prevMousePos;

    private int frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        mouseDelta = Vector2.zero;
        prevMousePos = Vector2.zero;
        frameCounter = 0;
    }

    // Using FixedUpdate because physics calculations are involved.
    void FixedUpdate()
    {
        // Apply friction in opposite direction of movement.
        rb2D.velocity += new Vector2(frictionCoefficient * rb2D.velocity.x, frictionCoefficient * rb2D.velocity.y);
    }

    void OnMouseDown()
    {
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;

        // Only sample once every few frames to prevent displacement being calculated as 0.
        if (++frameCounter % frameSampleUnit == 0)
        {
            // Update mouse coordinate variables while item is being dragged.
            mouseDelta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - prevMousePos;
            prevMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            frameCounter = 0;
        }

        // Disable collisions with other objects while dragging.
        GetComponent<Collider2D>().enabled = false;
        //Debug.Log(string.Format("mouseDelta: {0}, prevMousePos: {1}", mouseDelta, prevMousePos));
    }

    private void OnMouseUp()
    {
        //Debug.Log(string.Format("mouseDelta: {0}", mouseDelta));
        rb2D.velocity = Vector2.zero;

        // Multiply by scalar to heighten overall speed.
        rb2D.AddForce(mouseDelta * forceMultiplier);

        // Object is not being dragged; re-enable collisions with other objects.
        GetComponent<Collider2D>().enabled = true;
        releaseEvent.Invoke();  
    }
}