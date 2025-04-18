namespace TextRPG
{
    public class Dungeon
    {
        public string name;     // 던전 이름
        public float reqDef;    // 권장 방어력
        public int rewardGold;  // 보상 골드
        public int rewardExp;   // 보상 경험치

        public Dungeon(string Name, int Def, int Gold, int Exp) // 던전의 정보를 받아 초기화
        {
            name = Name;
            reqDef = Def;
            rewardGold = Gold;
            rewardExp = Exp;
        }

        public void giveExp(Player player) // 경험치 지급 및 레벨 업
        {
            player.exp += rewardExp;
            Console.WriteLine("경험치를 얻었습니다.");

            // 경험치가 현재 레벨보다 많다면 레벨업 반복
            while (player.exp >= player.level)
            {
                player.exp -= player.level;
                player.levelUp();
                Console.WriteLine("레벨 업!!");
            }
            Thread.Sleep(500);
        }

        public string showDungeonType() // 던전 정보 표시
        {
            return $"{name} | 방어력 {reqDef} 이상 권장 | 획득 경험치 {rewardExp}";
        }
    }
}
