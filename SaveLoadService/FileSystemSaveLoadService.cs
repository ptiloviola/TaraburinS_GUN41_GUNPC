namespace SocialCasino.SaveLoadService
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {

        private readonly string _directoryPath;

        public FileSystemSaveLoadService(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException("Directory path cannot be null or whitespace.", nameof(directoryPath));
            }
            _directoryPath = directoryPath;
        }

        public void SaveData(string data, string fileName)
        {
            CreateDirectoryIfNotExists();
            string filePath = BuildFilePath(fileName);
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.Write(data);
            }
        }

        public string LoadData(string fileName)
        {
            CreateDirectoryIfNotExists();

            string filePath = BuildFilePath(fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");
            }

            using (StreamReader reader = File.OpenText(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Console.WriteLine($"Directory '{_directoryPath}' does not exist. Creating it...");
                Directory.CreateDirectory(_directoryPath);
            }
        }

        private string BuildFilePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or whitespace.", nameof(fileName));
            }

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                if (fileName.Contains(invalidChar))
                {
                    throw new ArgumentException($"File name cannot contain invalid character: {invalidChar}", nameof(fileName));
                }
                //id = id.Replace(c, '_');
            }

            fileName = Path.GetFileName(fileName);

            return Path.Combine(_directoryPath, fileName);

        }
    }
}


