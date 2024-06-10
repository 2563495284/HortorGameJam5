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
    }
}