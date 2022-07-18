using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

[DisallowMultipleComponent]
public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private List<IngredientType> objectPoolData = new List<IngredientType>(4);

    private Dictionary<KeyCode, PoolingObject> originDic;
    private Dictionary<KeyCode, IngredientType> dataDic;
    private Dictionary<KeyCode, Stack<PoolingObject>> poolDic;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        int dataLen = objectPoolData.Count;

        if(dataLen == 0)
        {
            return;
        }

        originDic = new Dictionary<KeyCode, PoolingObject>(dataLen);
        dataDic = new Dictionary<KeyCode, IngredientType>(dataLen);
        poolDic = new Dictionary<KeyCode, Stack<PoolingObject>>(dataLen);

        foreach(var data in objectPoolData)
        {
            Save(data);
        }
    }

    public void Save(IngredientType data)
    {
        //같은 데이터 Key
        if (poolDic.ContainsKey(data.key)) 
        {
            return;
        }

        GameObject origin = Instantiate(data.IngredientPrefab);
        if(!origin.TryGetComponent(out PoolingObject mpo))
        {
          mpo = origin.AddComponent<PoolingObject>();
        }
        origin.SetActive(false);

        Stack<PoolingObject> objectPool = new Stack<PoolingObject>(data.maxIngredCount);
        for(int i =0; i < data.initIngredCount; i++)
        {
            PoolingObject clone = mpo.Clone();
            objectPool.Push(clone);
        }

        originDic.Add(data.key, mpo);
        dataDic.Add(data.key, data);
        poolDic.Add(data.key, objectPool);   
    }
    public PoolingObject Extract(KeyCode key)
    {
        PoolingObject objectPool;

        if (!poolDic.TryGetValue(key, out var pool))
        {
            return null;
        }
        if (pool.Count > 0)
        {
            objectPool = pool.Pop();
        }
        else
        {
            objectPool = originDic[key].Clone();
        }

        objectPool.Activate();
        return objectPool;
    }

    public void Return(PoolingObject ObjectPool)
    {
        if(!poolDic.TryGetValue(ObjectPool.key, out var pool))
        {
            return;
        }
        KeyCode key = ObjectPool.key;

        if(pool.Count < dataDic[key].maxIngredCount)
        {
            pool.Push(ObjectPool);
            ObjectPool.Disabled();
        }
        
    }
}
