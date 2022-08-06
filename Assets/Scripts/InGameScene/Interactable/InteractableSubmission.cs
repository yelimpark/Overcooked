using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSubmission : Interactable, IPlace
{
    public KitchenManager km;
    public ObjectPoolManager poolManager;

    public bool Place(EquipmentSystem es)
    {
        Plate plate = es.hands.OccupyObj.GetComponent<Plate>();
        if (plate != null)
        {
            if (plate.AbleToTakeOut())
            {
                var food = plate.OnTakeOut();

                km.OnSubmit(food);

                PoolingObject foodPO = food.GetComponent<PoolingObject>();
                poolManager.Return(foodPO);
            }
            else
            {
                km.OnSubmit(null);
            }

            var plateGo = es.Unequip();
            es.UnequipEnd();
            PoolingObject po = plateGo.GetComponent<PoolingObject>();
            if (po != null)
                poolManager.Return(po);
            else
                plateGo.SetActive(false);
        }

        return false;
    }
}
