using System.Collections.Generic;
using UnityEngine;
namespace Card
{

    public class RoleCard : MonoBehaviour
    {
        public int cardId;

        public string cardName;

        public float maxHp;

        public float hp;

        public float maxMp;

        public float mp;

        public float maxDef;

        public float def;

        private List<CardSkill> natureSkills;

        private List<CardSkill> specialSkills;


        private List<CardSkill> basicSkills;
        private void Awake()
        {

        }
        private void Start()
        {

        }
    }
}
