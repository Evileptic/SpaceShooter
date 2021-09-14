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
            AudioSource.PlayOneShot(Configuration.Instance.EnemyShootClip);
            Instantiate(Configuration.Instance.EnemyBulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.EnemyBulletSpeed;
            shootTime = Time.time + Configuration.Instance.EnemyShootDelay;
        }
    }
}
