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

    public CoockwareType mask;

    private CoockwareType curPosition;
    public CoockwareType CurPosition
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

        timebar.Init();

        GameObject before = cookware.OnTakeOut(null);
        Ingrediant ingrediant = before.GetComponent<Ingrediant>();

        // ������ ������Ʈ Ǯ�� ��û�ؾ� ��. �׽�Ʈ �ڵ�.
        GameObject ObjPoolMgrGO = GameObject.FindGameObjectWithTag("ObjPoolMgr");
        ObjectPoolManager ObjPoolMgr = ObjPoolMgrGO.GetComponent<ObjectPoolManager>();
        GameObject after = ObjPoolMgr.Extract(ingrediant.next).gameObject;

        cookware.OnPlace(after);

        //��ȯ
        PoolingObject po = before.GetComponent<PoolingObject>();
        ObjPoolMgr.Return(po);
        before.SetActive(false);
    }

    public void SetTrigger(bool trigger)
    {
        this.trigger = trigger;
        Execute();

        if (!(trigger || AutoExecute))
        {
            timebar.pause = true;
        }
    }

    public bool ExitPosition()
    { 
        if (fixWhileCooking && !timebar.end)
            return false;

        //CurPosition = AppliancesType.None;
        timebar.pause = true;
        return true;
    }

    public void Execute()
    {
        //if (timebar == null)
        //    return;

        if (timebar.end || CurPosition != mask)
            return;

        Cookware cookware = GetComponent<Cookware>();
        if (cookware == null || cookware.occupyObj == null)
            return;

        Ingrediant ingrediant = cookware.occupyObj.GetComponent<Ingrediant>();
        if (ingrediant.type != mask)
            return;

        if (AutoExecute || trigger)
        {
            timebar.gameObject.SetActive(true);
            timebar.pause = false;
        }
    }
}
