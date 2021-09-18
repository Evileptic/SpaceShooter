using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;
    public Transform EnemiesSpawnPoint;
    public Transform EnemiesMoveLimit;

    private Configuration confuguration;
    private LevelManager levelManager;
    private int currentEnemiesCount;
    private float enemySpawnTime;

    private void Awake() => Instance = this;

    private void Start()
    {
        confuguration = Configuration.Instance;
        levelManager = LevelManager.Instance;
    }
    
    private void Update()
    {
        if (Time.time > enemySpawnTime)
        {
            if (currentEnemiesCount < confuguration.EnemiesCount)
                SpawnEnemy();
            enemySpawnTime = Time.time + confuguration.EnemySpawnDuration;
        }
    }

    public void DestroyEnemy(EnemyActor enemyActor)
    {
        currentEnemiesCount--;

        var destroyParticle = Instantiate(confuguration.PlayerDestroyParticle, enemyActor.transform.position, Quaternion.identity);
        Destroy(enemyActor.gameObject);
        Destroy(destroyParticle.gameObject, 5f);
    }

    private void SpawnEnemy()
    {
        currentEnemiesCount++;

        var enemySpawnPoint = Vector3.zero;
        enemySpawnPoint.x = Random.Range(levelManager.LeftLevelLimit.transform.position.x, levelManager.RightLevelLimit.transform.position.x);
        enemySpawnPoint.y = EnemiesSpawnPoint.transform.position.y;

        var spawnedPlanet = Instantiate(confuguration.EnemyPrefab, enemySpawnPoint, Quaternion.identity);
        spawnedPlanet.MoveSpeed = confuguration.EnemiesSpeed;
    }
}
