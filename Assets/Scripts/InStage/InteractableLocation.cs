using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLocation : MonoBehaviour
{
    private bool active = false;

    public GameObject shelfGO;
    public GameObject player;

    public bool Active
    {
        get { return active; }
        set 
        { 
            active = value;
            if (active)
            {
                OnCursorOn();
            }
            else
            {
                OnCursorOut();
            }
        }
    }

    public void OnCursorOn()
    {
        Highlight highlight = GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOn();
    }

    public void OnCursorOut()
    {
        Highlight highlight = GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOff();
    }

    private void Update()
    {
        if (active && Input.GetButtonDown("Fire1"))
        {
            Shelf shelf = shelfGO.GetComponent<Shelf>();
            GameObject ingrediant = shelf.OnTakeOut();
            // 플레이어에게 재료 장착시키는 함수
            ingrediant.transform.position = player.transform.position;
        }
    }
}
