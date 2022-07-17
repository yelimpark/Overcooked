using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
    private PlayerController controller;

    public Move(PlayerController controller)
    {
        this.controller = controller;
    }

    public override void Execute()
    {
        
    }

    public override void Execute(float value)
    {

    }

    public override void Execute(bool value)
    {
        controller.SetAnimationBool("isWalking", value);
    }
}
