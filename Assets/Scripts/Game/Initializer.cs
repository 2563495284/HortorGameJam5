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
        if (MessageManager.Instance == null) // ֻ��û��ʵ���������ʵ����
        {
            Instantiate(messageManagerPrefab);
        }
        //���������ļ�
        string gameConfDir =Application.dataPath+ "/../output"; // �滻Ϊgen.bat��outputDataDirָ���Ŀ¼
        var tables = new cfg.Tables(file => JSON.Parse(File.ReadAllText($"{gameConfDir}/{file}.json")));
        Debug.Log(tables.TbItem.DataList);
    }
}