using ConsoleGame.Classes.UseableObjects.Equipment;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.WeaponClasses.SuperClasse
{
    class Weapon : Equipment
    {
        private int weaponPower;
        public Weapon(string name, int weaponPower) : base(name)
        {
            this.weaponPower = weaponPower;
        }
        public int GetWeaponPower() { return weaponPower; }
        public override string WrithDiscription()
        {
            return "weapon: " + name + " power: " + weaponPower;
        }
        public override void EquipEquipmentOnPlayer(Player player)
        {
            player.WeaponEquip(this);
        }

    }
}
