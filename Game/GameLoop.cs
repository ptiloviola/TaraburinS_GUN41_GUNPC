using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;


namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");

            //task#3

            Console.WriteLine("Enter your name");
            var playerName = Console.ReadLine();

            Console.WriteLine(GetDifficultyModeString());
            
            while (_dungeon == null || _player == null)
            {
                if (Enum.TryParse<Difficulty>(Console.ReadLine(), out var difficulty))
                {
                    if (difficulty == Difficulty.Easy)
                    {
                        InitializeDifficultyMode(new UnitFactoryEasy().CreatePlayer(playerName), new DungeonBuilderEasy().BuildDungeon());
                        break;
                    }
                    else if (difficulty == Difficulty.Hard)
                    {
                        InitializeDifficultyMode(new UnitFactoryHard().CreatePlayer(playerName), new DungeonBuilderHard().BuildDungeon());
                        break;
                    }
                }
                Console.WriteLine(GetDifficultyModeString());
            }
            

        }

        private string GetDifficultyModeString() => $"Select difficulty mode. Type: {Difficulty.Easy} = {(int)Difficulty.Easy} or {Difficulty.Hard} = {(int)Difficulty.Hard}";

        private void InitializeDifficultyMode(Unit player, DungeonRoom dungeon)
        {
            _dungeon = dungeon;
            _player = player;
            Console.WriteLine($"Hello {_player.Name}");
            Player p = (Player)_player;
        }
        



        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    //task #3
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        if (currentRoom.Rooms.TryGetValue(direction, out var nextRoom))
                        {
                            currentRoom = nextRoom;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You can't go this way!");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                    DisplayRouteOptions(currentRoom);
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
