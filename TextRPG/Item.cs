namespace TextRPG
{
    public enum ItemType    // 아이템 종류 구분
    {
        Attack, // 공격력 관련
        Defense // 방어력 관련
    }

    public class Item
    {
        public string name;     // 아이템 이름
        public ItemType type;   // 아이템 종류
        public float power;     // 능력치(공격력/방어력)
        public int price;       // 구매 가격
        public int sellPrice;   // 판매 가격
        public string description;  // 아이템 설명
        public bool isPurchased;    // 구매 여부
        public bool isEquipped;     // 장착 여부

        public Item(string Name, ItemType Type, float Power, int Price, string Description) // 아이템 정보를 받아 초기화
        {
            name = Name;
            type = Type;
            power = Power;
            price = Price;
            sellPrice = price * 85 / 100;   // 판매 가격 == 구매 가격의 85%
            description = Description;
            isPurchased = false;
            isEquipped = false;
        }

        public string showShopItem()    // 상점 아이템 정보 표시
        {
            string statType;
            string status;

            if (type == ItemType.Attack)
            {
                statType = "공격력";
            }
            else
            {
                statType = "방어력";
            }

            if (isPurchased)
            {
                status = "구매완료";
            }
            else
            {
                status = $"{price} G";
            }
            return $"{name} | {statType} +{power} | {description} | {status}";
        }

        public string showInventoryItem()   // 인벤토리 아이템 정보 표시
        {
            string statType;
            string status;

            if (type == ItemType.Attack)
            {
                statType = "공격력";
            }
            else
            {
                statType = "방어력";
            }

            if (isEquipped)
            {
                status = "[E]";
            }
            else
            {
                status = "";
            }
            return $"{status}{name} | {statType} +{power} | {description}";
        }

        public string showSellitem()    // 판매 아이템 정보 표시
        {
            string statType;

            if (type == ItemType.Attack)
            {
                statType = "공격력";
            }
            else
            {
                statType = "방어력";
            }

            return $"{name} | {statType} +{power} | {description} | {sellPrice}";
        }
    }
}
