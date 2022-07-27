using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Slot
{
    public override bool AbleToPlace(GameObject go)
    {
        if (!base.AbleToPlace(go))
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.type != CoockwareType.PLATE)
            return false;

        if (occupyObj != null)
        {
            Ingrediant occupyIngrediant = occupyObj.GetComponent<Ingrediant>();
            return occupyIngrediant.combinedWith == ingrediant.IngrediantName;
        }

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
                GameObject ObjPoolMgrGO = GameObject.FindGameObjectWithTag("ObjPoolMgr");
                ObjectPoolManager ObjPoolMgr = ObjPoolMgrGO.GetComponent<ObjectPoolManager>();
                GameObject after = ObjPoolMgr.Extract(occupyIngrediant.next).gameObject;

                var before = OnTakeOut(null);
                OnPlace(after);

                PoolingObject po = before.GetComponent<PoolingObject>();
                ObjPoolMgr.Return(po);
            }
        }

        base.OnPlace(go);
    }

    public override bool AbleToTakeOut(GameObject dest)
    {

    }
}
