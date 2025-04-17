namespace TextRPG
{
    public class Shop
    {
        private List<Item> items;

        public Shop()
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

        public void showShop(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]");

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
                            buyItem(player);
                            break;
                        case 2:
                            sellitem(player);
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

        public void buyItem(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]");

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

                        if (player.gold >= item.price)
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

        public void sellitem(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine($"[보유 골드]\n{player.gold} G\n");
                Console.WriteLine("[아이템 목록]\n");

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

                    if (input > 0 && input <= player.equipment.Count)
                    {
                        Item item = player.equipment[input - 1];

                        player.gold += item.sellPrice;
                        item.isPurchased = false;

                        player.unequipItem(item);

                        player.equipment.Remove(item);

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
