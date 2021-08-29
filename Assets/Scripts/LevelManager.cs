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

    private void Update()
    {
        Vector2 spaceBackOffset = SpaceBackground.material.mainTextureOffset;
        spaceBackOffset.y -= Configuration.Instance.SpaceBackSpeed / 1000f;
        SpaceBackground.material.mainTextureOffset = spaceBackOffset;

        Vector2 spaceForeOffset = SpaceForeground.material.mainTextureOffset;
        spaceForeOffset.y -= Configuration.Instance.SpaceForeSpeed / 1000f;
        SpaceForeground.material.mainTextureOffset = spaceForeOffset;
    }
}
