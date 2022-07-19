using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public void Save()
    {
        GameManager.Instance.SaveLoadManager.Save();
    }

    public void Load()
    {
        
    }
    
    
}
