using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Slot
{
    private void Start()
    {
        AcceptableTag.Add("Ingrediant");
    }

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
        if (occupyObj != null)
        {
            Ingrediant ingrediant = go.GetComponent<Ingrediant>();
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
        else
        {
            base.OnPlace(go);
        }
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (dest == null)
            return false;

        Slot slot = dest.GetComponent<Slot>();
        return slot != null && slot.AbleToPlace(occupyObj);
    }
}
