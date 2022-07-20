using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour 
{
    private ObjectPool<Stuff> stuffpool;

    public Stuff stuffPrefab;
    public GameObject spon;

    private void Start()
    {
        stuffpool = new ObjectPool<Stuff>
            (createFunc: () =>
            {
                var createStuff = Instantiate(stuffPrefab);
                createStuff.poolToReturn = stuffpool;
                return createStuff;
            },
            actionOnGet: (stuff) =>
            {
                stuff.gameObject.SetActive(true);
                stuff.Reset();
            },
            actionOnRelease: (stuff) =>
            {
                stuff.gameObject.SetActive(false);
            },
            actionOnDestroy: (stuff) =>
            {
                Destroy(stuff.gameObject);
            }, defaultCapacity:100, maxSize: 1000);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatStuff();
        }
    }
    private void CreatStuff()
    {
        var stuff = stuffpool.Get();
        var position = spon.transform.position;

        stuff.transform.position = position;
    }
}
