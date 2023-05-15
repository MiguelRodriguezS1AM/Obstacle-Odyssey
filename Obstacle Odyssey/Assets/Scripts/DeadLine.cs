using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "ball")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
