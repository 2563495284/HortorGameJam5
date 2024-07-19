using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoRender : MonoBehaviour
{
    public Text skillName;
    public Text mpCost;
    public Text skillRound;
    public Text skillDesc;

    public Button btnClose;

    private void Start()
    {
        btnClose.onClick.AddListener(OnClickClose);
    }
    public void OnData(Skill skill)
    {
        if (skill != null)
        {
            skillName.text = skill.name;
            mpCost.text = $"{skill.mp}";
            long maxRound = 0;
            skill.mechanics.ForEach(mechanic => { if (mechanic.round > maxRound) { maxRound = mechanic.round; } });
            if (maxRound > 0)
            {
                skillRound.text = $"{maxRound}";
            }
            else
            {
                skillRound.text = "0";
            }
            skillDesc.text = skill.desc;
        }
    }
    private void OnClickClose()
    {
        SkillInfoView.Instance.HideSkillInfoView();
    }

}
