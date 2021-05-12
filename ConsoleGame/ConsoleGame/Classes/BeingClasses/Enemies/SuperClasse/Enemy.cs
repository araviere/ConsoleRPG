using ConsoleGame.Classes.GuildClasses;
using System;
using System.Collections.Generic;

namespace ConsoleGame.SuperKlasse.BeingClasses
{
    class Enemy : Entity
    {
        private int xpOnEnemy;
        EnemyAttack attackPlayerTeam = new EnemyAttack();

        public Enemy(string name, int level, int currentHealth, int currentPower, int currentDefense, int entitySpeed, bool isSpecialEnemy) : base(name, level, 
            currentHealth += (currentHealth *= isSpecialEnemy ? level * (3 / 2) : level)/2,
            currentPower += (currentPower *= isSpecialEnemy ? level * (3 / 2) : level)/2,
            currentDefense += (currentDefense *= isSpecialEnemy ? level * (3 / 2) : level)/2, 
            entitySpeed)
        {
            this.xpOnEnemy = isSpecialEnemy ? (currentDefense + currentPower + currentHealth)*5 : (currentDefense + currentPower + currentHealth);
        }

        public int GetXPOnEnemy() { return xpOnEnemy; }

        public bool ItsTurn(Guild playerParty)
        {
            return attackPlayerTeam.AttackingPlayer(playerParty, this);
        }

        public string TakeDamage(int damagePower, List<Enemy> listOfEnemies)
        {
            damagePower = Math.Max(1, damagePower - currentDefense);
            currentHealth = Math.Max(0, currentHealth - damagePower);
            if (currentHealth == 0)
            {
                Death(listOfEnemies);
                return (name + " took " + damagePower + " damage and died");
            }
            return (name + " took " + damagePower + " amount of damage health is now: " + currentHealth);
            void Death(List<Enemy> listOfEnemies)
            {
                Console.WriteLine(name + " died");
                listOfEnemies.Remove(this);
            }
        }
        public override string WrithDiscription()
        {
            return name + " lvl: " + level + " health: " + currentHealth + " power: " + currentPower + " defence: " + currentDefense;
        }
    }
}
