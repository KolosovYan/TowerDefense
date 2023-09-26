using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private List<MoveEnemy> enemys;
    [SerializeField] private Transform cashedTransform;

    [Header("Settings")]

    [SerializeField] private float startDelay;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void CreateEnemy()
    {
        MoveEnemy temp = Instantiate(enemys[Random.Range(0, enemys.Count)], cashedTransform.position, Quaternion.identity);
        temp.SetPath(waypoints);
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            CreateEnemy();
        }
    }
}
