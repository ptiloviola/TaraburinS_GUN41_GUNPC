namespace SocialCasino.SaveLoadService
{
    public sealed class PlayerProfile
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }

        public const int MaxBalance = 1000;

        public string Serialize()
        {
            return $"NAME: {Name}\nBALANCE: {Balance}\nWINS: {Wins}\nLOSSES: {Losses}\nDRAWS: {Draws}";
        }

        public static PlayerProfile Deserialize(string data)
        {
            var profile = new PlayerProfile();
            var lines = data.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    switch (key)
                    {
                        case "NAME":
                            profile.Name = value;
                            break;
                        case "BALANCE":
                            profile.Balance = int.Parse(value);
                            break;
                        case "WINS":
                            profile.Wins = int.Parse(value);
                            break;
                        case "LOSSES":
                            profile.Losses = int.Parse(value);
                            break;
                        case "DRAWS":
                            profile.Draws = int.Parse(value);
                            break;
                    }
                }
            }
            return profile;
        }


        public PlayerProfile()
        {

        }

        public PlayerProfile(string name, int balance) 
        {
            Name = name;
            Balance = balance;
            Wins = 0;
            Losses = 0;
            Draws = 0;
        }
    }

}

