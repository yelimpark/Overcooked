using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class CreateIngredient : MonoBehaviour
{
    public KeyCode key;
    public ObjectPoolManager poolManager;
    public PoolingObject Create()
    {
        return poolManager.Extract(key);
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(UnityEngine.KeyCode.Space))
            {
                if (key == null)
                {
                    return;
                }
                else
                {
                    var go = poolManager.Extract(key);
                }
            }
        }
    }
}
