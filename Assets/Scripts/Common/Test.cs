using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int _Score = 0;

    private void Start()
    {
        List<Dictionary<string, string>> data = CSVReader.Read("csv_StageInfo");

        for(var i = 0; i < data.Count; i++)
        {
            Debug.Log("index" + (i).ToString() + " : " + data[i]["Stage"] + " " + data[i]["Score"]);
        }

        //_Score = (int)data[0]["Stage"];

    }
}
