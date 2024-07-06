using UnityEngine;

public class Initializer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        initialLizer();
    }
    private async void initialLizer()
    {
        await PlayerModel.Instance.login();
    }
}

