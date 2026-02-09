using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            // task #2
            CheckEquipment();
            Console.WriteLine("----------");
            if (item is EquipItem equipItem)
            {
                if (_equipment.TryAdd(equipItem.Slot, equipItem))
                {
                    // Item was equipped
                    CheckEquipment();
                    return;
                }
                else
                {
                    Console.WriteLine($"You found {equipItem.Name}. Equipment slot {equipItem.Slot} is already taken. Replace the equipment? press 'y' for yes, any key for no");
                    if (Console.ReadLine() == "y")
                    {
                        var oldItem = _equipment[equipItem.Slot];
                        _equipment[equipItem.Slot] = equipItem;
                        // Item was replaced
                        CheckEquipment();
                        Console.WriteLine($"Equipment {oldItem.Name} was replaced to {equipItem.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"The equipment {_equipment[equipItem.Slot].Name} remains the same. The loot is dropped.");
                        CheckEquipment();
                        return;
                    }
                    return;
                }
                
            }
            Console.WriteLine("Here");
            CheckEquipment();
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
                //task #1
                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
                Console.WriteLine($"{Name} used HealthPotion. Currently healt  = {Health}");
            }
            //task #1
            if (economicItem is Grindstone grindstone)
            {
                Armour armour = GetEquipedArmour();
                armour.Repair(5);
                Console.WriteLine($"{armour.Name} repair 5 points. durability = {armour.Durability}");
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            //task #2
            var totalDefence = 0f;
            if (_equipment.TryGetValue(EquipSlot.Armour, out var itemArmour) && itemArmour is Armour armour) 
            {
                totalDefence += armour.Defence;
            }
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var itemHelmet) && itemHelmet is Helmet helmet)
            {
                totalDefence += helmet.Defence;
            }
            Console.WriteLine($"total defence = {totalDefence}");
            return damage -= (uint)(damage * (totalDefence / 100f));
        }

        // test

        public override void CheckEquipment()
        {
            foreach (var kvp in _equipment)
            {
                Console.WriteLine($"key = {kvp.Key} and value = {kvp.Value.Name}");
            }
        }

        // task #1

        public Armour GetEquipedArmour()
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                return armour;
            }
            return null;
        }




        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
