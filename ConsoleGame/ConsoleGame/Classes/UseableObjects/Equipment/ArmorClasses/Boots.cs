using ConsoleGame.Classes.ArmorClasses.SuperClasse;

namespace ConsoleGame.Classes.ArmorClasses
{
    class Boots :Armor
    {
        public Boots(string name, int lvlRequirment, int armorRating, int armorSlownes) : base(armorSlot: 3, name, lvlRequirment, armorRating, armorSlownes)
        {

        }
    }
}
