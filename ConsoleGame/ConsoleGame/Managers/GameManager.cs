using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.Classes.BeingClasses;
using ConsoleGame.Classes;
using System;
using ConsoleGame.Classes.ArmorClasses;

namespace ConsoleGame
{    
    class GameManager
    {
        Guild playerGuild = new Guild();
        int encountersize;
        GameState gameState = GameState.StoryState;

        public enum GameState
        {
            BattleState,
            StoryState,
            InventoryState
        }
        public void SetEncounterSize(int i) { encountersize = i; }
        public int GetEncounterSize() { return encountersize; }

        public void GameStateSwitch(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void Start()
        {
            CharacterCreation createCharacter = new CharacterCreation();
            for (int repeater = 0; repeater < playerGuild.GetGuildSize(); repeater++)
            {
                playerGuild.SetPlayerGuildMember(createCharacter.PlayerCharacterCreation(), repeater);
                playerGuild.GetPlayerGuildMember(repeater).SetPlayerGuild(playerGuild);
            }
            playerGuild.ShowParty();

            playerGuild.AddToArmorBack(new HeadGear("DebugEquipment", 1, 1, 1));
        }
        public void RunGame()
        {
            StoryManager storyManager = new StoryManager();
            storyManager.StoryGeneration(this);
            CombatManager combatManager = new CombatManager();
            while (69 != 420)
            {
                if(Console.ReadLine().ToLower() == "open bag")
                {
                    GameStateSwitch(GameManager.GameState.InventoryState);
                }
                switch (gameState)
                {
                    case GameState.BattleState: combatManager.CombatManagment(playerGuild,this); break;
                    case GameState.StoryState: storyManager.Story();break;
                    case GameState.InventoryState: new InventoryMenu().OpenInventory(playerGuild,this); break;
                }
            }
        }
    }
}
