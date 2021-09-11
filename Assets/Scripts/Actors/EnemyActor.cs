using UnityEngine;

public class EnemyActor : MoveDown
{
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
    }
}
