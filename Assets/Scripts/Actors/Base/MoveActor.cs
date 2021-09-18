using UnityEngine;

public enum MoveDirection { UP, DOWN }

public class MoveActor : MonoBehaviour
{
    [SerializeField] private MoveDirection MoveDirection;
    [HideInInspector] public float MoveSpeed;

    public virtual void Update()
    {
        Vector3 targetPositon = Vector3.zero;
        targetPositon.x = transform.position.x;
        targetPositon.z = transform.position.z;

        switch (MoveDirection)
        {
            case MoveDirection.UP:
                targetPositon.y = transform.position.y + MoveSpeed * Time.deltaTime;
                break;
            case MoveDirection.DOWN:
                targetPositon.y = transform.position.y - MoveSpeed * Time.deltaTime;
                break;
        }

        transform.position = targetPositon;
    }
}