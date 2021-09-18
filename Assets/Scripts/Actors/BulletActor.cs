public enum BulletOwner { PLAYER, ENEMY }

public class BulletActor : MoveActor
{
    public BulletOwner BulletOwner;

    private void Start() => Destroy(gameObject, Configuration.Instance.BulletsDestroyDelay);

    public override void Update() => base.Update();
}