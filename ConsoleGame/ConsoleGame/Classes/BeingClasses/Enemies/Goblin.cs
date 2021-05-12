using ConsoleGame.SuperKlasse.BeingClasses;

namespace ConsoleGame.Classes.BeingClasses.enemies
{
    class Goblin : Enemy
    {
        public Goblin(int level, bool isSpecialEnemy) : base(name: "goblin", level, currentHealth: 10, currentPower: 3, currentDefense: 3, entitySpeed: 3, isSpecialEnemy)
        {

        }
    }
}
