using ConsoleGame.Classes.ArmorClasses;
using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using ConsoleGame.Classes.PotionClasses;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.BeingClasses.PlayerClasses
{
    class Knight : Player
    {
        public Knight (string name) : base(name, currentHealth: 50, currentPower: 1, currentDefense:1, entitySpeed: 3)
        {            

            potionBack.Add(new StrengtPotion("strengthpotion", 4, 9));
            ArmorEquip(new HeadGear("basic HeadGear", 1, 3, 0));
            ArmorEquip(new ChestPlate("basic ChestPlate",1, 5, 1));
            ArmorEquip(new Pants("basic Pants",1, 5, 1));
            ArmorEquip(new Boots("basic Boots",1, 2, 0));
            WeaponEquip(new Weapon("basic Sword", 9));
            
        }
    }
}
