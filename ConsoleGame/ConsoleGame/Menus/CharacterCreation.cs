using ConsoleGame.Classes.BeingClasses.PlayerClasses;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;

namespace ConsoleGame.Classes
{
    class CharacterCreation
    {
        public Player PlayerCharacterCreation()
        {
            Console.WriteLine();
            return ChoiceOfClass(NameQuestion());
        }
        string NameQuestion()
        {
            Console.WriteLine("what's your name adventurer");
            string name = Console.ReadLine();
            if (name != null && !name.Contains(" ") && name != "")
            {
                if (name.Contains("_"))
                {
                    string[] nameChar = name.Split("_");
                    name = "";
                    foreach(string segment in nameChar)
                    {
                        switch (name)
                        {
                            case "": name += segment; break;
                            default: name += " " + segment; break;
                        }
                    }
                    if (name == "") { Console.WriteLine("can't be blank"); NameQuestion(); }
                }
                return NameAreYouSureQuestion(name);
            }
            else { Console.WriteLine("can't be blank or contain a space, if your name wants to contain a space use _ instead"); return NameQuestion(); }

            string NameAreYouSureQuestion(string name)
            {
                Console.WriteLine("_____________________________________________________________________________");
                Console.WriteLine("your name: " + name);
                Console.WriteLine("are you sure that that is your name");
                switch (Console.ReadLine().ToLower())
                {
                    case string s when (s.Contains("yes")): return name;
                    case string s when (s.Contains("no")): return NameQuestion();
                    default: return NameAreYouSureQuestion(name);
                }

            }
        }
        Player ChoiceOfClass(string name)
        {
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("what class are you adventurer");
            Console.WriteLine();
            Console.WriteLine("Knight");
            Console.WriteLine("Archer");
            Console.WriteLine("Sorcerer");

            
            return (ClassSelection(name, Console.ReadLine()));
        }
        Player ClassSelection(string name, string number)
        {
            switch (number.ToLower())
            {
                case string s when (s.Contains("knight")): return AreYouSureQuestion(new Knight(name), number);
                case string s when (s.Contains("archer")): return AreYouSureQuestion(new Archer(name), number);
                case string s when (s.Contains("sorcerer")): return AreYouSureQuestion(new Sorcerer(name), number);
                default: Console.WriteLine("that's not a class adventurer choose another one"); return ChoiceOfClass(name);
            }
        }
        Player AreYouSureQuestion(Player player, string number)
        {
            player.WrithDiscription();
            Console.WriteLine();
            Console.WriteLine("do you want to change name or class");
            Console.WriteLine("I want to change the name");
            Console.WriteLine("I want to change my class");
            Console.WriteLine("I'm done");

            switch (Console.ReadLine().ToLower())
            {
                case string s when (s.Contains("name")): return ClassSelection(NameQuestion(), number);
                case string s when (s.Contains("class")): return ChoiceOfClass(player.GetName());
                case string s when (s.Contains("done")):
                    return player;
                default: return AreYouSureQuestion(player, number);
            }
        }
    }
}
