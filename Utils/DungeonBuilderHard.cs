using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public class DungeonBuilderHard: DungeonBuilder
    {
        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");

            var unitFactory = new UnitFactoryHard();

            var monsterRoom = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());




            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var lootEquip = new DungeonRoom("Loot2", new Helmet(5, 5, "Old Helmet"));
            var lootEquip2 = new DungeonRoom("Loot3", new RangeWeapon(12, 15, "New Bow"));
            var monsterRoom2 = new DungeonRoom("Monster2", unitFactory.CreateGoblinEnemy());

            var lootEquip3 = new DungeonRoom("Loot4", new Helmet(9, 9, "New Helmet"));

            var monsterRoom3 = new DungeonRoom("Monster3", unitFactory.CreateGoblinEnemy());

            var lootRoom2 = new DungeonRoom("Loot4", new Gold());

            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, emptyRoom);
            enter.TrySetDirection(Direction.Forward, monsterRoom);
            enter.TrySetDirection(Direction.Left, lootRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootEquip2);
            monsterRoom.TrySetDirection(Direction.Left, lootEquip);
            lootRoom.TrySetDirection(Direction.Forward, lootEquip2);

            lootEquip.TrySetDirection(Direction.Forward, monsterRoom2);
            lootEquip2.TrySetDirection(Direction.Forward, monsterRoom2);

            monsterRoom2.TrySetDirection(Direction.Left, lootStoneRoom);
            lootStoneRoom.TrySetDirection(Direction.Left, lootEquip3);


            lootStoneRoom.TrySetDirection(Direction.Forward, monsterRoom3);
            lootEquip3.TrySetDirection(Direction.Forward, monsterRoom3);
            monsterRoom3.TrySetDirection(Direction.Forward, lootRoom2);
            lootRoom2.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
