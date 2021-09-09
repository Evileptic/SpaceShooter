using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float MoveSpeed;

    public virtual void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - MoveSpeed * Time.deltaTime,
            transform.position.z);
    }
}