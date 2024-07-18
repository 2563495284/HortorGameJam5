using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRender : MonoBehaviour
{
    public Text skillName;
    public Button btnSkill;

    public Text skillRound;
    public Text skillMpCost;

    private void Start()
    {

        btnSkill.onClick.AddListener(OnClickSkill);
    }
    private void OnClickSkill()
    {
        MessageManager.Instance.ShowMessage("还没做～");
    }
    public void OnData(Skill skill)
    {
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
    }
}
