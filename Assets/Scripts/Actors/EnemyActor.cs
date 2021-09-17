using UnityEngine;

public class EnemyActor : MoveActor
{
    public Transform BulletSpawnPoint;
    public AudioSource AudioSource;

    private float shootTime;

    public override void Update()
    {
        base.Update();

        if (transform.position.y < EnemyManager.Instance.EnemiesMoveLimit.position.y)
        {
            Vector3 respawnPosition = Vector3.zero;
            respawnPosition.x = transform.position.x;
            respawnPosition.y = EnemyManager.Instance.EnemiesSpawnPoint.position.y;
            transform.position = respawnPosition;
        }

        if (Time.time > shootTime)
        {
            AudioSource.PlayOneShot(Configuration.Instance.ShootClip);
            Instantiate(Configuration.Instance.EnemyBulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.EnemyBulletSpeed;
            shootTime = Time.time + Configuration.Instance.EnemyShootDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BulletActor>(out var bulletActor))
        {
            if (bulletActor.BulletOwner == BulletOwner.PLAYER)
            {
                Destroy(bulletActor.gameObject);
                EnemyManager.Instance.DestroyEnemy(this);
            }
        }
    }
}
