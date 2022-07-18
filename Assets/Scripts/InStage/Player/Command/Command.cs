using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();

    public abstract void Execute(float value);

    public abstract void Execute(bool value);
}
