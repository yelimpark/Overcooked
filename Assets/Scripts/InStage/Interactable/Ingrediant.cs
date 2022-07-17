using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotMask
{
    None = 0,
    FRYPAN = 1,
    CUTTING_BOARD = 2
}


public class Ingrediant : MonoBehaviour
{
    public SlotMask mask;
    public string next;
    public string IngrediantName;
}
