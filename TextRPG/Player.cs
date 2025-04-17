namespace TextRPG
{
    public class Player
    {
        public string name;
        public string job;
        public int level;
        public int exp;
        public float attack;
        public float defense;
        public float hp;
        public int gold;
        public List<Item> equipment;
        public Item? weapon;
        public Item? armor;

        public Player()
        {
            name = "Sin";
            job = "전사";
            level = 1;
            exp = 0;
            attack = 10f;
            defense = 5f;
            hp = 100f;
            gold = 1500;
            equipment = new List<Item>();
        }

        public void showStatus()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                Console.WriteLine($"Lv. {level:D2} (Exp {exp} / {level})");
                Console.WriteLine($"{name} ( {job} )");
                Console.WriteLine($"공격력 : {attack}");
                Console.WriteLine($"방어력 : {defense}");
                Console.WriteLine($"체력 : {hp}");
                Console.WriteLine($"Gold : {gold}");

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine()); // 사용자 입력 받기

                    switch (input)
                    {
                        case 0:
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자만 입력해주세요.");
                    Thread.Sleep(500);
                }

            }
        }

        public void showInventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("1. 장착 관리\n0. 나가기\n");

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
                            showEquipItem();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자만 입력해주세요.");
                    Thread.Sleep(500);
                }
            }
        }

        public void showEquipItem()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("[아이템 목록]\n");

                if (equipment.Count == 0)
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < equipment.Count; i++)
                    {
                        Console.WriteLine($"- {i + 1} {equipment[i].showInventoryItem()}");
                    }
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                
                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input > 0 && input <= equipment.Count)
                    {
                        Item item = equipment[input - 1];
                        if (item.isEquipped == false)
                        {
                            equipItem(item);
                            continue;
                        }
                        else
                        {
                            unequipItem(item);
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
                    Console.WriteLine("잘못된 입력입니다. 숫자만 입력해주세요.");
                    Thread.Sleep(500);
                }
            }
        }

        public void equipItem(Item item)
        {
            if (item.isEquipped)
                return;

            if (item.type == ItemType.Attack)
            {
                if (weapon != null)
                {
                    unequipItem(weapon);
                }
                weapon = item;
                attack += item.power;
            }
            else
            {
                if (armor != null)
                {
                    unequipItem(armor);
                }
                armor = item;
                defense += item.power;
            }
            item.isEquipped = true;
        }

        public void unequipItem(Item item)
        {
            if (item.type == ItemType.Attack)
            {
                attack -= item.power;
                weapon = null;
            }
            else
            {
                defense -= item.power;
                armor = null;
            }
            item.isEquipped = false;
        }

        public void levelUp()
        {
            level += 1;
            attack += 0.5f;
            defense += 1f;
        }

        public void rest()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("시작의 마을에 오신 여러분 환영합니다.");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {gold} G)");

                Console.WriteLine("\n1. 휴식하기\n0. 나가기\n");

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
                            if (hp >= 100)
                            {
                                Console.WriteLine("휴식할 필요가 없습니다.");
                                Thread.Sleep(500);
                                break;
                            }

                            if (gold >= 500)
                            {
                                gold -= 500;
                                hp = 100f;
                                Console.WriteLine("휴식을 완료했습니다.");
                                Thread.Sleep(500);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Gold가 부족합니다.");
                                Thread.Sleep(500);
                                break;
                            }
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자만 입력해주세요.");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
