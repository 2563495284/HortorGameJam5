namespace Utils
{
    public class HeroAdaptor
    {
        public static Hero transformBattleHeroResp(BattleFinishHeroResp battleHero)
        {
            var hero = new Hero();
            hero.id = battleHero.id;
            hero.name = battleHero.name;
            hero.battleSkills = battleHero.battleSkills;
            hero.avatar = battleHero.avatar;
            hero.hp = battleHero.hp;
            hero.mp = battleHero.mp;
            hero.talent = battleHero.talent;
            return hero;
        }
    }
}