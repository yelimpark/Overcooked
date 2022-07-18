using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaviour : MonoBehaviour
{
    Cookware cookware;

    public TimeBar timebar;
    public float Yoffset = 20f;

    public bool fixWhileCooking = false;
    public bool AutoExecute = true;

    [System.NonSerialized]
    public bool trigger = false;

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

    private void Start()
    {
        cookware = GetComponent<Cookware>();
    }

    public void OnTimeUp()
    {
        if (cookware == null || cookware.occupyObj == null)
            return;

        GameObject before = cookware.OnTakeOut(null);
        Ingrediant ingrediant = before.GetComponent<Ingrediant>();

        // ������ ������Ʈ Ǯ�� ��û�ؾ� ��. �׽�Ʈ �ڵ�.
        GameObject after = GameObject.Find(ingrediant.next);
        after.SetActive(true);

        cookware.OnPlace(after);

        //��ȯ
        before.SetActive(false);
    }

    private void Update()
    {
        Vector3 newPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        newPos.y += Yoffset;
        timebar.transform.position = newPos;

        //�ӽ��ڵ�!!!!!!
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CurPosition = SlotMask.CUTTING_BOARD;
            trigger = true;
            Execute();
        }
    }

    public bool ExitPosition()
    {
        if (fixWhileCooking && !timebar.end)
            return false;

        CurPosition = SlotMask.None;
        timebar.pause = true;
        return true;
    }

    public void Execute()
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
