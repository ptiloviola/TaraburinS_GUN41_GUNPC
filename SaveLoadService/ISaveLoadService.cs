namespace SocialCasino.SaveLoadService
{
    public interface ISaveLoadService<T>
    {

        public void SaveData(T data, T fileName);

        public T LoadData(T fileName);

    }
}


