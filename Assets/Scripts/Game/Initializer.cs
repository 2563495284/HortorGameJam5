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
    }
}