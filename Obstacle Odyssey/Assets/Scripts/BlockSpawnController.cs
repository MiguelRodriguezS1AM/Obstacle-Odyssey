using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockSpawnController : MonoBehaviour
{
    public List<GameObject> blockPrefabs;
    public GameObject punto;
    public Text numberText;  // Referencia al objeto de texto que muestra el número
    public Color startColor = Color.white;  // Color inicial de los obstáculos
    public Color targetColor = Color.blue;  // Color objetivo de los obstáculos
    public float spawnRate = 1.0f;
    public float spawnX = -5.0f;
    public float spawnY = 0.0f;
    public float spawnPointY = 0.0f;
    public float initialFallSpeed = 10.0f;

    private float nextSpawnTime = 0.0f;
    private int cont = 0;
    private int blocks = 0;
    private Renderer objectRenderer;
    private Color currentColor;

    private AudioSource audioSource;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentColor = startColor;
        objectRenderer.material.color = currentColor;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {

            int num = int.Parse(numberText.text);
            if (num > 10)
            {
                // Cambiar el color actual al color objetivo
                currentColor = targetColor;
            }
            else if (num > 20)
            {
                // Cambiar el color actual a otro color deseado
                currentColor = Color.red;  // Reemplaza esto con el color que desees
            }
            int index;
            // Seleccionar un bloque aleatorio de la lista
            if (cont < 5)
            {
                index = Random.Range(0, 3);
            }
            else
            {
                index = Random.Range(0, blockPrefabs.Count);
            }

            if (blocks > 5)
            {
                Physics2D.gravity = new Vector2(0f, -10f);
                spawnRate = 2.0f;
            }

            if (blocks > 10)
            {
                Physics2D.gravity = new Vector2(0f, -20f);
                spawnRate = 1.6f;
            }

            if (blocks > 15)
            {
                Physics2D.gravity = new Vector2(0f, -25f);
                spawnRate = 1.4f;
            }

            if (blocks > 20)
            {
                Physics2D.gravity = new Vector2(0f, -35f);
                spawnRate = 1.1f;
            }
            if (blocks > 25)
            {
                Physics2D.gravity = new Vector2(0f, -55f);
                spawnRate = 0.9f;
            }

            if (blocks > 30)
            {
                Physics2D.gravity = new Vector2(0f, -80f);
                spawnRate = 0.8f;
            }

            // Instanciar el bloque en la posición especificada por spawnX y spawnY
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            GameObject blockObject = Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);

            Vector3 spawnPositionPoint = new Vector3(spawnX, spawnPointY, 0.0f);
            Instantiate(punto, spawnPositionPoint, Quaternion.identity);

            // Establecer el próximo tiempo de aparición
            nextSpawnTime = Time.time + spawnRate;

            cont++;
            blocks++;

            // Asignar el color actual al bloque
            Renderer blockRenderer = blockObject.GetComponent<Renderer>();
            blockRenderer.material.color = currentColor;

            // Obtener el componente Rigidbody2D del bloque
            Rigidbody2D blockRigidbody = blockObject.GetComponent<Rigidbody2D>();

            // Activar el Rigidbody2D y establecer la velocidad inicial de caída
            blockRigidbody.simulated = true;
            blockRigidbody.velocity = new Vector2(0f, -initialFallSpeed);
        }
    }

    private void OnDestroy()
    {
        audioSource.Stop();
    }
}
