using ConsoleGame.Structures.Linkt;

namespace ConsoleGame
{
    class StoryManager
    {
        new LinkdList guildStory = new LinkdList();

        public void Story()
        {
            guildStory.head.PrintText();
            if (guildStory.head.nextNode != null)
                guildStory.head = guildStory.head.nextNode;
        }
        public void StoryGeneration(GameManager gameManager)
        {

            guildStory.head = new LinkdList.StoryNode("You are in a world full of goblins",
                 new LinkdList.StoryNode("You have gotten a quest to slay a cave full of goblins",
                 new LinkdList.DecisionNode("You have arived at the cave that houses those goblins",
                 new LinkdList.ChoiceNode[]
                 {
                     new LinkdList.ChoiceNode("Go inside", "You run inside and screaming: LEEROY JENKINS!!!!!", new LinkdList.BattleNode(4,"You see a group of goblins and battle commenses",
                     new LinkdList.StoryNode("you've defeated all the goblins",
                     new LinkdList.StoryNode("you go back to town",
                     new LinkdList.StoryNode("you enter the guild",
                     new LinkdList.Node("and that was your day"))))
                     ,gameManager)),
                     new LinkdList.ChoiceNode("Run away", "You run away like cowards",new LinkdList.Node("You have been fired by the guild for being useless"))
                 })));
        }
    }
}