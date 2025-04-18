namespace TextRPG
{
    public class Shop
    {
        private List<Item> items;   // 판매할 아이템이 들어갈 리스트

        public Shop()   // 상점에서 판매할 아이템 초기화
        {
            items = new List<Item>
            {
                new Item("수련자 갑옷", ItemType.Defense, 5f, 1000, "수련에 도움을 주는 갑옷입니다."),
                new Item("무쇠갑옷", ItemType.Defense, 9f, 1500, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Item("스파르타의 갑옷", ItemType.Defense, 15f, 3500, "스파르타 전사들이 사용한 전설의 갑옷입니다."),
                new Item("낡은 검", ItemType.Attack, 2f, 600, "쉽게 볼 수 있는 낡은 검입니다."),
                new Item("청동 도끼", ItemType.Attack, 5f, 1500, "어디선가 사용됐던 도끼입니다."),
                new Item("스파르타의 창", ItemType.Attack, 7f, 2000, "스파르타 전사들이 사용한 전설의 창입니다."),
            };
        }

        public void showShop(Player player) // 상점 화면
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]");

                // 아이템 목록 출력
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"- {items[i].showShopItem()}");
                }

                Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 0:
                            return;
                        case 1:
                            buyItem(player);    // 아이템 구매
                            break;
                        case 2:
                            sellitem(player);   // 아이템 판매
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

        public void buyItem(Player player)  // 아이템 구매 화면
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]");

                // 번호가 추가된 목록 출력
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"- {i + 1} {items[i].showShopItem()}");
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input > 0 && input <= items.Count)
                    {
                        Item item = items[input - 1];
                        if (item.isPurchased == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Thread.Sleep(500);
                            continue;
                        }

                        if (player.gold >= item.price)  // 골드가 충분할 경우
                        {
                            player.gold -= item.price;
                            item.isPurchased = true;
                            player.equipment.Add(item);
                            Console.WriteLine("구매를 완료했습니다.");
                            Thread.Sleep(500);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            Thread.Sleep(500);
                            continue;
                        }
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

        public void sellitem(Player player)     // 아이템 판매 화면
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]\n");

                // 판매할 아이템 목록 출력
                if (player.equipment.Count != 0)
                {
                    for (int i = 0; i < player.equipment.Count; i++)
                    {
                        Console.WriteLine($"- {i + 1} {player.equipment[i].showSellitem()}");
                    }
                }
                else
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input > 0 && input <= player.equipment.Count) // 입력받은 값이 유효한 인덱스의 아이템일 경우
                    {
                        Item item = player.equipment[input - 1];

                        player.gold += item.sellPrice;  // 판매 금액만큼 골드 획득
                        item.isPurchased = false;       // 구매 상태 해제(상점에서 다시 구매 가능)
                                
                        player.unequipItem(item);       // 장착된 아이템이라면 해제

                        player.equipment.Remove(item);  // 장비 목록에서 제거

                        Console.WriteLine("아이템을 판매했습니다.");
                        Thread.Sleep(500);
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

    }
}
