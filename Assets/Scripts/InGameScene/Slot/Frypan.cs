using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frypan : Cookware
{
    public Animator fireAlarm;
    public float fireTime = 4f;
    private bool fireTrigger = false;
    private IEnumerator fireCorutine;

    public override void Start()
    {
        type = CoockwareType.FRYPAN;
        base.Start();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (dest != null)
        {
            Hands hands = dest.GetComponent<Hands>();
            if (hands != null)
                return false;
        }

        return base.AbleToTakeOut(dest);
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        timebar.pause = true;

        return base.OnTakeOut(dest);
    }

    public override void OnTimeUp()
    {
        base.OnTimeUp();

        fireCorutine = CoSetFire();
        StartCoroutine(fireCorutine);
    }

    public IEnumerator CoSetFire()
    {
        float timer = fireTime;
        // �ִϸ����� trigger
        
        while (timer > 0)
        {
            if (!timebar.pause)
                timer -= Time.deltaTime;
            yield return null;
        }

        // ������
    }
}
