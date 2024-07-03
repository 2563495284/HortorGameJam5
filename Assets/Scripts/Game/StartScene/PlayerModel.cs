using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel : Singleton<PlayerModel>
{
    List<Hero> roles;
    private void Awake()
    {
        roles = new List<Hero>();
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    public void addRole(Hero role)
    {
        roles.Add(role);
    }

}

