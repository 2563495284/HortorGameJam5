using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillInfoView : Singleton<SkillInfoView>
{
    public GameObject skillInfoView;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameObject skillInfoViewPrefab = Resources.Load<GameObject>("Prefabs/SkillInfoView");
        if (skillInfoViewPrefab)
        {
            skillInfoView = Instantiate(skillInfoViewPrefab);
            skillInfoView.transform.SetParent(this.gameObject.transform);
            skillInfoView.SetActive(false);

        }
        else
        {
            Debug.LogError("skillInfoView is null");
        }
    }



    public void ShowSkillInfoView(Skill skill)
    {
        SkillInfoRender skillRender = skillInfoView.GetComponent<SkillInfoRender>();
        skillRender.OnData(skill);
        skillInfoView.SetActive(true);
    }
    public void HideSkillInfoView()
    {
        if (skillInfoView)
        {
            skillInfoView.SetActive(false);
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}