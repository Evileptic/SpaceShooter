using UnityEngine;

public class Configuration : MonoBehaviour
{
    public static Configuration Instance = null;

    private void Awake() => Instance = this;

    [Header("Player Config")]
    [Range(0f, 20f)]
    public float PlayerSpeed = 15f;
    public BulletActor PlayerBulletPrefab;
    public float PlayerBulletSpeed;
    public float PlayerRespawnDelay;
    public ParticleSystem PlayerDestroyParticle;

    [Header("Level Config")]
    [Range(0f, 1f)]
    public float SpaceBackSpeed = 0.15f;
    [Range(0f, 1f)]
    public float SpaceForeSpeed = 0.3f;
    public float PlanetsHorizontalRange;
    public PlanetActor[] PlanetPrefabs;
    public float PlanetSpawnDelay;
    public float PlanetSpawnMinZLimit = 100f;
    public float PlanetSpawnMaxZLimit = 120f;
    public float PlanetSpawnMinScaleLimit = 1f;
    public float PlanetSpawnMaxScaleLimit = 3f;
    public float PlanetSpawnMinSpeedLimit = 1f;
    public float PlanetSpawnMaxSpeedLimit = 2f;

    [Header("Enemies Config")]
    public int EnemiesCount;
    public float EnemiesSpeed;
    public float EnemySpawnDuration;
    public float EnemyShootDelay;
    public EnemyActor EnemyPrefab;
    public BulletActor EnemyBulletPrefab;
    public float EnemyBulletSpeed;
    public float EnemyRespawnDelay;

    [Header("Others Config")]
    public float CameraSmooth;
    public float BulletsDestroyDelay;
    public float PlayerEngineInputThreshold;

    [Header("Sound Clips")]
    public AudioClip ShootClip;
    public AudioClip ExplosionClip;
}