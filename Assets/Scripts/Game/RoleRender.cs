using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoleRender : MonoBehaviour
{
    public Button btnRole;

    public Image headImg;

    public Text nameText;

    public Image natureSkillImg;
    private bool _showInfo;
    private void Start()
    {

        btnRole.onClick.AddListener(OnClickRole);
    }

    private void OnClickRole()
    {
        if (!_showInfo) return;

        MessageManager.Instance.ShowMessage("还没做～");
    }
    public void OnData(Hero hero, bool showInfo = false)
    {
        _showInfo = showInfo;
        if (hero != null)
        {
            nameText.text = hero.name;
            if (headImg != null && hero.avatar != null)
            {
                Debug.LogWarning("<<<<avatar<<<<" + hero.avatar);
                byte[] imageBytes = Convert.FromBase64String(hero.avatar);
                Debug.Log("宽:" + headImg.rectTransform.rect.width + "高：" + headImg.rectTransform.rect.height);
                Texture2D tex = new Texture2D((int)headImg.rectTransform.rect.width, (int)headImg.rectTransform.rect.height);
                tex.LoadImage(imageBytes);
                headImg.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
            Sprite natureSprite = ImageLoader.Instance.getSkillAttr(hero.talent.attr);
            if (natureSprite != null)
            {
                natureSkillImg.sprite = natureSprite;
            }else{
                natureSkillImg.sprite = null;
            }
        }
    }
}
