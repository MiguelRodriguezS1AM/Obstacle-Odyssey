using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    public List<GameObject> blockPrefabs;
    public GameObject punto;
    public float spawnRate = 1.0f;
    public float spawnX = -5.0f;
    public float spawnY = 0.0f;
    public float spawnPointY = 0.0f;
    public Rigidbody2D player;

    private float nextSpawnTime = 0.0f;
    private int cont = 0;
    private int index = 0;

    private int blocks = 0;


    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {

            // Seleccionar un bloque aleatorio de la lista
            if (cont < 5)
            {
                index = Random.Range(0, 3);
            }
            else
            {
                index = Random.Range(0, blockPrefabs.Count);
            }

            if(blocks > 5)
            {
                Physics2D.gravity = new Vector2(0f, -20f);
                spawnRate = 2.0f;
            }

            if (blocks > 10)
            {
                Physics2D.gravity = new Vector2(0f, -30f);
                spawnRate = 2.5f;

            }

            if (blocks > 15)
            {
                Physics2D.gravity = new Vector2(0f, -40f);
                spawnRate = 3.0f;

            }

            if (blocks > 20)
            {
                Physics2D.gravity = new Vector2(0f, -45f);
                spawnRate = 3.0f;
            }

            // Instanciar el bloque en la posición especificada por spawnX y spawnY
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);

            Vector3 spawnPositionPoint = new Vector3(spawnX, spawnPointY, 0.0f);
            Instantiate(punto, spawnPositionPoint, Quaternion.identity);

            // Establecer el próximo tiempo de aparición
            nextSpawnTime = Time.time + spawnRate;
            cont++;

            blocks++;
        }
    }
}
