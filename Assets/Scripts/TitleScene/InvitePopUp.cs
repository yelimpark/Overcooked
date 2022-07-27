using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvitePopUp : MonoBehaviour
{
    public TextMeshProUGUI roomNumText;

    public void SetCode(string text)
    {
        roomNumText.text = text;
    }

    public void OnClode()
    {
        gameObject.SetActive(false);
    }
}
