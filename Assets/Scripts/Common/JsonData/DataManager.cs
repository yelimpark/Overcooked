using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

public class DataManager : MonoBehaviour
{
    public List<SceneInfo> currentStageInfo;

    private FileInfo fileInfo;

    public TextAsset hgh;

    public void LoadStageData()
    {
        string fileName = "StageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        fileInfo = new FileInfo(path);

        string json = File.ReadAllText(path);
        currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
        

        Debug.Log($"[DataManager] 불러온 파일명 :  {fileName}");

    }
    public void LoadNewStageData()
    {
        string fileName = "DefaultStageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        fileInfo = new FileInfo(path);

        string json = File.ReadAllText(path);
        currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
    
        Debug.Log($"[DataManager] 불러온 파일명 :  {fileName}");

    }


    public void SaveStageData()
    {
        string fileName = "StageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        var setJson = JsonConvert.SerializeObject(currentStageInfo);
        File.WriteAllText(path, setJson);
        Debug.Log($"[DataManager] 저장한 파일명 : {fileName}");
    }

    public void DeleteStageData()
    {
        string fileName = "StageInfo";
        string path = Application.persistentDataPath + "Json" + "/" + fileName + ".Json";

        File.Delete(path);
    }
}
