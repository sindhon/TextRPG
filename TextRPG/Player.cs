namespace TextRPG
{
    public class Player
    {
        public string name;     // 플레이어 이름
        public string job;      // 직업
        public int level;       // 레벨
        public int exp;         //경험치
        public float attack;    // 공격력
        public float defense;   // 방어력
        public float hp;        // 체력
        public int gold;        // 보유 골드
        public List<Item> equipment;    // 보유 아이템
        public Item? weapon;    // 착용중인 무기
        public Item? armor;     // 착용중인 방어구

        public Player() // 플레이어 초기 상태
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

        public void showStatus()    // 플레이어 상태 출력
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
                    int input = int.Parse(Console.ReadLine());

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
                catch (FormatException) // 입력이 숫자가 아닐 경우 예외 처리
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자만 입력해주세요.");
                    Thread.Sleep(500);
                }

            }
        }

        public void showInventory() // 인벤토리 메뉴
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
                            showEquipItem();    // 아이템 장착
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

        public void showEquipItem() // 아이템 장착 화면
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
                            equipItem(item);    // 아이템 장착
                            continue;
                        }
                        else
                        {
                            unequipItem(item);  // 아이템 해제
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

        public void equipItem(Item item)    // 아이템 장착
        {
            if (item.isEquipped)
                return;

            if (item.type == ItemType.Attack)
            {
                if (weapon != null)
                {
                    unequipItem(weapon);    // 기존 무기 해제
                }
                weapon = item;
                attack += item.power;
            }
            else
            {
                if (armor != null)
                {
                    unequipItem(armor);     // 기존 방어구 해제
                }
                armor = item;
                defense += item.power;
            }
            item.isEquipped = true;
        }

        public void unequipItem(Item item)  // 아이템 해제
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

        public void levelUp()   // 레벨 업
        {
            level += 1;
            attack += 0.5f;
            defense += 1f;
        }

        public void rest()  // 휴식 화면
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
