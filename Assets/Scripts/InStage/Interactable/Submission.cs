using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submission : MonoBehaviour
{
    CardManager CardManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingrediants" || other.tag == "Cookware")
        {
            Debug.Log(other.name);
            Utils.FixPosition(other.gameObject);
            iTween.MoveTo(other.gameObject, iTween.Hash("z", -10f, "speed", 1f));
            CardManager.OnSubmit(null);
        }
    }
}
