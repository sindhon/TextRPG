namespace TextRPG
{
    public enum Action
    {
        Status = 1, // 1: 상태 보기
        Inventory,  // 2: 인벤토리 보기
        Shop,       // 3: 상점 이용
        Dungeon,    // 4: 던전 입장
        Rest        // 5: 휴식하기 
    }

    public class Game
    {
        private Player player;
        private Shop shop;
        private StartDungeon sDungeon;

        public Game()
        {
            player = new Player();  // 게임 시작 시 플레이어 생성
            shop = new Shop();      // 게임 시작 시 상점 생성
            sDungeon = new StartDungeon();  // 던전 생성
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
                            player.showStatus();    // 상태 보기
                            break;
                        case Action.Inventory:
                            player.showInventory(); // 인벤토리 보기
                            break;
                        case Action.Shop:
                            shop.showShop(player);  // 상점 열기
                            break;
                        case Action.Dungeon:
                            sDungeon.showDungeon(player);   // 던전 입장
                            break;  
                        case Action.Rest:
                            player.rest();      // 휴식하기
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                }
                catch (FormatException) // 입력이 숫자가 아닐 경우 예외 처리
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }


    }
}
