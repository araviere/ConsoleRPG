using ConsoleGame.Classes.UseableObjects;
using ConsoleGame.SuperKlasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.PotionClasses.SuperClasse
{
    class Potion : ObjectClass
    {
        protected int uses;
        protected int amount;

        public Potion(string name, int uses, int amount) : base(name)
        {
            this.uses = uses;
            this.amount = amount;
        }

        public int GetUses() { return uses; }

        public int GetAmount() { return amount; }

        public virtual void Use(Entity being)
        {
            Console.WriteLine("potion of " + name + " used");
            uses--;
        }

        public override string WrithDiscription()
        {
            return name + " strenght: " + amount + " uses: " + uses;
        }
    }
}
