using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes.BeingClasses.Enemies
{
    class GoblinWarrior : Enemy
    {
        public GoblinWarrior(int level, bool isSpecialEnemy) : base(name: "goblinwarrior", level, currentHealth: 15, currentPower: 2, currentDefense: 5, entitySpeed: 1, isSpecialEnemy)
        {

        }
    }
}
