using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed;
    public Vector2 maxPos;
    public Vector2 minPos;

    // camera is moved with the player and does not exceed the boundaries of the map
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 desiredPosition = new(target.position.x, target.position.y, transform.position.z);
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPos.x, maxPos.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
