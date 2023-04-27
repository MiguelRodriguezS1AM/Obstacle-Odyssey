using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSphere : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        // Clamp sphere's position within the limits of the square collider
        Collider2D squareCollider = GameObject.Find("Square").GetComponent<Collider2D>();
        float clampedX = Mathf.Clamp(transform.position.x, squareCollider.bounds.min.x, squareCollider.bounds.max.x);
        float clampedY = Mathf.Clamp(transform.position.y, squareCollider.bounds.min.y, squareCollider.bounds.max.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            // Snap sphere back to initial position if it collides with the square collider
            transform.position = initialPosition;
        }
    }
}
