using UnityEngine;

public class Configuration : MonoBehaviour
{
    public static Configuration Instance = null;

    private void Awake() => Instance = this;

    [Header("Player Config")]
    public float PlayerSpeed;

    [Header("Level Config")]
    [Range(0f, 1f)]
    public float SpaceBackSpeed;
    [Range(0f, 1f)]
    public float SpaceForeSpeed;

    [Header("Others Config")]
    public float CameraSmooth;
}
