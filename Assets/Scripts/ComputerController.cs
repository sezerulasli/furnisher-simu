using TMPro;
using UnityEngine;
using System;

public class ComputerController : MonoBehaviour, IInteractable
{
    [SerializeField] private ComputerInteractUI interactUI;
    public event Action OnScreenInteract;

    public void Interact()
    {
        OnScreenInteract?.Invoke();
        interactUI.gameObject.SetActive(true);
    }

}
