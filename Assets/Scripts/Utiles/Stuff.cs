using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Stuff : MonoBehaviour
{
    public IObjectPool<Stuff> poolToReturn;    
    public bool IsTriggered
    {
        get;
        private set;
    }

    public void Reset()
    {
        IsTriggered = false;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(IsTriggered)
        {
            return;
        }

        if(collision.collider.CompareTag("Trash"))
        {
            IsTriggered = true;
            StartCoroutine(DestroyStuff());               
        }
    }

    private IEnumerator DestroyStuff()
    {
        yield return new WaitForSeconds(0.5f);
        poolToReturn.Release(this);
    }
}
