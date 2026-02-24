using SocialCasino.SaveLoadService;
using SocialCasino.CasinoGame;


namespace SocialCasino.CasinoGame
{
    public class Casino : IGame
    {
        private readonly ISaveLoadService<string> _saveLoadService;
        private string _saveFileName;

        private readonly Blackjack _blackjack;
        private readonly DiceGame _diceGame;

        private PlayerProfile _playerProfile = new PlayerProfile();

        private int _currentBet;




        public Casino(ISaveLoadService<string> saveLoadService, Blackjack blackjack, DiceGame diceGame)
        {
            _saveLoadService = saveLoadService ?? throw new ArgumentNullException(nameof(saveLoadService));

            _blackjack = blackjack;
            _diceGame = diceGame;

            SubscribeToGameEvents(_blackjack);
            SubscribeToGameEvents(_diceGame);
        }

        private PlayerProfile LoadOrCreateProfile()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            _saveFileName = name.Trim() + ".txt";
            try
            {
                string data = _saveLoadService.LoadData(_saveFileName);
                return PlayerProfile.Deserialize(data);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Profile not found. Creating new profile...");
                var profile = new PlayerProfile();
                
                if (!string.IsNullOrWhiteSpace(name))
                {
                    profile.Name = name.Trim();
                    profile.Balance = 100;
                }
                _saveLoadService.SaveData(profile.Serialize(), _saveFileName);
                return profile;
            }
        }

        private void SaveProfile()
        {
            _saveLoadService.SaveData(_playerProfile.Serialize(), _saveFileName);
            Console.WriteLine("Profile was saved");
        }

        private int MakeBet()
        {
            while (true)
            {
                Console.Write($"Your balance: {_playerProfile.Balance}. Enter your bet: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int bet))
                {
                    if (bet > 0 && bet <= _playerProfile.Balance)
                    {
                        return bet;
                    }
                    else
                    {
                        Console.WriteLine("Invalid bet amount. Please enter a positive number that does not exceed your balance.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for your bet.");
                }
            }
        }

        private void SubscribeToGameEvents(CasinoGameBase game)
        {
            game.OnWin += HandleWin;
            game.OnLoose += HandleLoose;
            game.OnDraw += HandleDraw;
        }

        private void HandleWin()
        {
            int newBalance = _playerProfile.Balance + _currentBet;
            _playerProfile.Wins++;

            if (newBalance > PlayerProfile.MaxBalance)
            {
                int excess = newBalance - PlayerProfile.MaxBalance;
                _playerProfile.Balance = PlayerProfile.MaxBalance;

                Console.WriteLine($"You WIN! +{_currentBet}. Balance capped at {PlayerProfile.MaxBalance}.");
                Console.WriteLine($"Excess {excess}. You bankrupted the casino — they’ll build a new one here!");
            }
            else
            {
                _playerProfile.Balance = newBalance;
                Console.WriteLine($"You WIN! +{_currentBet}. New balance: {_playerProfile.Balance}");
            }
        }

        private void HandleLoose()
        {
            _playerProfile.Losses++;
            _playerProfile.Balance -= _currentBet;
            if (_playerProfile.Balance <= 0)
            {
                _playerProfile.Balance = 0;
                Console.WriteLine($"You LOSE! -{_currentBet}. Your balance is now zero. Game over!");
            }
            Console.WriteLine($"You LOSE! -{_currentBet}. New balance: {_playerProfile.Balance}");
        }

        private void HandleDraw()
        {
            _playerProfile.Draws++;
            Console.WriteLine("It's a DRAW! Your balance remains the same.");
        }


        public void StartGame()
        {
            Console.WriteLine("=== SOCIAL CASINO ===");
            _playerProfile = LoadOrCreateProfile();
            Console.WriteLine($"Hello, {_playerProfile.Name}!");
            Console.WriteLine($"Balance: {_playerProfile.Balance}\nStats: W={_playerProfile.Wins} L={_playerProfile.Losses} D={_playerProfile.Draws}");

            while(true)
            {
                if (_playerProfile.Balance <= 0)
                {
                    Console.WriteLine("You have no more balance to play. Please come back later!");
                    SaveProfile();
                    return;
                }
                Console.WriteLine();
                Console.WriteLine("Choose game:");
                Console.WriteLine("1 - Blackjack");
                Console.WriteLine("2 - Dice");
                Console.WriteLine("0 - Exit");
                CasinoGameBase selectedGame = null;

                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        selectedGame = _blackjack;
                        break;
                    case "2":
                        selectedGame = _diceGame;
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        SaveProfile();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                if (selectedGame == null)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }
                Console.WriteLine($"You chose {selectedGame.GetType().Name}. Starting game...");
                _currentBet = MakeBet();
                Console.WriteLine($"Computer bet is the same: {_currentBet}");

                selectedGame.PlayGame();
            }
        }
    }
}


