using ConsoleGame.PotionClasses.SuperClasse;
using ConsoleGame.SuperKlasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.PotionClasses
{
    class HealingPotion : Potion
    {
        public HealingPotion(string name, int uses, int amount) : base(name, uses, amount)
        {

        }
        public override void Use(Entity entity)
        {
            entity.ReceiveHealing(amount);
            base.Use(entity);
        }
    }
}
