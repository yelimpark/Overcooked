using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaivourWithTimer : CookingBehaviour
{
    public GameObject timebar;
    public float Yoffset;

    public override bool AtPosition
    {
        get { return atPosition; }
        set 
        {
            atPosition = value;
            
            if (atPosition)
            {
                Vector3 newPos = Camera.main.WorldToScreenPoint(transform.position);
                newPos.y += Yoffset;
                timebar.transform.position = newPos;
            }

            timebar.SetActive(atPosition);
        }
    }

    public void OnTimeUp()
    {
        string next = string.Empty;

        Shelf shelf = GetComponent<Shelf>();
        if (shelf != null && shelf.OccupyObj != null)
        {
            Ingrediant ingrediant =  shelf.OccupyObj.GetComponent<Ingrediant>();
            next = ingrediant.next;
        }

        // ������ ������Ʈ Ǯ�� ��û�ؾ� ��. �׽�Ʈ �ڵ�.
        GameObject nextGO =  GameObject.Find(next);
        
        nextGO.transform.position = transform.position;
        nextGO.SetActive(true);
        gameObject.SetActive(false);
    }
}
