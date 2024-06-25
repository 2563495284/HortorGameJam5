using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneType
{
    STARTSCENE,
    MAINSCENE,
    GAMESCENE
}
public class SceneSwitcher : Singleton<SceneSwitcher>
{
    // 加载指定名称的场景
    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 加载指定索引的场景
    public static void LoadSceneByIndex(ESceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }
}
