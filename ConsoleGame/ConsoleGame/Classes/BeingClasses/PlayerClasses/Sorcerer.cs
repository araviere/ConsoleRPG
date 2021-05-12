using ConsoleGame.Classes.ArmorClasses;
using ConsoleGame.Classes.PotionClasses;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.BeingClasses.PlayerClasses
{
    class Sorcerer : Player
    {
        public Sorcerer(string name) : base(name, currentHealth: 9000, currentPower: 1, currentDefense: 1, entitySpeed: 5)
        {

            potionBack.Add(new StrengtPotion("manapotion", 4, 9));
            ArmorEquip(new HeadGear("basic hood", 1, 1, 0));
            ArmorEquip(new ChestPlate("basic robe", 1, 1, 0));
            ArmorEquip(new Pants("basic Pants", 1, 1, 0));
            ArmorEquip(new Boots("basic Boots", 1, 1, 0));
            WeaponEquip(new Weapon("basic Wand", 2000));

        }
    }
}
