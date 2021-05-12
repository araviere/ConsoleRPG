using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.UseableObjects.Equipment
{
    class Equipment : ObjectClass
    {
        public Equipment(string name) : base(name)
        {

        }
        public virtual void EquipEquipmentOnPlayer(Player player) { }

    }
    
}
