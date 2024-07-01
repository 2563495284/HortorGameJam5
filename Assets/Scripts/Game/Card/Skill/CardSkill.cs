using System;
using Card;
namespace Card
{

    public class CardSkill
    {
        protected float costMp;

        protected int lastRound;

        protected ECardSkillType cardSkillType;

        protected ECardSkillActionType cardSkillActionType;

        protected CardAction cardAction;

        public CardSkill(ECardSkillType cardSkillType, ECardSkillActionType cardSkillActionType, float costMp, int lastRound)
        {
            this.cardSkillType = cardSkillType;
            this.cardSkillActionType = cardSkillActionType;
            this.costMp = costMp;
            this.lastRound = lastRound;

            switch (cardSkillActionType)
            {
                case ECardSkillActionType.ATTACK:
                    cardAction = new AttackAction(costMp, lastRound);
                    break;

                case ECardSkillActionType.DEFEND:
                    cardAction = new DefenseAction(costMp, lastRound);
                    break;

                case ECardSkillActionType.CURE:
                    cardAction = new CureAction(costMp, lastRound);
                    break;
                default:
                    cardAction = new AttackAction(costMp, lastRound);
                    break;
            }
        }

    }
}