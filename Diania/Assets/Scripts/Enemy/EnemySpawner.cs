using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPool;

    [SerializeField] private float _radius = 10f;

    [SerializeField] private float _spawnTimer = 1f;

    private float _lastSetTime;

    void Update()
    {
        if (Time.time - _lastSetTime >= _spawnTimer)
        {
            SpawnEnemy();
            _lastSetTime = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemyPrefab = _enemyPool[Random.Range(0, _enemyPool.Count)];

        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * _radius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius); // draw a wireframe circle
    }
}
