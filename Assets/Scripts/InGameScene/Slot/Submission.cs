using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submission : Slot
{
    public KitchenManager km;
    public ObjectPoolManager poolManager;

    public void Start()
    {
        AcceptableTag.Add("Cookware");
    }

    public override void OnPlace(GameObject go)
    {
        PoolingObject po = go.GetComponent<PoolingObject>();
        poolManager.Return(po);

        km.OnSubmit(go);
    }
}
