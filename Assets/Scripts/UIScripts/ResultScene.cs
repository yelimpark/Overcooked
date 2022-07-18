using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{

    public GameObject ZoomUI;
    public ZoomOut ZoomOutUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ZoomOutUI.ZoomOutUI();
        }
    }
}
