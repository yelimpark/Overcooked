using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public void ExecuteCommand(Command command)
    {
        command.Execute();
    }

    public void ExecuteCommand(Command command, float value)
    {
        command.Execute(value);
    }

    public void ExecuteCommand(Command command, bool value)
    {
        command.Execute(value);
    }
}
