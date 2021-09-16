using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BulletActor>(out var bulletActor))
        {
            if (bulletActor.BulletOwner == BulletOwner.ENEMY)
            { 
                Destroy(bulletActor.gameObject);
                PlayerManager.Instance.DestroyPlayer();
            }
        }
    }
}