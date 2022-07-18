using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    // UI 
    public CardManager cm;

    public void OnSubmit(GameObject go)
    {
        cm.OnSubmit(go);
    }
}
