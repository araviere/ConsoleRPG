using ConsoleGame.Classes.ArmorClasses;
using ConsoleGame.Classes.PotionClasses;
using ConsoleGame.Classes.UseableObjects.Equipment;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.BeingClasses.PlayerClasses
{
    class Archer : Player
    {
        public Archer(string name) : base(name, currentHealth: 40, currentPower: 1, currentDefense: 1, entitySpeed: 5)
        {

            potionBack.Add(new StrengtPotion("arrowpotion", 4, 9));
            ArmorEquip(new HeadGear("basic Hood", 1, 2, 0));
            ArmorEquip(new ChestPlate("basic Robe", 1, 2, 1));
            ArmorEquip(new Pants("basic Pants", 1, 2, 1));
            ArmorEquip(new Boots("basic Boots", 1, 1, 0));
            WeaponEquip(new Bow("basic Bow", 12, 40));

        }
        public override void ResetEntity()
        {
            Bow bow = (Bow)weapon;
            bow.ResetArrows();
            base.ResetEntity();
        }

        public override bool AttackCheck()
        {
            Bow bow = (Bow)weapon;
            if (bow.GetArrows() > 0)
            {
                bow.ShootBow();
                return base.AttackCheck();
            }
            else 
            {
                Console.WriteLine("you're out of arrows!!!");
                return false; 
            }
        }
    }
}
