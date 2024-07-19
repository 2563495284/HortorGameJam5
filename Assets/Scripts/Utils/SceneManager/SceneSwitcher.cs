using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneType
{
    STARTSCENE,
    MAINSCENE,
    GAMESCENE,
    CARDBAGSCENE,
    GAMEROLEPREPARESCENE,
    GAMESKILLPREPARESCENE,
    GAMEPVPQUEUEINGSCENE,
}
public class SceneSwitcher : Singleton<SceneSwitcher>
{

    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadSceneByIndex(ESceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
