using UnityEngine;

public class Planet : MonoBehaviour
{
    public float MoveSpeed;

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y - MoveSpeed * Time.deltaTime, 
            transform.position.z);
    }
}
