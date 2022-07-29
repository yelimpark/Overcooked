using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

public class DataManager : MonoBehaviour
{
    public List<SceneInfo> currentStageInfo;

    private FileInfo fileInfo;

    public TextAsset DefaultStageInfo;

    public void LoadStageData()
    {
        string fileName = "StageInfo";
        string path = Application.persistentDataPath + fileName + ".Json";

        fileInfo = new FileInfo(path);

        string json = File.ReadAllText(path);
        currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
        

        Debug.Log($"[DataManager] 불러온 파일명 :  {path}");

    }
    public void LoadNewStageData()
    {
        //string fileName = "DefaultStageInfo";
        //string path = Application.persistentDataPath + "/" + "Json" + "/" + fileName + ".Json";

        //fileInfo = new FileInfo(path);

        //string json = File.ReadAllText(path);
        currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(DefaultStageInfo.ToString());
    
        //Debug.Log($"[DataManager] 불러온 파일명 :  {fileName}");

    }


    public void SaveStageData()
    {
        string fileName = "StageInfo";
        string path = Application.persistentDataPath + fileName + ".Json";

        var setJson = JsonConvert.SerializeObject(currentStageInfo);
        File.WriteAllText(path, setJson);
        Debug.Log($"[DataManager] 저장한 파일명 : {fileName}");
    }

    public void DeleteStageData()
    {
        string fileName = "StageInfo";
        string path = Application.persistentDataPath + fileName + ".Json";

        File.Delete(path);
    }
}
