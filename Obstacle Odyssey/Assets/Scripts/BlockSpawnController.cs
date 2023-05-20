using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    public List<GameObject> blockPrefabs;
    public GameObject punto;
    public float spawnRate = 1.0f;
    public float spawnX = -5.0f;
    public float spawnY = 0.0f; // Coordenada Y donde se generarán los objetos

    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Seleccionar un bloque aleatorio de la lista
            int index = Random.Range(0, blockPrefabs.Count);

            // Instanciar el bloque en la posición especificada por spawnX y spawnY
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);

            Instantiate(punto, spawnPosition, Quaternion.identity);

            // Establecer el próximo tiempo de aparición
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
