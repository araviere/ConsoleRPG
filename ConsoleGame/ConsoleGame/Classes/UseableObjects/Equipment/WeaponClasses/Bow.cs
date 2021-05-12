using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.UseableObjects.Equipment
{
    class Bow : Weapon
    {
        int baseArrowAmount;
        int currentArrowAmount;
        public Bow(string name, int weaponPower, int arrows): base (name, weaponPower)
        {
            currentArrowAmount = baseArrowAmount = arrows;
        }
        public int GetArrows() { return currentArrowAmount; }
        public void ShootBow() { currentArrowAmount--; }
        public void ResetArrows() { currentArrowAmount = baseArrowAmount; }

    }
}
