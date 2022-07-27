using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassMovement : MonoBehaviour
{
    public Animator animator;
    public Transform passPos;
    public GameObject chef;
    public GameObject tuchText;

    public float speed;
    public bool isMove;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            chef.SetActive(true);
            tuchText.SetActive(false);
            animator.SetBool("isOpen", true);
        }

        if (isMove)
        {
            CameraMove();
        }
    }

    private void CameraMove()
    {
        Camera.main.transform.SetPositionAndRotation(
            Vector3.Lerp(Camera.main.transform.position, passPos.position, speed * Time.deltaTime),
            Quaternion.Lerp(Camera.main.transform.rotation, passPos.rotation, speed * Time.deltaTime));
    }
}
