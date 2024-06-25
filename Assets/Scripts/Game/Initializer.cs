using cfg;
using SimpleJSON;
using System;
using System.IO;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameObject messageManagerPrefab;
    private void Awake()
    {
        if (MessageManager.Instance == null) // 只在没有实例的情况下实例化
        {
            Instantiate(messageManagerPrefab);
        }
        //加载配置文件
        string gameConfDir =Application.dataPath+ "/../output"; // 替换为gen.bat中outputDataDir指向的目录
        var tables = new cfg.Tables(file => JSON.Parse(File.ReadAllText($"{gameConfDir}/{file}.json")));
        Debug.Log(tables.TbItem.DataList);
    }
}