using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class EnemyAttack
    {
        public bool AttackingPlayer(Guild playerParty, Enemy thisOne)
        {
            if (thisOne.GetHealth() > 0)
            {
                List<int> playerAgrow = new List<int>();
                List<Player> playersAllive = new List<Player>();
                foreach (Player player in playerParty.GetPlayerlist())
                {
                    if (player.GetHealth() > 0)
                    {
                        playersAllive.Add(player);
                    }
                }
                if (playersAllive.Count != 0)
                {
                    playerAgrow.Add(0);
                    Random randomTargetCalculator = new Random();
                    Console.WriteLine(thisOne.GetName() + " turn to attack");
                    for (int repeater = 0; repeater < playersAllive.Count;)
                    {
                        playerAgrow.Add(playersAllive[repeater].GetDefence() + playerAgrow[repeater]);
                        repeater++;
                    }
                    int agrowTarget = randomTargetCalculator.Next(0, playerAgrow[playerAgrow.Count - 1]);
                    for (int repeater = 1; repeater <= playerAgrow.Count;)
                    {
                        if (agrowTarget <= playerAgrow[repeater] )
                        {
                            Console.WriteLine(playersAllive[repeater - 1].TakeDamage(thisOne.GetPower()));
                            Console.WriteLine();

                            return true;
                        }
                        repeater++;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else { return false; }
        }
    }
}
