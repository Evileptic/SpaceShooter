using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    public Transform PlayerTransform;
    public GameObject LeftEngineFX;
    public GameObject RightEngineFX;
    public Transform LeftBulletSpawnPoint;
    public Transform RightBulletSpawnPoint;

    private LevelManager levelManager;

    private void Awake() => Instance = this;
    private void Start() => levelManager = LevelManager.Instance;

    private void Update()
    {
        LeftEngineFX.SetActive(InputManager.Input.x > 0.1f);
        RightEngineFX.SetActive(InputManager.Input.x < -0.1f);

        var playerPosition = PlayerTransform.position;

        var targetX = InputManager.Input.x * Configuration.Instance.PlayerSpeed * Time.deltaTime;
        var clampedX = Mathf.Clamp(PlayerTransform.transform.position.x + targetX, levelManager.LeftLevelLimit.position.x, levelManager.RightLevelLimit.position.x);
        playerPosition.x = clampedX;

        var targetY = InputManager.Input.y * Configuration.Instance.PlayerSpeed * Time.deltaTime;
        var clampedY = Mathf.Clamp(PlayerTransform.transform.position.y + targetY, levelManager.BottomLevelLimit.position.y, levelManager.TopLevelLimit.position.y);
        playerPosition.y = clampedY;

        PlayerTransform.position = playerPosition;
    }

    public void Shoot()
    {
        Instantiate(Configuration.Instance.PlayerBulletPrefab, LeftBulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.PlayerBulletSpeed;
        Instantiate(Configuration.Instance.PlayerBulletPrefab, RightBulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.PlayerBulletSpeed;
    }
}
