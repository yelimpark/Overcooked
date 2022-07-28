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
    public CoockwareType type;
    private CookingBehaviour cb;

    private void Start()
    {
        cb = GetComponent<CookingBehaviour>();
        AcceptableTag.Add("Ingrediant");
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (!base.AbleToPlace(go))
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.type != type)
            return false;

        return true;
    }

    public override void OnPlace(GameObject go)
    {
        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant != null && occupyObj != null)
        {
            Ingrediant occupyIngrediant = occupyObj.GetComponent<Ingrediant>();
            if (occupyIngrediant.combinedWith == ingrediant.IngrediantName)
            {
                // ������ ������Ʈ Ǯ�� ��û�ؾ� ��. �׽�Ʈ �ڵ�.
                GameObject ObjPoolMgrGO = GameObject.FindGameObjectWithTag("ObjPoolMgr");
                ObjectPoolManager ObjPoolMgr = ObjPoolMgrGO.GetComponent<ObjectPoolManager>();
                GameObject after = ObjPoolMgr.Extract(occupyIngrediant.next).gameObject;
                //after.SetActive(true);

                var before = OnTakeOut(null);
                OnPlace(after);

                //��ȯ
                PoolingObject po = before.GetComponent<PoolingObject>();
                ObjPoolMgr.Return(po);
                before.SetActive(false);
            }
        }

        base.OnPlace(go);

        if (ingrediant != null && ingrediant.type == type && cb != null)
            cb.Execute();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (cb != null && !cb.ExitPosition())
            return false;

        if (dest != null)
        {
            Cookware cookware = dest.GetComponent<Cookware>();
            if (cookware == null || cookware.AbleToPlace(occupyObj))
                return true;
        }

        return false;
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        return base.OnTakeOut(dest);
    }
}
