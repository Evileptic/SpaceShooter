using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    public Transform PlayerTransform;

    [SerializeField] private GameObject leftEngineFX;
    [SerializeField] private GameObject rightEngineFX;
    [SerializeField] private Transform leftBulletSpawnPoint;
    [SerializeField] private Transform rightBulletSpawnPoint;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource playerEngineAudioSource;
    [SerializeField] private Transform topLevelLimit;
    [SerializeField] private Transform bottomLevelLimit;

    private LevelManager levelManager;
    private Configuration configuration;

    private void Awake() => Instance = this;

    private void Start()
    {
        levelManager = LevelManager.Instance;
        configuration = Configuration.Instance;
    }

    private void Update()
    {
        if (!PlayerTransform.gameObject.activeSelf) return;

        leftEngineFX.SetActive(InputManager.Input.x > configuration.PlayerEngineInputThreshold);
        rightEngineFX.SetActive(InputManager.Input.x < -configuration.PlayerEngineInputThreshold);

        var playerPosition = PlayerTransform.position;

        var targetX = InputManager.Input.x * configuration.PlayerSpeed * Time.deltaTime;
        var clampedX = Mathf.Clamp(PlayerTransform.position.x + targetX, levelManager.LeftLevelLimit.position.x, levelManager.RightLevelLimit.position.x);
        playerPosition.x = clampedX;

        var targetY = InputManager.Input.y * configuration.PlayerSpeed * Time.deltaTime;
        var clampedY = Mathf.Clamp(PlayerTransform.position.y + targetY, bottomLevelLimit.position.y, topLevelLimit.position.y);
        playerPosition.y = clampedY;

        PlayerTransform.position = playerPosition;

        playerEngineAudioSource.volume = Mathf.Abs(InputManager.Input.magnitude);
    }

    public void Shoot()
    {
        if (!PlayerTransform.gameObject.activeSelf) return;

        playerAudioSource.PlayOneShot(configuration.ShootClip);
        Instantiate(configuration.PlayerBulletPrefab, leftBulletSpawnPoint.position, Quaternion.identity).MoveSpeed = configuration.PlayerBulletSpeed;
        Instantiate(configuration.PlayerBulletPrefab, rightBulletSpawnPoint.position, Quaternion.identity).MoveSpeed = configuration.PlayerBulletSpeed;
    }

    public void DestroyPlayer()
    {
        var destroyParticle = Instantiate(configuration.PlayerDestroyParticle, PlayerTransform.position, Quaternion.identity);
        Destroy(destroyParticle.gameObject, configuration.BulletsDestroyDelay);
        PlayerTransform.gameObject.SetActive(false);
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(configuration.PlayerRespawnDelay);
        PlayerTransform.gameObject.SetActive(true);
    }
}