using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene Information", menuName = "Scriptable Oject/Scene Information")]
public class SceneDefinition : ScriptableObject
{
    public string SceneName;
    public GameObject StageImage;
    public int[] StarScores;
    

}
