using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float boundOffset;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private float enemySpawnDelay;

    private Enemy enemy;
    private Vector3 screenBound;

    private void Awake()
    {
        enemy = Resources.Load<Enemy>("Prefabs/Enemies/Enemy");
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private void SpawnEnemies()
    {
        float randomPos_X = Random.Range(-screenBound.x + boundOffset, screenBound.x - boundOffset);
        Vector2 pos = new Vector2(randomPos_X, transform.position.y);
        PoolManager.instance.ReleaseFromThePool(enemy.gameObject, pos);
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while(true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }
}
