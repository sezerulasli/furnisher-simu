using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI notificationText;
    public static NotificationUI Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    public void UpdateText(string text)
    {
        notificationText.text = text;
        notificationText.gameObject.SetActive(true);
        StopAllCoroutines(); // Bir coroutine başladığında, 2. bir text'i etkilemesin diye her seferinde var olan coroutine'leri kapatıyorum.
        StartCoroutine(ShowText());

    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(2f);
        notificationText.gameObject.SetActive(false);
    }

}
