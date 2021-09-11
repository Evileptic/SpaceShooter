using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;
    public Transform EnemiesSpawnPoint;
    public Transform EnemiesMoveLimit;

    [HideInInspector]
    public int currentEnemiesCount;
    private float enemySpawnTime;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (Time.time > enemySpawnTime)
        {
            if (currentEnemiesCount < Configuration.Instance.EnemiesCount)
            {
                currentEnemiesCount++;
                var enemySpawnPoint = Vector3.zero;
                enemySpawnPoint.x = Random.Range(LevelManager.Instance.LeftLevelLimit.transform.position.x, LevelManager.Instance.RightLevelLimit.transform.position.x);
                enemySpawnPoint.y = EnemiesSpawnPoint.transform.position.y;
                var spawnedPlanet = Instantiate(Configuration.Instance.EnemyPrefab, enemySpawnPoint, Quaternion.identity);
                spawnedPlanet.MoveSpeed = Configuration.Instance.EnemiesSpeed;
            }
            enemySpawnTime = Time.time + Configuration.Instance.EnemySpawnDuration;
        }
    }
}
