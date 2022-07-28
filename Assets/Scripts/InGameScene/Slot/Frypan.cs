using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frypan : Slot
{
    public TimeBar timebar;

    private CoockwareType position;
    public CoockwareType Position
    {
        get { return Position; }
        set
        {
            Position = value;
            Execute();
        }
    }

    private void Start()
    {
        AcceptableTag.Add("Ingrediant");
    }

    public void OnTimeUp()
    {
        if (occupyObj == null)
            return;

        timebar.Init();

        GameObject before = OnTakeOut(null);
        Ingrediant ingrediant = before.GetComponent<Ingrediant>();

        GameObject ObjPoolMgrGO = GameObject.FindGameObjectWithTag("ObjPoolMgr");
        ObjectPoolManager ObjPoolMgr = ObjPoolMgrGO.GetComponent<ObjectPoolManager>();
        GameObject after = ObjPoolMgr.Extract(ingrediant.next).gameObject;

        base.OnPlace(after);

        PoolingObject po = before.GetComponent<PoolingObject>();
        ObjPoolMgr.Return(po);
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (!base.AbleToPlace(go))
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.type != CoockwareType.FRYPAN)
            return false;

        if (occupyObj != null)
            return false;

        return true;
    }

    public override void OnPlace(GameObject go)
    {
        base.OnPlace(go);
        Execute();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (!base.AbleToTakeOut(dest))
            return false;

        Ingrediant ingrediant = occupyObj.GetComponent<Ingrediant>();
        if (ingrediant.type == CoockwareType.FRYPAN)
            return false;

        if (dest == null)
            return false;

        Slot slot = dest.GetComponent<Slot>();
        return slot != null && slot.AbleToPlace(occupyObj);
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        timebar.pause = true;
        return base.OnTakeOut(dest);
    }

    public void Execute()
    {
        if (Position != CoockwareType.FRYPAN)
            return;

        Ingrediant ingrediant = occupyObj.GetComponent<Ingrediant>();
        if (ingrediant.type == CoockwareType.FRYPAN)
            return;

        timebar.gameObject.SetActive(true);
        timebar.pause = false;
    }
}
