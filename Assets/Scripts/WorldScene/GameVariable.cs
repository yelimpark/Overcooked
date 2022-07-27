using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariable
{
    public static SceneDefinition sceneDefinition;

    public static SceneDefinition GetDefinition()
    {
        return sceneDefinition;
    }

    public static void SetDefinition(SceneDefinition data)
    {
        sceneDefinition = data;
    }
}
