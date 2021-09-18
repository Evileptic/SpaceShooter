using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;

    public Transform LeftLevelLimit;
    public Transform RightLevelLimit;

    [SerializeField] private Transform planetsSpawnPoint;
    [SerializeField] private MeshRenderer spaceBackground;
    [SerializeField] private MeshRenderer spaceForeground;

    private Configuration configuration;
    private float backsSpeedDecreaset = 1000f;
    private float planetSpawnTime;

    private void Awake() => Instance = this;

    private void Start() => configuration = Configuration.Instance;


    private void Update()
    {
        if (Time.time > planetSpawnTime)
        {
            var spawnPoint = Vector3.zero;
            spawnPoint.y = planetsSpawnPoint.transform.position.y;
            spawnPoint.x = Random.Range(-configuration.PlanetsHorizontalRange, configuration.PlanetsHorizontalRange);
            spawnPoint.z = Random.Range(configuration.PlanetSpawnMinZLimit, configuration.PlanetSpawnMaxZLimit);
            var planetForInstance = configuration.PlanetPrefabs[Random.Range(0, configuration.PlanetPrefabs.Length)];

            float spawnScale = Random.Range(configuration.PlanetSpawnMinScaleLimit, configuration.PlanetSpawnMaxScaleLimit);
            var spawnedPlanet = Instantiate(planetForInstance, spawnPoint, planetForInstance.transform.rotation);
            spawnedPlanet.transform.localScale *= spawnScale;

            float spawnSpeed = Random.Range(configuration.PlanetSpawnMinSpeedLimit, configuration.PlanetSpawnMaxSpeedLimit);
            spawnedPlanet.MoveSpeed = spawnSpeed;
            planetSpawnTime = Time.time + configuration.PlanetSpawnDelay;
        }

        Vector2 spaceBackOffset = spaceBackground.material.mainTextureOffset;
        spaceBackOffset.y -= configuration.SpaceBackSpeed / backsSpeedDecreaset;
        spaceBackground.material.mainTextureOffset = spaceBackOffset;

        Vector2 spaceForeOffset = spaceForeground.material.mainTextureOffset;
        spaceForeOffset.y -= configuration.SpaceForeSpeed / backsSpeedDecreaset;
        spaceForeground.material.mainTextureOffset = spaceForeOffset;
    }
}
