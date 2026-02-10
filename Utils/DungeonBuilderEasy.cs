using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public class DungeonBuilderEasy: DungeonBuilder
    {
        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");

            var unitFactory = new UnitFactoryEasy();

            var monsterRoom = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var lootEquip = new DungeonRoom("Loot2", new RangeWeapon(8, 10, "Old Bow"));
            var lootEquip2 = new DungeonRoom("Loot3", new RangeWeapon(12, 15, "New Bow"));
            var monsterRoom2 = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, lootEquip);
            lootEquip.TrySetDirection(Direction.Forward, monsterRoom);
            monsterRoom.TrySetDirection(Direction.Forward, lootEquip2);
            monsterRoom.TrySetDirection(Direction.Left, lootStoneRoom);
            lootEquip2.TrySetDirection(Direction.Forward, monsterRoom2);
            lootStoneRoom.TrySetDirection(Direction.Forward, monsterRoom2);
            monsterRoom2.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
