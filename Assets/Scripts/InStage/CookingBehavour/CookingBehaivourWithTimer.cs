using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaivourWithTimer : CookingBehaviour
{
    public TimeBar timebar;
    public float Yoffset;

    public void OnTimeUp()
    {
        Slot slot = GetComponent<Slot>();
        if (slot == null || slot.OccupyObj == null)
            return;

        GameObject before = slot.OnTakeOut();
        Ingrediant ingrediant = before.GetComponent<Ingrediant>();

        // ������ ������Ʈ Ǯ�� ��û�ؾ� ��. �׽�Ʈ �ڵ�.
        GameObject after = GameObject.Find(ingrediant.next);

        after.transform.position = transform.position;
        after.SetActive(true);
        slot.OnPlace(after);

        //��ȯ
        before.SetActive(false);
    }

    private void Update()
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(transform.position);
        newPos.y += Yoffset;
        timebar.transform.position = newPos;
    }

    public override void AtPosition()
    {
        timebar.gameObject.SetActive(true);
        timebar.pause = false;
    }

    public override void ExitPosition() 
    {
        timebar.pause = true;
    }
}
