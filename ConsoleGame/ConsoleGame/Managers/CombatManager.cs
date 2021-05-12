using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.SuperKlasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Classes.BeingClasses
{
    class CombatManager
    {
        int totalXPAmount;
        GameManager gameManager;
        List<Entity> encounterList = new List<Entity>();
        Queue<Entity> battleOrder = new Queue<Entity>();
        public void CombatManagment(Guild playerGuild, GameManager gameManager)
        {
            this.gameManager = gameManager;
            List<Enemy> enemyEncounterGroup = EnemyPartyGenerator(playerGuild.GetPlayerGuildMember(0).GetLevel(),gameManager.GetEncounterSize());

            foreach (Player player in playerGuild.GetPlayerlist())
            {
                encounterList.Add(player);
            }
            battleOrder = SortQueue(encounterList);
            CombatRound(playerGuild, enemyEncounterGroup);
        }
        List<Enemy> EnemyPartyGenerator(int level, int encounterSize)
        {
            EnemyRandommizer enemyCreation = new EnemyRandommizer();
            List<Enemy> enemyEncounterGroup = new List<Enemy>();
            
            while (enemyEncounterGroup.Count < encounterSize)
            {
                Enemy enemy = enemyCreation.GetRandomEnemy(level);
                totalXPAmount += enemy.GetXPOnEnemy();
                enemyEncounterGroup.Add(enemy);
                encounterList.Add(enemy);
            }
            return enemyEncounterGroup;
        }
        void CombatRound(Guild playerGuild, List<Enemy> enemyParty)
        {
            int playersAlive = 0;
            foreach(Player player in playerGuild.GetPlayerlist())
            {
               if(player.GetHealth() > 0)
                {
                    playersAlive++;
                }
            }
            
            if (playersAlive == 0) { GameOver();}
                        
            for (int repeater = 0; repeater < encounterList.Count;)
            {
                if(enemyParty.Count == 0) { CombatEnded(playerGuild); }
                switch (battleOrder.Peek().GetType().BaseType.ToString().Split(".").Last())
                {
                    case "Enemy": Enemy enemy = (Enemy)battleOrder.Dequeue(); if(enemy.ItsTurn(playerGuild)) battleOrder.Enqueue(enemy); break;
                    case "Player": Player player = (Player)battleOrder.Dequeue(); if(player.ItsTurn(enemyParty)) battleOrder.Enqueue(player); break;
                    default: Console.WriteLine("OwO wooks wike an ewwow has occuwwwed"); break;
                }
                repeater++;
            }
            if(enemyParty.Count == 0) { CombatEnded(playerGuild); }
            else { CombatRound(playerGuild, enemyParty); }
        }
        Queue<Entity> SortQueue(List<Entity> battleOrder)
        {
            Entity entityHolder;
            Queue<Entity> holder = new Queue<Entity>();
            for (int counter = 0; counter < battleOrder.Count; counter++)
            {
                for (int listPlace = 1; listPlace < battleOrder.Count;)
                {
                    if(battleOrder[listPlace-1].GetSpeed() < battleOrder[listPlace].GetSpeed())
                    {
                        entityHolder = battleOrder[listPlace];
                        battleOrder[listPlace] = battleOrder[listPlace-1];
                        battleOrder[listPlace-1] = entityHolder;
                    }
                    listPlace++;
                }
            }
            foreach(Entity entity in battleOrder)
            {
                holder.Enqueue(entity);
            }
            return holder;            
        }
        void CombatEnded(Guild playerGuild)
        {
            foreach (Player player in playerGuild.GetPlayerlist())
            {
                player.SetXP(totalXPAmount / playerGuild.GetGuildSize());
                player.ResetEntity();
            }
            totalXPAmount = 0;
            gameManager.GameStateSwitch(GameManager.GameState.StoryState);
        }
        void GameOver()
        {
            Console.WriteLine("your entirer party is death poor you");
            Console.ReadLine();
        }
    }
}