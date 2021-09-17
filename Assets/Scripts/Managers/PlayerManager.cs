using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    public Transform PlayerTransform;
    public GameObject LeftEngineFX;
    public GameObject RightEngineFX;
    public Transform LeftBulletSpawnPoint;
    public Transform RightBulletSpawnPoint;
    public AudioSource PlayerAudioSource;

    private LevelManager levelManager;

    private void Awake() => Instance = this;
    private void Start() => levelManager = LevelManager.Instance;

    private void Update()
    {
        if (!PlayerTransform.gameObject.activeSelf) return;

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
        if (!PlayerTransform.gameObject.activeSelf) return;

        PlayerAudioSource.PlayOneShot(Configuration.Instance.ShootClip);
        Instantiate(Configuration.Instance.PlayerBulletPrefab, LeftBulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.PlayerBulletSpeed;
        Instantiate(Configuration.Instance.PlayerBulletPrefab, RightBulletSpawnPoint.transform.position, Quaternion.identity).MoveSpeed = Configuration.Instance.PlayerBulletSpeed;
    }

    public void DestroyPlayer()
    {
        var destroyParticle = Instantiate(Configuration.Instance.PlayerDestroyParticle, PlayerTransform.position, Quaternion.identity);
        Destroy(destroyParticle.gameObject, 5f);
        PlayerTransform.gameObject.SetActive(false);
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(Configuration.Instance.PlayerRespawnDelay);
        PlayerTransform.gameObject.SetActive(true);
    }
}