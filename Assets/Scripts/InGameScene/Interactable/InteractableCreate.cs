using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class InteractableCreate : Interactable
{
    public KeyCode key;
    public ObjectPoolManager poolManager;
    public PoolingObject Create()
    {
        return poolManager.Extract(key);
    }

    public override GameObject TakeOut(GameObject dest)
    {
        if (key == null)
            return null;

        var go = poolManager.Extract(key);
        go.gameObject.transform.position = transform.position;
        return go.gameObject;
    }
}
