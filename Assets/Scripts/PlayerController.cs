using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float moveSpeed = 20.0f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float rotationMax = 60.0f;
    private float lookUpDown;
    private Rigidbody playerRb;
    private float mouseAxisXC;
    public static PlayerController Instance { get; private set; }
    public ITool CurrentTool;
    void Awake()
    {
        Instance = this;
    }
    void Start()  // her şey burada başladı.
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CurrentTool = GetComponentInChildren<ITool>();

    }
    void Update() // Saniyede bilgisayarın ne kadar iyiyse o kadar kare oynatır.
    {
        PlayerCameraMove();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit();
        }

    }

    void FixedUpdate()
    {  // Saniyede 50 kare oynatır bu yüzden motorsal fiziksel hareketler burada.
        PlayerMove(); //Karakter hareketi Rigidbody MovePosition içerdiği için FixedUpdate içerisine koydum.
    }
    public void PlayerMove()
    {

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = ((transform.forward * verticalInput) + (transform.right * horizontalInput)) * moveSpeed;
        playerRb.linearVelocity = movement;
    }

    public void PlayerCameraMove()
    {
        var mouseAxisX = Input.GetAxis("Mouse X");
        var mouseAxisY = Input.GetAxis("Mouse Y");
        mouseAxisXC += mouseAxisX;
        // Yukarı aşağı bakma işlemleri
        playerCamera.localRotation = Quaternion.Euler(lookUpDown, 0f, 0f); // localRotation ile kameranın rotasyonunu derecelendirdim. Clamp ile yalnızca -60 ile 60 arasında rotate alabiliyor.
        lookUpDown -= mouseAxisY * rotationSpeed; // Çıkartarak iterate ediyorum çünkü yukarıya bakınca negatif aşağıya bakınca pozitif olması gerek. Yani mouse artarken -, azalırken +
        lookUpDown = Mathf.Clamp(lookUpDown, -rotationMax, rotationMax); // Clamp fonksiyonu ile mouse axis verisini sınırlandırıyorum.
        // Sağa sola dönme işlemleri
        // transform.Rotate(Vector3.up *  (rotationSpeed * mouseAxisX)); 
        playerRb.MoveRotation(Quaternion.Euler(0f, mouseAxisXC, 0f));
    }

    public void RaycastHit()
    {
        RaycastHit hit;
        bool ifToolUsed = false;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (CurrentTool != null)
            {
                ifToolUsed = CurrentTool.Use(hit.collider.gameObject);
            }
            if (ifToolUsed == false && hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactableObj))
            { // TryGetComponent ile bool döndürüyorum (var mı yok mu kontrolü)
                interactableObj.Interact();  // burası şimdilik tool interaction anlamına da geliyor.
                return;
            }
        }
        else
        {
            Debug.Log("No Hit");
        }
    }
}
