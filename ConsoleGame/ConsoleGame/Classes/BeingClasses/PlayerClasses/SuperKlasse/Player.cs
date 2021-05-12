using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.Classes.ItemClasses;
using ConsoleGame.Classes.ItemClasses.SuperClasse;
using ConsoleGame.Classes.PotionClasses;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.PotionClasses.SuperClasse;
using System;
using System.Collections.Generic;

namespace ConsoleGame.SuperKlasse.BeingClasses
{
    class Player : Entity
    {
        protected List<Potion> potionBack = new List<Potion>();
        protected List<Item> itemBack = new List<Item>();
        private PlayerCombatMenu combatMenu = new PlayerCombatMenu();
        private int maxXP = 100;
        private int currentXP = 0;
        private Armor[] armorSet = new Armor[4];
        protected Weapon weapon;
        private Guild playerGuild;

        public Player(string name, int currentHealth, int currentPower, int currentDefense, int entitySpeed) : base(name, level: 1, currentHealth, currentPower, currentDefense, entitySpeed)
        {
            potionBack.Add(new HealingPotion("healingpotion", 4, 10));
        }
        public Armor[] GetArmor() { return armorSet; }
        public Weapon GetWeapon() { return weapon; }
        public Guild GetPlayerGuild() { return playerGuild; }
        public void SetPlayerGuild(Guild guild) 
        {
            playerGuild = guild;
            itemBack.Add(new ResurectionStone(1, playerGuild));
        }
        public bool ItsTurn(List<Enemy> enemyEncounterGroup)
        {
            if (currentHealth > 0)
            {
                combatMenu.StartOfMenu(enemyEncounterGroup, this);
                return true;
            }
            else
            {
                Console.WriteLine(name + " is death so can't fight");
                return false;
            }
        }
        public virtual void WeaponEquip(Weapon pickedWeapon)
        {
            if (weapon != null)
            currentPower = basePower -= weapon.GetWeaponPower();
            weapon = pickedWeapon;
            currentPower = basePower += weapon.GetWeaponPower();
        }
        public void ArmorEquip(Armor armor)
        {            
            if(armorSet[armor.GetArmorSlot()] != null)
            {
                currentDefense = baseDefense  = Math.Max(1, baseDefense - armorSet[armor.GetArmorSlot()].GetArmorRating());
                entitySpeed = (baseEntitySpeed += armorSet[armor.GetArmorSlot()].GetArmorSlowness());
            }
            armorSet[armor.GetArmorSlot()] = armor;
            currentDefense = baseDefense = Math.Max(1, baseDefense + armor.GetArmorRating());
            entitySpeed = (baseEntitySpeed -= armor.GetArmorSlowness());
        }
        public List<Potion> GetPotionList()
        {
            return potionBack;
        }
        public List<Item> GetItemList()
        {
            return itemBack;
        }        
        public string SetXP(int xpAmount)
        {
            Console.WriteLine(name + " got " + xpAmount + " amount of Xp");
            currentXP += xpAmount;
            if (currentXP >= maxXP)
            {
                while(currentXP - maxXP > 0)
                currentXP -= maxXP; LevelUp();
            }
            return (name + " got " + xpAmount + " of X; xp is now: " + currentXP);
        }
        string LevelUp()
        {
            level++;
            currentHealth = baseHealth += ((4 * baseHealth) / 7);
            maxXP = (100 * level);
            return (name + " Leveled Up");
        }

        public override string WrithDiscription()
        {
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("name: " + name);
            Console.WriteLine("class: " + this.GetType().ToString().Split(".")[this.GetType().ToString().Split(".").Length - 1]);
            Console.WriteLine("[Health]: " + currentHealth + " [Power]:" + currentPower + " [Defence]: " + currentDefense);
            return "";
        }
    }
}
