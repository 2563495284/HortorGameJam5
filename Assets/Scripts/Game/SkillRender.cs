using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillRender : MonoBehaviour
{
    public Text skillName;
    public Button btnSkill;

    public Text skillRound;
    public Text skillMpCost;

    public Image skillMainAttrImg;
    public Image skillSubAttrImg;
    private bool _showInfo;
    private void Start()
    {

        btnSkill.onClick.AddListener(OnClickSkill);
    }
    private void OnClickSkill()
    {
        if (!_showInfo) return;
        MessageManager.Instance.ShowMessage("还没做～");
    }
    public void OnData(Skill skill, bool showInfo = false)
    {
        _showInfo = showInfo;
        if (skill != null)
        {
            skillName.text = skill.name;
            skillMpCost.text = $"{skill.mp}";
            long maxRound = 0;
            skill.mechanics.ForEach(mechanic => { if (mechanic.round > maxRound) { maxRound = mechanic.round; } });
            if (maxRound > 0)
            {
                skillRound.text = $"{maxRound}";
            }
            else
            {
                skillRound.text = "";
            }
        }
        if (skill.attrSummary.Count >= 2)
        {
            Sprite mainSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[0]);
            Sprite subSprite = ImageLoader.Instance.getSkillAttr(skill.attrSummary[1]);
            if (mainSprite)
            {

                skillMainAttrImg.sprite = mainSprite;
            }
            if (subSprite)
            {
                skillSubAttrImg.sprite = subSprite;
            }
        }
    }
}
