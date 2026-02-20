namespace SocialCasino.CasinoGame
{
    public abstract class CasinoGameBase
    {
        public abstract void PlayGame();

        public event Action OnWin;

        public event Action OnLoose;

        public event Action OnDraw;

        protected void OnWinInvoke()
        {
            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke();
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }

        protected abstract void FactoryMethod();

        public CasinoGameBase()
        {
            FactoryMethod();

            OnWin += () => Console.WriteLine("Результат: WIN");
            OnLoose += () => Console.WriteLine("Результат: LOOSE");
            OnDraw += () => Console.WriteLine("Результат: DRAW");
        }
    }

}

