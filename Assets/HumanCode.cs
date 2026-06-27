using UnityEngine;

public class HumanCode : MonoBehaviour
{
// Start is called once before the first execution of Update after the MonoBehaviour is created



void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
}

public float rotateSpeed = 100f;

// Update is called once per frame
void Update()
{
    //Di chuyen
    if (Input.GetKey(KeyCode.D))
    {
        transform.Translate(new Vector3(5f, 0f, 0f) * Time.deltaTime, Space.Self);
    }

    else if (Input.GetKey(KeyCode.A))
    {
        transform.Translate(new Vector3(-5f, 0f, 0f) * Time.deltaTime, Space.Self);
    }

    if (Input.GetKey(KeyCode.S))
    {
        transform.Translate(new Vector3(0f, 0f, -5f) * Time.deltaTime, Space.Self);
    }
    else if (Input.GetKey(KeyCode.W))
    {
        transform.Translate(new Vector3(0f, 0f, 5f) * Time.deltaTime, Space.Self);
    }

    float mouseX = Input.GetAxis("Mouse X");
    transform.Rotate(Vector3.up * mouseX * rotateSpeed * Time.deltaTime);

}



}
