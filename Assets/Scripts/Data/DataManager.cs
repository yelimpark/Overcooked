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

    public void LoadStageData()
    {
        string fileName = "StageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
        {
            Debug.Log($"[DataManager] ���̺� ������ ����");

            fileName = "DefaultStageInfo";
            path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

            string json = File.ReadAllText(path);

            currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
        }
        else
        {
            string json = File.ReadAllText(path);
            currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
        }

        Debug.Log($"[DataManager] �ҷ��� ���ϸ� :  {fileName}");

    }
    public void LoadNewStageData()
    {
        string fileName = "DefaultStageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        fileInfo = new FileInfo(path);

        string json = File.ReadAllText(path);
        currentStageInfo = JsonConvert.DeserializeObject<List<SceneInfo>>(json);
    
        Debug.Log($"[DataManager] �ҷ��� ���ϸ� :  {fileName}");

    }


    public void SaveStageData()
    {
        string fileName = "StageInfo";
        string path = Application.dataPath + "/" + "Json" + "/" + fileName + ".Json";

        var setJson = JsonConvert.SerializeObject(currentStageInfo);
        File.WriteAllText(path, setJson);
        Debug.Log($"[DataManager] ������ ���ϸ� : {fileName}");
    }

    public void DeleteStageData()
    {
        string fileName = "StageInfo";
        string path = Application.dataPath + "Json" + "/" + fileName + ".Json";

        File.Delete(path);
    }
}
