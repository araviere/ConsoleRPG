using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.Classes.ItemClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Classes.ItemClasses
{
    class ResurectionStone : Item
    {

        Guild playerGuild;
        public ResurectionStone(int amount, Guild playerGuild) : base(name: "resurectionstone", amount)
        {
            this.playerGuild = playerGuild;
        }

        public override bool Use()
        {
            Console.WriteLine("_____________________________________________________________________________");
            if (amount > 0)
            {
                List<Player> graveyard = new List<Player>();
                Console.WriteLine();
                Console.WriteLine("graveyard:");
                foreach (Player player in playerGuild.GetPlayerlist())
                {
                    if (player.GetHealth() == 0)
                    {
                        graveyard.Add(player);
                        Console.WriteLine(player.GetName());
                    }
                }
                Console.WriteLine("back");
                Console.WriteLine();
                Console.WriteLine("witch ally do you want to ressurect?");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case string s when (graveyard.Exists(x => x.GetName().Contains(s))):
                            amount--;
                            graveyard.Find(x => x.GetName().Contains(s)).ReceiveHealing(99999);
                            base.Use();
                            return false;
                        case string s when (s.Contains("back")): return true;
                        default: Console.WriteLine("that's not a player"); return  Use();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("that's not a player");
                    return Use();
                }
                catch (FormatException)
                {
                    Console.WriteLine("that's not a player");
                    return Use();
                }
            }
            else
            {
            Console.WriteLine("you have run out of this item");
            return true;
            }
        }
    }
}