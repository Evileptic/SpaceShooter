using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;
    public Transform EnemiesSpawnPoint;
    public Transform EnemiesMoveLimit;

    public int currentEnemiesCount;
    private float enemySpawnTime;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (Time.time > enemySpawnTime)
        {
            if (currentEnemiesCount < Configuration.Instance.EnemiesCount)
                SpawnEnemy();
            enemySpawnTime = Time.time + Configuration.Instance.EnemySpawnDuration;
        }
    }

    public void DestroyEnemy(EnemyActor enemyActor)
    {
        currentEnemiesCount--;
        var destroyParticle = Instantiate(Configuration.Instance.PlayerDestroyParticle, enemyActor.transform.position, Quaternion.identity);
        Destroy(enemyActor.gameObject);
        Destroy(destroyParticle.gameObject, 5f);
    }

    private void SpawnEnemy()
    {
        currentEnemiesCount++;
        var enemySpawnPoint = Vector3.zero;
        enemySpawnPoint.x = Random.Range(LevelManager.Instance.LeftLevelLimit.transform.position.x, LevelManager.Instance.RightLevelLimit.transform.position.x);
        enemySpawnPoint.y = EnemiesSpawnPoint.transform.position.y;
        var spawnedPlanet = Instantiate(Configuration.Instance.EnemyPrefab, enemySpawnPoint, Quaternion.identity);
        spawnedPlanet.MoveSpeed = Configuration.Instance.EnemiesSpeed;
    }
}
