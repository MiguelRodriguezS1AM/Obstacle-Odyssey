using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 offset;
    private CircleCollider2D circleCollider2D;
    private RectTransform rectTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rectTransform = GetComponent<RectTransform>();
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
        if (collision.gameObject.tag == "Obstaculo")
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("GameOver");
        }

        if (collision.gameObject.tag == "punto")
        {
            Destroy(collision.gameObject);
            Debug.Log("Punto");
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
