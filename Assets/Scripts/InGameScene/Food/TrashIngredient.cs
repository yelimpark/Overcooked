using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class TrashIngredient : MonoBehaviour
{    
    private ObjectPoolManager poolManager;
    private PoolingObject poolingObject;

    private void Awake()
    {        
        poolManager = GameObject.FindObjectOfType<ObjectPoolManager>();
        poolingObject = GetComponent<PoolingObject>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trash"))
        {
            poolManager.Return(poolingObject);
        }
    }
}
