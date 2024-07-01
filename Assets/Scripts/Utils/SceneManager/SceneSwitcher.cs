using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneType
{
    STARTSCENE,
    MAINSCENE,
    GAMESCENE,
    CARDBAGSCENE
}
public class SceneSwitcher : Singleton<SceneSwitcher>
{
    // ����ָ�����Ƶĳ���
    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ����ָ�������ĳ���
    public static void LoadSceneByIndex(ESceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }
}
