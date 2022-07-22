using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class PoolingObject : MonoBehaviour
{
    public KeyCode key;

    public PoolingObject Clone()
    {
        GameObject go = Instantiate(gameObject);
        if(!go.TryGetComponent(out PoolingObject Mpo))
        {
            Mpo = go.AddComponent<PoolingObject>();
        }
        go.SetActive(false);
        return Mpo;
    }

    public GameObject GetGO()
    {
        GameObject go = Instantiate(gameObject);
        go.AddComponent<PoolingObject>();
        return go;
    }

    public void Activate() 
    {

       gameObject.SetActive(true);      
    }

    public void Disabled() 
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
