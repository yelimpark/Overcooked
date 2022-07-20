using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

[System.Serializable]
public class IngredientType
{
    public const int count = 20;
    public const int maxCount = 60;

    public KeyCode key;
    public GameObject IngredientPrefab;
    public int initIngredCount = count;
    public int maxIngredCount = maxCount;
}
