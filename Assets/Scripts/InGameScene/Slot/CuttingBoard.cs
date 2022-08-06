using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : Cookware
{
    private bool trigger;
    private Animator playerAnimator;

    public override void Start()
    {
        type = CoockwareType.CUTTING_BOARD;
        Position = CoockwareType.CUTTING_BOARD;
        base.Start();
    }

    public void Trigger(Animator animator)
    {
        playerAnimator = animator;
        trigger = true;
        Execute();
        trigger = false;
    }

    public override void Execute()
    {
        if (!trigger)
            return;

        base.Execute();

        if(timebar.gameObject.activeSelf)
            playerAnimator.SetBool("isChoping", true);
    }

    public override void OnTimeUp()
    {
        base.OnTimeUp();

        playerAnimator.SetBool("isChoping", false);
    }
}
