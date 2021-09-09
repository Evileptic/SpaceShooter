using UnityEngine;

public class Configuration : MonoBehaviour
{
    public static Configuration Instance = null;

    private void Awake() => Instance = this;

    [Header("Player Config")]
    [Range(0f, 20f)]
    public float PlayerSpeed = 15f;

    [Header("Level Config")]
    [Range(0f, 1f)]
    public float SpaceBackSpeed = 0.15f;
    [Range(0f, 1f)]
    public float SpaceForeSpeed = 0.3f;

    public float PlanetsHorizontalRange;
    public PlanetActor[] PlanetPrefabs;
    public float PlanetSpawnDelay;

    [Header("Others Config")]
    public float CameraSmooth;
}
