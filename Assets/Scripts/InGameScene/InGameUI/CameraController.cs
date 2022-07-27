using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public float CameraMovePos;
    public float moveTime;
    public void CameraZoomIn()
    {
        iTween.MoveTo(MainCamera, iTween.Hash("position", new Vector3(MainCamera.transform.position.x, CameraMovePos, MainCamera.transform.position.z), "time", moveTime));
    }
}
