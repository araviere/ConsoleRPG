using ConsoleGame.Classes.ArmorClasses.SuperClasse;
using ConsoleGame.Classes.GuildClasses;
using ConsoleGame.Classes.UseableObjects.Equipment;
using ConsoleGame.Classes.WeaponClasses.SuperClasse;
using ConsoleGame.SuperKlasse.BeingClasses;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    class InventoryMenu
    {
        public void OpenInventory(Guild guild, GameManager gm)
        {

            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine("Witch Itembag do you want to open?");
            Console.WriteLine("[1] Weaponbag");
            Console.WriteLine("[2] Armorbag");
            Console.WriteLine("[3] No bag lets go on with the jurney");
            switch (Console.ReadLine())
            {
                case "1": BagInventory(guild.GetWeaponBag()); break;
                case "2": BagInventory(guild.GetArmorBack()); break;
                case "3": gm.GameStateSwitch(GameManager.GameState.StoryState); break;
                default: Console.WriteLine("that's not a option"); break;
            }

            void BagInventory(List<Equipment> list)
            {
                Console.WriteLine("_____________________________________________________________________________");
                for (int counter = 0; counter < list.Count;)
                {
                    Console.WriteLine("[" + (counter + 1) + "] " + list[counter].WrithDiscription());
                    counter++;
                }
                Console.WriteLine("[" + (list.Count+1) + "] go back");
                Console.WriteLine("What armor do you want to equip?");
                try
                {
                    switch (int.Parse(Console.ReadLine()) - 1)
                    {
                        case int n when (n < list.Count && list[n].GetType().BaseType.Name == "Armor"): EquipArmorOnWho((Armor)list[n]); break;
                        case int n when (n < list.Count && list[n].GetType().Name == "Weapon"): EquipWeaponOnWho((Weapon)list[n]); break;
                        case int n when (n == list.Count):OpenInventory(guild, gm); break;
                        default: Console.WriteLine("that's not a armor set"); BagInventory(list); break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("that's not a armor set"); BagInventory(list);
                }
                catch (FormatException)
                {
                    Console.WriteLine("that's not a armor set"); BagInventory(list);
                }

                void EquipArmorOnWho(Armor armor)
                {
                    Console.WriteLine("_____________________________________________________________________________");
                    for (int counter = 0; counter < guild.GetPlayerlist().Length;)
                    {
                        Console.WriteLine();
                        Console.WriteLine("[" + (counter + 1) + "] " + guild.GetPlayerlist()[counter].GetName());
                        Console.WriteLine(guild.GetPlayerlist()[counter].GetArmor()[armor.GetArmorSlot()].WrithDiscription());
                        Console.WriteLine();
                        counter++;
                    }
                    Console.WriteLine("[" + (guild.GetPlayerlist().Length+1) + "]  I've changed my mind and don't want to do it");
                    Console.WriteLine("On who do you want to eguip this?");
                    Console.WriteLine(armor.WrithDiscription());
                    try
                    {
                        switch (int.Parse(Console.ReadLine()) - 1)
                        {
                            case int n when (n < guild.GetPlayerlist().Length && n >= 0):
                                EquipArmor(guild.GetPlayerlist()[n], armor); break;
                            case int n when (n == guild.GetPlayerlist().Length): guild.AddToArmorBack(armor); break;
                            default: Console.WriteLine("no player found"); EquipArmorOnWho(armor); break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("no player found"); EquipArmorOnWho(armor);
                    }
                    void EquipArmor(Player player, Armor armor)
                    {
                        Console.WriteLine("_____________________________________________________________________________");
                        Console.WriteLine("Do You want to equipt " + armor.WrithDiscription());
                        Console.WriteLine("In the place of " + player.GetArmor()[armor.GetArmorSlot()].WrithDiscription());
                        Console.WriteLine("Yes");
                        Console.WriteLine("No");
                        switch (Console.ReadLine().ToLower())
                        {
                            case "yes": armor.EquipEquipmentOnPlayer(player); break;
                            case "no": guild.AddToArmorBack(armor); break;
                            default: Console.WriteLine("That's not a answer"); EquipArmor(player, armor); break;
                        }
                    }
                }
                void EquipWeaponOnWho(Weapon weapon)
                {
                    Console.WriteLine("_____________________________________________________________________________");
                    for (int counter = 0; counter < guild.GetPlayerlist().Length;)
                    {
                        Console.WriteLine();
                        Console.WriteLine("[" + (counter + 1) + "] " + guild.GetPlayerlist()[counter].GetName());
                        Console.WriteLine(guild.GetPlayerlist()[counter].GetWeapon().WrithDiscription());
                        Console.WriteLine();
                        counter++;
                    }
                    Console.WriteLine("[" + (guild.GetPlayerlist().Length+1) + "]  I've changed my mind and don't want to do it");
                    Console.WriteLine("On who do you want to equip this?");
                    Console.WriteLine(weapon.WrithDiscription());
                    try
                    {
                        switch (int.Parse(Console.ReadLine()) - 1)
                        {
                            case int n when (n < guild.GetPlayerlist().Length && n >= 0):
                                EquipArmor(guild.GetPlayerlist()[n], weapon); break;
                            case int n when (n == guild.GetPlayerlist().Length): guild.AddToWeaponBack(weapon);OpenInventory(guild, gm); break;
                            default: Console.WriteLine("no player found"); EquipWeaponOnWho(weapon); break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("no player found"); EquipWeaponOnWho(weapon);
                    }
                    void EquipArmor(Player player, Weapon weapon)
                    {
                        Console.WriteLine("_____________________________________________________________________________");
                        Console.WriteLine("Do You want to equipt " + weapon.WrithDiscription());
                        Console.WriteLine("In the place of " + player.GetWeapon().WrithDiscription());
                        Console.WriteLine("[1] Yes");
                        Console.WriteLine("[2] No");
                        switch (Console.ReadLine())
                        {
                            case "1": weapon.EquipEquipmentOnPlayer(player); break;
                            case "2": guild.AddToWeaponBack(weapon); OpenInventory(guild, gm); break;
                            default: Console.WriteLine("That's not a answer"); EquipArmor(player, weapon); break;
                        }
                    }
                }
            }
        }        
    }
}
