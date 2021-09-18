using UnityEngine;

public class EnemyActor : MoveActor
{
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private AudioSource AudioSource;

    private Configuration configuration;
    private EnemyManager enemyManager;
    private float shootTime;

    private void Start()
    {
        configuration = Configuration.Instance;
        enemyManager = EnemyManager.Instance;
    }

    public override void Update()
    {
        base.Update();

        if (transform.position.y < enemyManager.EnemiesMoveLimit.position.y)
        {
            Vector3 respawnPosition = Vector3.zero;
            respawnPosition.x = transform.position.x;
            respawnPosition.y = enemyManager.EnemiesSpawnPoint.position.y;
            transform.position = respawnPosition;
        }

        if (Time.time > shootTime)
        {
            AudioSource.PlayOneShot(configuration.ShootClip);
            Instantiate(configuration.EnemyBulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = configuration.EnemyBulletSpeed;
            shootTime = Time.time + configuration.EnemyShootDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BulletActor>(out var bulletActor))
        {
            if (bulletActor.BulletOwner == BulletOwner.PLAYER)
            {
                Destroy(bulletActor.gameObject);
                enemyManager.DestroyEnemy(this);
            }
        }
    }
}
