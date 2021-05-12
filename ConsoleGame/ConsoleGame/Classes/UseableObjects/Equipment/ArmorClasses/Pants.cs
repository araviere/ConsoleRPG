using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.ArmorClasses
{
    class Pants : Armor
    {
        public Pants(string name, int lvlRequirment, int armorRating, int armorSlownes) : base(armorSlot: 2, name, lvlRequirment, armorRating, armorSlownes)
        {

        }
    }
}
