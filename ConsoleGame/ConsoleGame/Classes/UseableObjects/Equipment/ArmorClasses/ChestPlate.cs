using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.ArmorClasses
{
    class ChestPlate : Armor
    {
        public ChestPlate(string name,int lvlRequirment, int armorRating, int armorSlownes) : base(armorSlot: 1, name, lvlRequirment, armorRating, armorSlownes)
        {

        }
    }
}
