using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{

    public GameObject FadeUI;
    public FadeInOutUI fadeOutUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fadeOutUI.FadeOutUI();
        }
    }
}
