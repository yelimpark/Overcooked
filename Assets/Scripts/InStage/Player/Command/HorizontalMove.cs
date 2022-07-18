using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : Command
{
    private PlayerController controller;

    public HorizontalMove(PlayerController controller)
    {
        this.controller = controller;
    }

    public override void Execute(float value)
    {
        PlayerController.AxisType type = PlayerController.AxisType.X;
        controller.SetVelocity(type, value);
    }

    public override void Execute() { }

    public override void Execute(bool value)
    {
        throw new System.NotImplementedException();
    }
}
