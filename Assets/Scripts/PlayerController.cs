using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20.0f;
    [SerializeField] private Transform playerCamera;

    private Rigidbody playerRb;

    public static PlayerController Instance { get; private set; }
    public ITool CurrentTool;
    [SerializeField] private LayerMask interactableLayer;

    float horizontalInput;
    float verticalInput;

    void Awake()
    {
        Instance = this;
    }
    void Start()  // her şey burada başladı.
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CurrentTool = playerCamera.GetComponentInChildren<ITool>();

    }
    void Update() // Saniyede bilgisayarın ne kadar iyiyse o kadar kare oynatır.
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (EventSystem.current.IsPointerOverGameObject()) // imleç bir ui objesi üzerinde mi kontrolü.. raycast'i engellemek adına.
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit();
        }

    }

    void FixedUpdate()
    {  // Saniyede 50 kare oynatır bu yüzden motorsal fiziksel hareketler burada.
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            PlayerMove();
        }

        //Karakter hareketi Rigidbody MovePosition içerdiği için FixedUpdate içerisine koydum.
    }
    public void PlayerMove()
    {

        Vector3 movement = ((transform.forward * verticalInput) + (transform.right * horizontalInput)) * moveSpeed;
        playerRb.linearVelocity = movement;

    }

    public void RaycastHit()
    {
        RaycastHit hit;
        bool ifToolUsed = false;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity, interactableLayer))
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