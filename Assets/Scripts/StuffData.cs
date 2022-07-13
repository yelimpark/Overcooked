using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyType = System.String;

[System.Serializable]
public class StuffData
{
    public const int initialCount = 20;
    public const int maxCount = 50;

    public KeyType key;
    public GameObject prefab;
    public int initialObjectCount = initialCount;
    public int maxObjectCount = maxCount; 

}
