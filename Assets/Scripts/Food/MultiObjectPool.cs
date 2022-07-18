using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class MultiObjectPool : MonoBehaviour
{
    public KeyCode key;

    public MultiObjectPool Clone()
    {
        GameObject go = Instantiate(gameObject);
        if(!go.TryGetComponent(out MultiObjectPool Mpo))
        {
            Mpo = go.AddComponent<MultiObjectPool>();
        }
        go.SetActive(false);
        return Mpo;
    }

    public void Activate() //플레이어가 박스에 닿아서 클릭을 했을 때 위치 보정?
    {
        gameObject.SetActive(true);
    }

    public void Disabled() //쓰레기통에 넣었을때 false가 되면서 위치가 변경되도록(?)
    {
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Trash"))
        {
            Disabled();
        }
    }


}
