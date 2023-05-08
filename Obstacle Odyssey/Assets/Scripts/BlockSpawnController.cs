using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    public List<GameObject> blockPrefabs;
    public float spawnRate = 1.0f;
    public float spawnHeight = 10.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;

    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Seleccionar un bloque aleatorio de la lista
            int index = Random.Range(0, blockPrefabs.Count);

            // Instanciar el bloque en la posición correcta
            Vector3 spawnPosition = new Vector3(Random.Range(leftBound, rightBound), spawnHeight, 0.0f);
            Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);

            // Establecer el próximo tiempo de aparición
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
