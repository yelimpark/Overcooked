using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoockwareType
{
    NONE,
    FRYPAN,
    CUTTING_BOARD,
    PLATE,
    FIRE_EXTINGUISHER,
    HANDS
}

public class Cookware : Slot
{
    public TimeBar timebar;

    protected CoockwareType type;

    private CoockwareType position;
    public CoockwareType Position
    {
        get { return position; }
        set 
        {
            position = value;
            Execute();
        }
    }

    public virtual void Start()
    {
        AcceptableTag.Add("Ingrediant");
    }

    public override bool AbleToPlace(GameObject go)
    {
         if (!base.AbleToPlace(go))
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.type != type)
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
        if (ingrediant.type == type)
            return false;

        if (dest == null)
            return false;

        Slot slot = dest.GetComponent<Slot>();
        return slot != null && slot.AbleToPlace(occupyObj);
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        return base.OnTakeOut(dest);
    }

    public virtual void Execute()
    {
        if (Position != type)
            return;

        if (occupyObj == null)
            return;

        Ingrediant ingrediant = occupyObj.GetComponent<Ingrediant>();
        if (ingrediant.type != type)
            return;

        timebar.gameObject.SetActive(true);
        timebar.pause = false;
    }

    public virtual void OnTimeUp()
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

        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach(var player in players)
        {
            if (player.GetComponent<InputHandler>().enabled)
                player.GetComponent<Animator>().SetBool("isChoping", false);
        }
    }
}
