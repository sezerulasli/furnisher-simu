using TMPro;
using UnityEngine;
using System;

public class ComputerController : MonoBehaviour, IInteractable
{
    public event Action OnScreenInteract;
    public void Interact()
    {
        OnScreenInteract?.Invoke();
    }



}
