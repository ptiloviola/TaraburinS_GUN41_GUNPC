using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            // test
            //var lootEquip = new DungeonRoom("Loot2", new Armour(3, 3, "Old shirt"));
            var lootEquip = new DungeonRoom("Loot2", new Helmet(7, 5, "Old Helmet"));
            var monsterRoom2 = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());

            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            // test
            enter.TrySetDirection(Direction.Left, lootEquip);

            //lootEquip.TrySetDirection(Direction.Forward, lootRoom);
            //lootEquip.TrySetDirection(Direction.Left, monsterRoom2);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, lootStoneRoom);

            lootEquip.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, monsterRoom2);

            lootStoneRoom.TrySetDirection(Direction.Forward, monsterRoom2);

            monsterRoom2.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
