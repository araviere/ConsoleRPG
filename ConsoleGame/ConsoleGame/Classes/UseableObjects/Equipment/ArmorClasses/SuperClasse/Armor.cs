using ConsoleGame.Classes.UseableObjects.Equipment;
using ConsoleGame.SuperKlasse.BeingClasses;

namespace ConsoleGame.Classes.ArmorClasses.SuperClasse
{
    class Armor : Equipment
    {
        protected int armorSlot;
        protected int lvlRequirment;
        protected int armorRating;
        protected int armorSlownes;

        public Armor(int armorSlot,string name, int lvlRequirment, int armorRating, int armorSlownes) : base(name)
        {
            this.armorSlot = armorSlot;
            this.lvlRequirment = lvlRequirment;
            this.armorRating = armorRating;
            this.armorSlownes = armorSlownes;
        }
        public int GetArmorSlot() { return armorSlot; }
        public int GetLVLRequirment() { return lvlRequirment; }
        public int GetArmorRating() { return armorRating; }
        public int GetArmorSlowness() { return armorSlownes; }

        public override string WrithDiscription()
        {
            return "type: " + this.GetType().Name + " name: " + name + " armorrating: " + armorRating + " armorslownes: " + armorSlownes;
        }
        public override void EquipEquipmentOnPlayer(Player player)
        {
            player.ArmorEquip(this);
        }
    }
}
