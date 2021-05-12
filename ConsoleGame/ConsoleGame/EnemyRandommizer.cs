using ConsoleGame.Classes.BeingClasses.enemies;
using ConsoleGame.Classes.BeingClasses.Enemies;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;

namespace ConsoleGame
{
    class EnemyRandommizer
    {
        public Enemy GetRandomEnemy(int level)
        {
            Random randomMizer = new Random();
            switch (randomMizer.Next(1, 11))
            {
                case 2: return new GoblinWarrior(level, false);
                case 3: return new HobGoblin(level, false);
                default:return new Goblin(level, false);
            }
        }
    }
}