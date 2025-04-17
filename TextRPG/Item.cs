namespace TextRPG
{
    public enum ItemType
    {
        Attack,
        Defense
    }

    public class Item
    {
        public string name;
        public ItemType type;
        public float power;
        public int price;
        public int sellPrice;
        public string description;
        public bool isPurchased;
        public bool isEquipped;

        public Item(string Name, ItemType Type, float Power, int Price, string Description)
        {
            name = Name;
            type = Type;
            power = Power;
            price = Price;
            sellPrice = price * 85 / 100;
            description = Description;
            isPurchased = false;
            isEquipped = false;
        }

        public string showShopItem()
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

        public string showInventoryItem()
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

        public string showSellitem()
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
