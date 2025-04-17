namespace TextRPG
{
    public enum Action
    {
        Status = 1,
        Inventory,
        Shop,
        Dungeon,
        Rest
    }

    public class Game
    {
        private Player player;
        private Shop shop;
        private StartDungeon sDungeon;

        public Game()
        {
            player = new Player();
            shop = new Shop();
            sDungeon = new StartDungeon();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    Action action = (Action)input;

                    switch (action)
                    {
                        case Action.Status:
                            player.showStatus();
                            break;
                        case Action.Inventory:
                            player.showInventory();
                            break;
                        case Action.Shop:
                            shop.showShop(player);
                            break;
                        case Action.Dungeon:
                            sDungeon.showDungeon(player);
                            break;
                        case Action.Rest:
                            player.rest();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }


    }
}
