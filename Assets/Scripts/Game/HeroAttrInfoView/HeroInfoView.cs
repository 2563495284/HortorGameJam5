
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HeroInfoView : Singleton<HeroInfoView>
{
    public GameObject heroInfoView;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameObject heroInfoViewPrefab = Resources.Load<GameObject>("Prefabs/HeroInfoView");
        if (heroInfoViewPrefab)
        {
            heroInfoView = Instantiate(heroInfoViewPrefab);
            heroInfoView.transform.SetParent(this.gameObject.transform);
            heroInfoView.SetActive(false);

        }
        else
        {
            Debug.LogError("heroInfoView is null");
        }
    }



    public void ShowHeroInfoView(Hero hero)
    {
        if (hero == null) return;
        HeroInfoAttrListMng heroInfoAttrListMng = heroInfoView.GetComponent<HeroInfoAttrListMng>();
        heroInfoAttrListMng.PopulateHeroAttrList(hero);
        heroInfoView.SetActive(true);
    }
    public void HideHeroInfoView()
    {
        if (heroInfoView)
        {
            heroInfoView.SetActive(false);
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}