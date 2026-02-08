using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class EquipItem : Item
    {
        private uint _durability;
        private uint _maxDurability;
        public uint Durability { get => _durability; protected set => _durability = value; }
        public override bool Stackable => false;

        public abstract EquipSlot Slot { get; }

        protected EquipItem(uint maxDurability, string name) : base(name)
        {
            _maxDurability = maxDurability;
            _durability = _maxDurability;
        }

        //public void ReduceDurability(uint delta) => _durability -= delta;

        //task#1
        public void ReduceDurability(uint delta)
        {
            if (_durability >= 2)
            {
                _durability = _durability - delta;
            }
            else
            {
                Console.WriteLine($"EquipItem {Name} is broken");
            }
            
        }

        public void Repair(uint delta)
        {
            _durability += delta;

            if (_durability > _maxDurability)
            {
                _durability = _maxDurability;
            }
        }
    }
}
