using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using ConsoleGame.Classes.UseableObjects.Equipment;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleGame.Classes.GuildClasses
{
    class Guild
    {
        private Player[] guild = new Player[1];
        private List<Equipment> armorBack = new List<Equipment>();
        private List<Equipment> weaponBag = new List<Equipment>();

        public Player GetPlayerGuildMember(int guildNumber) { return guild[guildNumber]; }
        public Player[] GetPlayerlist() { return guild; }
        public int GetGuildSize() { return guild.Length; }     
        public List<Equipment> GetWeaponBag() { return weaponBag; }
        public List<Equipment> GetArmorBack() { return armorBack; }
        public void SetPlayerGuildMember(Player player, int guildNumber) { guild[guildNumber] = player;}

        public void AddToArmorBack(Armor armor) { armorBack.Add(armor); }
        public void AddToWeaponBack(Weapon weapon) { weaponBag.Add(weapon); }

        public void ShowParty()
        {
            foreach(Player player in guild)
            {
                Console.WriteLine(player.GetName());
                Console.WriteLine(player.GetWeapon().WrithDiscription());
                Console.WriteLine();
                foreach(Armor armor in player.GetArmor())
                {
                    Console.WriteLine(armor.WrithDiscription());
                }
                Console.WriteLine();
            }
        }
    }
}
