using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class NotificationUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI notificationText;
    private PaintCanController _paintCanController;

    void UpdateText(string text) {
        notificationText.gameObject.SetActive(true);
        notificationText.text = text + " Seçildi.";
        StartCoroutine(ShowText());
    }
    void OnEnable() {
        PaintCanController.OnChosenColor += UpdateText;
        
    }
    
    IEnumerator ShowText() {
        Debug.Log("oldu");
        yield return new WaitForSeconds(2f);
        notificationText.gameObject.SetActive(false);
    }

    void OnDisable() {
        PaintCanController.OnChosenColor -= UpdateText;
    }
    
}
