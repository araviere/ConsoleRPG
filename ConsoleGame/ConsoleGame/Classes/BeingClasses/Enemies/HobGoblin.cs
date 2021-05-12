using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.BeingClasses.Enemies
{
    class HobGoblin : Enemy
    {
        public HobGoblin(int level, bool isSpecialEnemy) : base(name: "hobgoblin", level, currentHealth: 15, currentPower: 5, currentDefense: 3, entitySpeed: 4, isSpecialEnemy)
        {

        }
    }
}
