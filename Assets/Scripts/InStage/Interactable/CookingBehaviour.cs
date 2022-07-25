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

    public AppliancesType mask;

    private AppliancesType curPosition;
    public AppliancesType CurPosition
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

        // 원래는 오브젝트 풀에 요청해야 함. 테스트 코드.
        GameObject after = GameObject.Find(ingrediant.next);
        after.SetActive(true);

        cookware.OnPlace(after);

        //반환
        before.SetActive(false);
    }

    //private void Update()
    //{
    //    Vector3 newPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
    //    newPos.y += Yoffset;
    //    timebar.transform.position = newPos;

    //    임시코드!!!!!!
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        trigger = true;
    //        Execute();
    //    }
    //}

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
        if (ingrediant.mask != mask)
            return;

        if (AutoExecute || trigger)
        {
            timebar.gameObject.SetActive(true);
            timebar.pause = false;
        }
    }
}
