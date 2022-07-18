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

    public void Activate() //�÷��̾ �ڽ��� ��Ƽ� Ŭ���� ���� �� ��ġ ����?
    {
        gameObject.SetActive(true);
    }

    public void Disabled() //�������뿡 �־����� false�� �Ǹ鼭 ��ġ�� ����ǵ���(?)
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
