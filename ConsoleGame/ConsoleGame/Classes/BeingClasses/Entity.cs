using ConsoleGame.Classes;
using System;

namespace ConsoleGame.SuperKlasse
{
    class Entity : ThingClass
    {
        protected int level;
        protected int baseHealth;
        protected int currentHealth;
        protected int basePower;
        protected int currentPower;
        protected int baseDefense;
        protected int currentDefense;
        protected int entitySpeed;
        protected int baseEntitySpeed;

        public Entity(string name, int level, int currentHealth, int currentPower, int currentDefense, int entitySpeed) : base(name)
        {
            this.level = level;
            baseHealth = this.currentHealth = currentHealth;
            basePower = this.currentPower = currentPower;
            baseDefense = this.currentDefense = currentDefense;
            baseEntitySpeed = this.entitySpeed = entitySpeed;
        }

        public int GetLevel() { return level; }
        public int GetPower() { return currentPower; }     
        public int GetHealth() { return currentHealth; }
        public int GetDefence() { return currentDefense; }
        public int GetSpeed() 
        {
            return entitySpeed; 
        }
        public string TakeDamage(int damagePower)
        {
            damagePower = Math.Max(1, damagePower - currentDefense);
            currentHealth = Math.Max(0, currentHealth - damagePower);
            if (currentHealth == 0)
            {
                return (name + " has taken " + damagePower + " damage and died");
            }
            return (name + " has taken " + damagePower + " amount of damage health is now: " + currentHealth);
        }
        public virtual bool AttackCheck()
        {
            return true;
        }
        public void PowerBuff(int buffAmount)
        {
            currentPower += buffAmount;
            Console.WriteLine(name + " got buffed by " + buffAmount + " power is now: " + currentPower);
        }
        public virtual void ResetEntity()
        {
            currentDefense = baseDefense;
            currentHealth = baseHealth;
            currentPower = basePower;
            entitySpeed = baseEntitySpeed;
        }
        public void ReceiveHealing(int healingAmount)
        {
            currentHealth += (healingAmount = (int)Math.Min(baseHealth - currentHealth, healingAmount));
            Console.WriteLine(name + " got " + healingAmount + " amount of healing");
        }        
    }
}
