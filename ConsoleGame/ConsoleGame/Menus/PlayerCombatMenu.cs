using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    class PlayerCombatMenu
    {
        List<Enemy> enemyPartyGroupList = new List<Enemy>();
        Player player;
        public void StartOfMenu(List<Enemy> stransit, Player player)
        {
            this.player = player;
            enemyPartyGroupList = stransit;
            player.WrithDiscription();
            WriteEnemyTeam();
            Console.WriteLine();
            ChoiceMenu();
        }
        void WriteEnemyTeam()
        {
            Console.WriteLine("_____________________________________________________________________________");
            for (int repeater = 0; repeater < enemyPartyGroupList.Count;)
            {
                Console.WriteLine(enemyPartyGroupList[repeater].WrithDiscription());
                repeater++;
            }
        }
        void ChoiceMenu()
        {
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("what do you like to do?");
            Console.WriteLine("attack");
            Console.WriteLine("use potion");
            Console.WriteLine("use item");
            switch (Console.ReadLine().ToLower())
            {
                case string s when (s.Contains("attack")): Attacking(); break;
                case string s when (s.Contains("potion")): UsePotion(); break;
                case string s when (s.Contains("item")): UseItem(); break;
                default: Console.WriteLine("you can't do that"); ChoiceMenu(); break;
            }
        }
        void Attacking()
        {
            Console.WriteLine("_____________________________________________________________________________");
            WriteEnemyTeam();
            Console.WriteLine("back");
            Console.WriteLine("which enemy would you like to attack");

            try
            {
                switch (Console.ReadLine().ToLower())
            {
                 case string s when ((enemyPartyGroupList.Find(x => x.GetName().Contains(s)).GetName() == s) && player.AttackCheck() == true):
                    Console.WriteLine(enemyPartyGroupList.Find(x => x.GetName().Contains(s)).TakeDamage(player.GetPower(), enemyPartyGroupList));
                        break;
                case string s when ((enemyPartyGroupList.Exists(x => x.GetName().Contains(s)) && enemyPartyGroupList.Find(x => x.GetName().Contains(s)).GetName() == s) && player.AttackCheck() == true):
                        Console.WriteLine(enemyPartyGroupList.Find(x => x.GetName().Contains(s)).TakeDamage(player.GetPower(), enemyPartyGroupList));
                    break;
                case string s when (s.Contains("back")): ChoiceMenu(); break;
                default: Console.WriteLine("you can't do that!"); Attacking(); break;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("you can't do that!"); Attacking();
            }
        }
        void UsePotion()
        {
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("what potion do you want to use?");
            for (int repeater = 0; repeater < player.GetPotionList().Count;)
            {
                Console.WriteLine(player.GetPotionList()[repeater].WrithDiscription());
                repeater++;
            }
            Console.WriteLine("back");
            Console.WriteLine();
            try
            {
                switch (Console.ReadLine().ToLower())
                {
                    case string s when (player.GetPotionList().Exists(x => x.GetName().Contains(s))):
                            player.GetPotionList().Find(x => x.GetName().Contains(s)).Use(player); break;
                    case string s when (s.Contains("back")): ChoiceMenu(); break;
                    default: Console.WriteLine("you can't use that!"); UsePotion(); break;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("you can't use that!"); UsePotion();
            }
        }
        void UseItem()
        {
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("what item do you want to use?");
            for (int repeater = 0; repeater < player.GetItemList().Count;)
            {
                Console.WriteLine(player.GetItemList()[repeater].WrithDiscription());
                repeater++;
            }
            Console.WriteLine("back");
            Console.WriteLine();
            try
            {
                switch (Console.ReadLine())
                {
                    case string s when (s.Contains("back")): ChoiceMenu(); break;
                    case string s when (player.GetItemList().Exists(x => x.GetName().Contains(s))):
                        if (player.GetItemList().Find(x => x.GetName().Contains(s)).Use() == false)
                        { break; }
                        else
                            Console.WriteLine("you don't have that item"); UseItem();
                        break;
                    default: Console.WriteLine("you can't use that!"); UseItem(); break;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("you can't use that!"); UseItem();
            }
        }
    }
}
