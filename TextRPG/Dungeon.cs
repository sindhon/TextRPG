namespace TextRPG
{
    public class Dungeon
    {
        public string name;
        public float reqDef;
        public int rewardGold;
        public int rewardExp;

        public Dungeon(string Name, int Def, int Gold, int Exp)
        {
            name = Name;
            reqDef = Def;
            rewardGold = Gold;
            rewardExp = Exp;
        }

        public void giveExp(Player player)
        {
            player.exp += rewardExp;
            Console.WriteLine("경험치를 얻었습니다.");
            while (player.exp >= player.level)
            {
                player.exp -= player.level;
                player.levelUp();
                Console.WriteLine("레벨 업!!");
            }
            Thread.Sleep(500);
        }

        public string showDungeonType()
        {
            return $"{name} | 방어력 {reqDef} 이상 권장 | 획득 경험치 {rewardExp}";
        }
    }
}
