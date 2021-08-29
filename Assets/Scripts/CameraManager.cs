using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;

    void Start()
    {
        mainCamera = Camera.main;
        playerTransform = PlayerManager.Instance.PlayerTransform;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Configuration.Instance.CameraSmooth);
    }
}
