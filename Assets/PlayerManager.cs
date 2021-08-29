using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    public Transform PlayerTransform;

    private void Awake() => Instance = this;

    private void Update()
    {
        var playerPosition = PlayerTransform.position;
        playerPosition.x += InputManager.Input.x * Configuration.Instance.PlayerSpeed * Time.deltaTime;
        playerPosition.y += InputManager.Input.y * Configuration.Instance.PlayerSpeed * Time.deltaTime;

        if (playerPosition.x > LevelManager.Instance.LeftLevelLimit.position.x &&
            playerPosition.x < LevelManager.Instance.RightLevelLimit.position.x &&
            playerPosition.y < LevelManager.Instance.TopLevelLimit.position.y &&
            playerPosition.y > LevelManager.Instance.BottomLevelLimit.position.y)
        {
            PlayerTransform.position = playerPosition;
        }
    }
}
