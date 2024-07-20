using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class GameRolePrepareListMng : MonoBehaviour
{
    public Transform roleScrollContent; // 这个是Content对象的Transformm

    public GameObject Role;//选择的主角
    public ObjectPool listItemRoleObjectPool;
    void Start()
    {
        PopulateRoleList();
        RefreshRole();
    }
    void OnDestroy()
    {

    }
    public void PopulateRoleList()
    {
        // Clear existing items (optional)
        foreach (Transform child in roleScrollContent)
        {
            listItemRoleObjectPool.ReturnPooledObject(child.gameObject);
        }
        List<Hero> listHeros = PlayerModel.Instance.role.heros;
        // Create new items
        for (int i = 0; i < listHeros.Count; i++)
        {
            Hero hero = listHeros[i];
            GameObject listItem = listItemRoleObjectPool.GetPooledObject();
            listItem.transform.SetParent(roleScrollContent);
            listItem.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            listItem.SetActive(true); // 确保模板项是启用状态
            // 设置按钮的文本（你可以根据具体需求进行各种设置）
            RoleRender roleRender = listItem.GetComponentInChildren<RoleRender>();
            if (roleRender != null)
            {
                roleRender.OnData(hero, onClickRole, onShowRoleInfo);
            }

        }
    }
    public void RefreshRole()
    {
        Hero hero = PlayerModel.Instance.curtHero;
        RoleRender roleRender = Role.GetComponentInChildren<RoleRender>();
        if (roleRender != null)
        {
            roleRender.OnData(hero, onClickRole, onShowRoleInfo);
        }
    }
    public void onClickRole(Hero hero)
    {
        PlayerModel.Instance.setCurtHero(hero);
        RefreshRole();
    }
    private void onShowRoleInfo(Hero hero)
    {
        HeroInfoView.Instance.ShowHeroInfoView(hero);
    }
}
