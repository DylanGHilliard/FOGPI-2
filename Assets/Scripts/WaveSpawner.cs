using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public int amtToSpawn;
    public float spawnInterval;
    private float spawnTimer;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(10, 10);

    public bool IsValidSpawnPoint(Vector2 _pos)
    {
        // Check if position is on the ground layer
        Collider2D[] hitCollider = Physics2D.OverlapPointAll(_pos, ~groundLayer);
        return hitCollider.Length != 0;
    }

    private Vector2 GetRandomPos() {
        int maxAttempts = 30;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Generate random position within spawn area
            float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float randomY = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, 0);

            // Check if position is valid
            if (IsValidSpawnPoint(randomPosition))
            {
                return randomPosition;
            }
        }

        Debug.LogWarning("Could not find Valid spawn Position");
        return transform.position;
        

    }


    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval && amtToSpawn >0)
        {
             Vector2 spawnPosition = GetRandomPos();
            if (spawnPosition != new Vector2(transform.position.x, transform.position.y)) // Only spawn if valid position found
            {
                GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Count)];
                Instantiate(enemyToSpawn,  spawnPosition, Quaternion.identity, this.transform);
                amtToSpawn--;
                spawnTimer = 0f;
                
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 1));
    }
}
