using ConsoleGame.Classes.UseableObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.ItemClasses.SuperClasse
{
    class Item : ObjectClass
    {
        protected int amount;

        public Item(string name, int amount) : base(name)
        {
            this.amount = amount;
        }

        public int GetAmount() { return amount; }

        public string SetAmount(int i) {amount += i; return " has added " + amount + " " + name + " to there inventory"; }

        public virtual bool Use()
        {
            Console.WriteLine("used " + name);
            return false;
        }
        public override string WrithDiscription()
        {
            return name + " Amount: " + amount;
        }
    }
}
