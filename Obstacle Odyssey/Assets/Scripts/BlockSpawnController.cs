using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    public List<GameObject> blockPrefabs;
    public float spawnRate = 1.0f;
    public float spawnX = -5.0f;

    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Seleccionar un bloque aleatorio de la lista
            int index = Random.Range(0, blockPrefabs.Count);

            // Obtener la altura del objeto proporcionado
            float blockHeight = GetBlockHeight(blockPrefabs[index]);

            // Instanciar el bloque en la posición correcta
            Vector3 spawnPosition = new Vector3(spawnX, transform.position.y + blockHeight / 2, 0.0f);
            Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);

            // Cambiar de Static a Dynamic
            Rigidbody2D blockRigidbody = blockPrefabs[index].GetComponent<Rigidbody2D>();
            if (blockRigidbody != null)
            {
                blockRigidbody.bodyType = RigidbodyType2D.Dynamic;
            }

            // Establecer el próximo tiempo de aparición
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private float GetBlockHeight(GameObject blockPrefab)
    {
        // Buscar un objeto hijo con Collider2D o SpriteRenderer
        Collider2D blockCollider = blockPrefab.GetComponentInChildren<Collider2D>();
        SpriteRenderer blockRenderer = blockPrefab.GetComponentInChildren<SpriteRenderer>();

        if (blockCollider != null)
        {
            return blockCollider.bounds.size.y;
        }
        else if (blockRenderer != null)
        {
            return blockRenderer.bounds.size.y;
        }

        // Si no se encuentra Collider2D ni SpriteRenderer, retornar una altura predeterminada
        return 1.0f; // Puedes ajustar este valor según tus necesidades
    }
}
