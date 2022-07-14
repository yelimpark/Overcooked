using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frypan : Shelf
{
    private GameObject OccupyObj;

    public GameObject timebar;
    public float Yoffset;

    public new void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;

        Ingrediant ingrediant = otherGO.GetComponent<Ingrediant>();
        if (OccupyObj != null || ingrediant == null || ingrediant.action == Action.Cook)
            return;

        // 원래는 오브젝트 풀에 요청해야 함. 테스트 코드.
        OccupyObj = GameObject.Find(ingrediant.next);

        OccupyObj.transform.position = transform.position;
        OccupyObj.SetActive(true);
        // 반환
        otherGO.SetActive(false);

        // fix position
        Vector3 newPos = transform.position;
        newPos.y += transform.localScale.y;
        OccupyObj.transform.position = newPos;

        Rigidbody rb = OccupyObj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        // set timer
        newPos = Camera.main.WorldToScreenPoint(transform.position);
        newPos.y += Yoffset;
        timebar.transform.position = newPos;
        timebar.SetActive(true);
    }

    public new GameObject OnTakeOut()
    {
        if (OccupyObj == null)
            return null;

        GameObject takeout = OccupyObj;
        OccupyObj = null;

        Rigidbody rb = takeout.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.None;

        return takeout;
    }

    public void OnTimeUp()
    {
        // 테스트 코드.
        //GameObject nextGO = GameObject.Find(next);

        //nextGO.transform.position = transform.position;
        //nextGO.SetActive(true);
        //gameObject.SetActive(false);
    }
}
