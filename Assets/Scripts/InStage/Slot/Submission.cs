using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submission : Slot
{
    public float conbearSpeed = 3f;
    public KitchenManager km;

    private ObjectPoolManager poolManager;

    private void Awake()
    {
        poolManager = GameObject.FindObjectOfType<ObjectPoolManager>();      
    }
    public override void OnPlace(GameObject go)
    {
        // ¿Ã∆Â∆Æ
        //go.SetActive(false);
        PoolingObject po = go.GetComponent<PoolingObject>();
        poolManager.Return(po);

        km.OnSubmit(go);
    }

}
