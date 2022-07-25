using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookware : Slot
{
    public AppliancesType mask;
    private CookingBehaviour cb;

    public bool withoutPlate = false;

    private void Start()
    {
        cb = GetComponent<CookingBehaviour>();
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (go == null)
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.mask != mask)
            return false;

        if (occupyObj != null)
        {
            Ingrediant occupyIngrediant = occupyObj.GetComponent<Ingrediant>();
            if (occupyIngrediant.combinedWith == ingrediant.IngrediantName)
            {
                return true;
            }
        }

        return base.AbleToPlace(go);
    }

    public override void OnPlace(GameObject go)
    {
        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant != null && occupyObj != null)
        {
            Ingrediant occupyIngrediant = occupyObj.GetComponent<Ingrediant>();
            if (occupyIngrediant.combinedWith == ingrediant.IngrediantName)
            {
                // 원래는 오브젝트 풀에 요청해야 함. 테스트 코드.
                GameObject ObjPoolMgrGO = GameObject.FindGameObjectWithTag("ObjPoolMgr");
                ObjectPoolManager ObjPoolMgr = ObjPoolMgrGO.GetComponent<ObjectPoolManager>();
                GameObject after = ObjPoolMgr.Extract(occupyIngrediant.next).gameObject;
                after.SetActive(true);

                var before = OnTakeOut(null);
                OnPlace(after);

                //반환
                before.SetActive(false);
            }
        }

        base.OnPlace(go);

        if (ingrediant != null && ingrediant.mask == mask && cb != null)
            cb.Execute();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (cb != null && !cb.ExitPosition())
            return false;

        if (withoutPlate)
            return true;

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
