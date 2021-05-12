using ConsoleGame.PotionClasses.SuperClasse;
using ConsoleGame.SuperKlasse;
using System;
namespace ConsoleGame.Classes.PotionClasses
{
    class StrengtPotion : Potion
    {
        public StrengtPotion(string name, int uses, int amount) : base(name, uses, amount)
        {

        }

        public override void Use(Entity being)
        {
            being.PowerBuff(amount);
            base.Use(being);
        }
    }
}
