using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnRate = 1.0f;
    public float spawnHeight = 10.0f;

    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Instanciar el bloque en la posici�n correcta
            Vector3 spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), spawnHeight, 0.0f);
            Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

            // Establecer el pr�ximo tiempo de aparici�n
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
