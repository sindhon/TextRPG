namespace TextRPG
{
    public class StartDungeon
    {
        List<Dungeon> dungeons; // 입장 가능한 던전이 들어갈 리스트

        public StartDungeon()   // 던전 초기화
        {
            dungeons = new List<Dungeon>
            {
                new Dungeon("쉬운 던전", 5, 1000, 1),
                new Dungeon("일반 던전", 11, 1700, 5),
                new Dungeon("어려운 던전", 17, 2500, 10)
            };
        }

        public void showDungeon(Player player)  // 던전 선택 화면 표시
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

                for (int i = 0; i < dungeons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {dungeons[i].showDungeonType()}");
                }

                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                
                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input > 0 && input <= dungeons.Count)   // 입력받은 값이 유효한 인덱스의 던전일 경우
                    {
                        Dungeon dungeon = dungeons[input - 1];
                        showResult(player, dungeon);
                    }
                    else if (input == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }

        public void showResult(Player player, Dungeon dungeon)  // 던전 결과 표시
        {
            Random rand = new Random();

            bool isFail = false;
            int failPercent = rand.Next(0, 10);

            // 플레이어의 방어력이 권장 방어력보다 낮을 경우 40% 확률로 실패
            if (player.defense < dungeon.reqDef && failPercent < 4) 
            {
                isFail = true;
            }

            float currentHP = player.hp;

            // 피해량 계산
            int damageTaken = rand.Next(25, 36);
            float totalDamageTaken = damageTaken + (dungeon.reqDef - player.defense);
            player.hp -= totalDamageTaken;

            
            int currentGold = player.gold;
            int baseGold = dungeon.rewardGold;

            // 보상 골드 계산: 기본 보상 + 공격력 기반 보너스
            float power = player.attack;
            int bonus = rand.Next((int)power, (int)(power * 2) + 1);
            int bonusGold = baseGold * bonus / 100;
            int totalGold = baseGold + bonusGold;

            while (true)
            {
                if (isFail)
                {
                    Console.Clear();
                    Console.WriteLine("아쉬워요ㅠㅠ");
                    Console.WriteLine($"{dungeon.name}을 클리어하지 못했습니다.\n");

                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine($"체력 {currentHP} -> {player.hp}");
                    Console.WriteLine("Gold 변화없음.. ");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("축하합니다!!");
                    Console.WriteLine($"{dungeon.name}을 클리어 하였습니다.");

                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine($"체력 {currentHP} -> {player.hp}");
                    Console.WriteLine($"Gold {currentGold} G -> {player.gold} G ");
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 0:
                            // 던전 클리어시 골드 지급
                            if (!isFail)
                            {
                                player.gold += totalGold;
                                dungeon.giveExp(player);
                            }
                            return;
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
