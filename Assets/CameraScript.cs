using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    public float distance = 5f;
    public float sensitivity = 3f;

    public float minPitch = -20f;
    public float maxPitch = 70f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        transform.position = target.position - rotation * Vector3.forward * distance;
        transform.rotation = rotation;
    }
}
