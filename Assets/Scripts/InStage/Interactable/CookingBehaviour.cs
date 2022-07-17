using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaviour : MonoBehaviour
{
    public TimeBar timebar;
    public float Yoffset;

    public bool fixWhileCooking = false;
    public bool AutoExecute = true;

    public SlotMask mask;
    
    private SlotMask curPosition;
    public SlotMask CurPosition
    {
        get { return curPosition; }
        set
        {
            curPosition = value;
            Execute();
        }
    }

    public void OnTimeUp()
    {
        Cookware cookware = GetComponent<Cookware>();
        if (cookware == null || cookware.occupyObj == null)
            return;

        GameObject before = cookware.OnTakeOut();
        Ingrediant ingrediant = before.GetComponent<Ingrediant>();

        // 원래는 오브젝트 풀에 요청해야 함. 테스트 코드.
        GameObject after = GameObject.Find(ingrediant.next);
        after.SetActive(true);

        ((Slot)cookware).OnPlace(after);

        //반환
        before.SetActive(false);
    }

    private void Update()
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(transform.position);
        newPos.y += Yoffset;
        timebar.transform.position = newPos;
    }

    public bool ExitPosition()
    {
        if (!AutoExecute && !timebar.end)
        {
            Execute(true);
            return false;
        }

        if (fixWhileCooking && !timebar.end)
            return false;

        CurPosition = SlotMask.None;
        timebar.pause = true;
        return true;
    }

    public void Execute(bool trigger = false)
    {
        if (timebar.end || CurPosition != mask)
            return;

        Cookware cookware = GetComponent<Cookware>();
        if (cookware == null || cookware.occupyObj == null)
            return;

        if (AutoExecute || trigger)
        {
            timebar.gameObject.SetActive(true);
            timebar.pause = false;
        }
    }
}
