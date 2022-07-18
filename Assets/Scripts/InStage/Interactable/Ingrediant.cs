using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotMask
{
    None,
    FRYPAN,
    CUTTING_BOARD,
    PLATE
}


public class Ingrediant : MonoBehaviour
{
    public SlotMask mask;
    public string next;
    public string IngrediantName;
}
