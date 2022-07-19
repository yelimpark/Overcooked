using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Scene Information", menuName = "Scriptable Oject/Scene Information")]
public class SceneDefinition : ScriptableObject
{
    public string SceneName;
    public Sprite StageImage;
    public int[] StarScores;
    

}
