using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;

    public Transform LeftLevelLimit;
    public Transform RightLevelLimit;
    public Transform TopLevelLimit;
    public Transform BottomLevelLimit;

    public Transform PlanetsSpawnPoint;

    public MeshRenderer SpaceBackground;
    public MeshRenderer SpaceForeground;

    private void Awake() => Instance = this;

    private float planetSpawnTimeout;

    private void Update()
    {
        if (Time.time > planetSpawnTimeout)
        {
            var spawnPoint = Vector3.zero;
            spawnPoint.y = PlanetsSpawnPoint.transform.position.y;
            spawnPoint.x = Random.Range(-Configuration.Instance.PlanetsHorizontalRange, Configuration.Instance.PlanetsHorizontalRange);
            spawnPoint.z = Random.Range(100f, 120f);
            var planetForInstance = Configuration.Instance.PlanetPrefabs[Random.Range(0, Configuration.Instance.PlanetPrefabs.Length)];
            float spawnScale = Random.Range(1f, 3f);
            var spawnedPlanet = Instantiate(planetForInstance, spawnPoint, planetForInstance.transform.rotation);
            spawnedPlanet.transform.localScale *= spawnScale;
            float spawnSpeed = Random.Range(1f, 2f);
            spawnedPlanet.MoveSpeed = spawnSpeed;
            planetSpawnTimeout = Time.time + Configuration.Instance.PlanetSpawnDelay;
        }

        Vector2 spaceBackOffset = SpaceBackground.material.mainTextureOffset;
        spaceBackOffset.y -= Configuration.Instance.SpaceBackSpeed / 1000f;
        SpaceBackground.material.mainTextureOffset = spaceBackOffset;

        Vector2 spaceForeOffset = SpaceForeground.material.mainTextureOffset;
        spaceForeOffset.y -= Configuration.Instance.SpaceForeSpeed / 1000f;
        SpaceForeground.material.mainTextureOffset = spaceForeOffset;
    }
}
