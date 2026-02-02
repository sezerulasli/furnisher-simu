using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotationMax = 60.0f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float smoothTime = 0.015f;
    private float mouseAxisXC;
    private float lookUpDown;
    public Vector3 currentVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseAxisX = Input.GetAxis("Mouse X");
        float mouseAxisY = Input.GetAxis("Mouse Y");

        mouseAxisXC += mouseAxisX;

        lookUpDown -= mouseAxisY * rotationSpeed;
        lookUpDown = Mathf.Clamp(lookUpDown, -rotationMax, rotationMax);

        player.rotation = Quaternion.Euler(0f, mouseAxisXC, 0f);

        transform.rotation = Quaternion.Euler(lookUpDown, mouseAxisXC, 0f);

    }

    void LateUpdate()
    {

        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);

    }
}
