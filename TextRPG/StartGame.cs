namespace TextRPG
{
    internal class StartGame
    {
        static void Main(string[] args)
        {
            Game game = new Game();  // 게임 생성
            game.Start();   // 게임 시작
        }
    }
}