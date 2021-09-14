using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector2 Input;

    private void Update()
    {
        Input.x = UnityEngine.Input.GetAxis("Horizontal");
        Input.y = UnityEngine.Input.GetAxis("Vertical");

        if (UnityEngine.Input.GetMouseButtonDown(0) || UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            PlayerManager.Instance.Shoot();
        }
    }
}
