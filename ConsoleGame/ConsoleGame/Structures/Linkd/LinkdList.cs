using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Structures.Linkt
{
    class LinkdList
    {
        public Node head;
        public class Node
        {
            public string data;
            public Node nextNode;
            public Node(string data)
            {
                this.data = data;
            }
            public virtual void PrintText()
            {
                Console.WriteLine(data);                
            }
        }
        public class StoryNode : Node
        {
            public StoryNode(string data, Node node) : base(data)
            {
                nextNode = node;
            }
            public override void PrintText()
            {
                base.PrintText();
            }
        }  
        public class DecisionNode : Node
        {
            List<ChoiceNode> decisionList;
            public DecisionNode(string data, ChoiceNode[] decisionList) : base(data)
            {
                this.decisionList = decisionList.ToList();
            }
            public override void PrintText()
            {
                Console.WriteLine("_____________________________________________________________________________");
                base.PrintText();
                foreach (ChoiceNode node in decisionList)
                {
                    Console.WriteLine(node.GetChoice());
                }
                string choice = Console.ReadLine().ToLower();
                try
                {
                    if (decisionList.Exists(X => X.GetChoice().ToLower().Contains(choice)))
                    { 
                        decisionList.Find(X => X.GetChoice().ToLower().Contains(choice)).PrintText();
                    nextNode = decisionList.Find(X => X.GetChoice().ToLower().Contains(choice)).nextNode;
                    }
                    else
                    {
                        Console.WriteLine("That's not a option");
                        PrintText();
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("That's not a option");
                    PrintText();
                }
            }
        }
        public class ChoiceNode : StoryNode
        {
            string choice;
            public ChoiceNode(string choice, string data, Node node) : base(data, node)
            {
                this.choice = choice;
            }
            public string GetChoice() { return choice; }
        }

        public class BattleNode : Node
        {
            GameManager gameManager;
            int battleSize;
            public BattleNode(int size, string data,Node node,GameManager gameManager) : base(data)
            {
                this.gameManager = gameManager;
                nextNode = node;
                battleSize = size;                
            }
            public override void PrintText()
            {
                gameManager.SetEncounterSize(battleSize);
                base.PrintText();
                gameManager.GameStateSwitch(GameManager.GameState.BattleState);
            }
        }
    }
}