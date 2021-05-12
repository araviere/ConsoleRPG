using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.ArmorClasses
{
    class HeadGear : Armor
    {
        public HeadGear(string name, int lvlRequirment, int armorRating, int armorSlownes) : base(armorSlot: 0, name, lvlRequirment, armorRating, armorSlownes)
        {

        }
    }
}
