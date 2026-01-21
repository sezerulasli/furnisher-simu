using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI notificationText;

    /*
    void UpdateText(string text)
    {
        notificationText.text = text;
        notificationText.gameObject.SetActive(true);
        StopAllCoroutines(); // Bir coroutine başladığında, 2. bir text'i etkilemesin diye her seferinde var olan coroutine'leri kapatıyorum.
        StartCoroutine(ShowText());

    }
    void OnEnable()
    {
        PaintCanController.OnChosenColor += UpdateText;
        PaintCanController.OnCanDrained += UpdateText;

    }

    IEnumerator ShowText()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(2f);
        notificationText.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        PaintCanController.OnChosenColor -= UpdateText;
        PaintCanController.OnCanDrained -= UpdateText;
    }
*/
}
