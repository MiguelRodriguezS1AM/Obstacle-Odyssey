using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 offset;
    private CircleCollider2D circleCollider2D;
    private BoxCollider2D boxCollider2D;
    private RectTransform rectTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        boxCollider2D = GameObject.FindGameObjectWithTag("Square").GetComponent<BoxCollider2D>();
        rectTransform = GameObject.FindGameObjectWithTag("Square").GetComponent<RectTransform>();
    }

    private void OnMouseDown()
    {
        isDragging = true;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StaticObject")
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StaticObject")
        {
            transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}