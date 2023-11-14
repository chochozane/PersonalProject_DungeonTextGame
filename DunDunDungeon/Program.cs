namespace DunDunDungeon
{

    internal partial class Program
    {

        static Character player1;
        static Item[] _items;


        static void Main(string[] args)
        {
            GameDataSetting();
            ShowGameStartScene();
            ShowSpartaVill();
        }

        static void GameDataSetting()
        {
            // 캐릭터 설정
            player1 = new Character("너의이름은", 01, "전사", 10, 5, 100, 1500);

            // 아이템 설명
            _items = new Item[10];
            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 5, 0));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 1, 2, 0, 0));
            AddItem(new Item("엄마의 후라이팬", "꽤나 강력하고 뜨거운 후라이팬입니다.", 1, 5, 0, 0));
        }

        // Item 배열에 아이템을 추가하기 위해 만든 함수
        static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10)
            {
                return; // 아이템이 꽉 차는 경우, 아무일도 일어나지 않는다 !
            }
            _items[Item.ItemCnt] = item;
            Item.ItemCnt++;
        }


        // 게임 시작 화면
        static void ShowGameStartScene()
        {
            Console.WriteLine("■■■■■■■■■■");
            Console.WriteLine("Sparta DunDunDungeon");
            Console.WriteLine("■■■■■■■■■■");
            Console.WriteLine("\n");
            Console.WriteLine("Press Any Key to Start !");
            Console.ReadKey();
        }


        // 스파르타 마을
        static void ShowSpartaVill()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();

            switch (CheckValidInput(1, 2))
            {
                case 1:
                    ShowStatus(); // 상태 보기
                    break;
                case 2:
                    ShowInvent(); // 인벤토리
                    break;
            }
        }

        static int CheckValidInput(int min, int max)
        {
            int keyInput; // TryParse 에서 사용
            bool result; // while 문에서 사용

            do
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.(숫자만 입력해주세요!)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(">> ");
                Console.ResetColor();
                result = int.TryParse(Console.ReadLine(), out keyInput); // TryParse 는 될 수도 있고 안 될 수도 있고를 생각하는 것. 여기서는 숫자일 수도 아닐 수도 있다는걸 생각한다는 의미. ReadLine 을 한 다음에 그게 맞다면 가져오고(keyInput 으로 !), 아니면 안 가져오고 !)
            }
            while (result == false || CheckIfValid(keyInput, min, max) == false); // false 면 계속 반복을 돈다 ~

            // 여기에 도착했다는 것은 값을 제대로 잘 입력했다는 것 ! :-)
            return keyInput;
        }

        private static bool CheckIfValid(int checkable, int min, int max)
        {
            if (min <= checkable && checkable <= max)
            {
                return true;
            }
            return false;
        }


        // 상태 보기
        private static void ShowStatus()
        {
            Console.Clear();

            ShowHighlightedText("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다");
            Console.WriteLine();
            Console.WriteLine($"{player1.name} ({player1.job})");

            PrintTextWithHighlights("Lv. ", player1.level.ToString("00"));
            int bonusAtk = getSumBonusAtk();
            PrintTextWithHighlights("공격력 : ", (player1.atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format(" (+{0})", bonusAtk) :"");
            int bonusDef = getSumBonusDef();
            PrintTextWithHighlights("방어력 : ", (player1.def + bonusDef).ToString(), bonusDef > 0 ? string.Format(" (+{0})", bonusDef) : "");
            int bonusHp = getSumBonusHp();
            PrintTextWithHighlights("체력 : ", (player1.hp + bonusHp).ToString(), bonusHp > 0 ? string.Format(" (+{0})", bonusHp) : "");
            PrintTextWithHighlights("골드 : ", player1.gold.ToString(), " G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            switch(CheckValidInput(0, 0))
            {
                case 0:
                    ShowSpartaVill();
                    break;
            }
        }

        private static int getSumBonusAtk() // 장착되어있다면 능력치 합쳐주는 역할 !
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped)
                {
                    sum += _items[i].Atk;
                }
            }
            return sum;
        }
        private static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped)
                {
                    sum += _items[i].Def;
                }
            }
            return sum;
        }
        private static int getSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped)
                {
                    sum += _items[i].Hp;
                }
            }
            return sum;
        }


        private static void ShowHighlightedText(string text) // 꾸미기 담당 함수
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PrintTextWithHighlights(string s1, string s2, string s3 = "") // string s3 는 값이 비어도 되게끔 빈칸을 하나 넣었다 생각하면 됩니다 ~ :-)
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }


        // 인벤토리
        static void ShowInvent()
        {
            Console.Clear();

            ShowHighlightedText("인벤토리");
            Console.WriteLine("보유 중인 아이템입니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i =0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription();
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine();

            switch (CheckValidInput(0, 1))
            {
                case 0:
                    ShowSpartaVill();
                    break;
                case 1:
                    ShowEquipSetting();
                    break;
            }
        }


        // 장착 관리
        static void ShowEquipSetting()
        {
            Console.Clear();

            ShowHighlightedText("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription(true, i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int keyInput = CheckValidInput(0, Item.ItemCnt);

            switch (keyInput)
            {
                case 0:
                    ShowInvent();
                    break;
                default:
                    ToggleEquipStatus(keyInput - 1); // 유저가 입력하는 값은 1, 2, 3, .. 실제 배열 인덱스는 0, 1, 2, ...
                    ShowEquipSetting();
                    break;
            }
        }

        private static void ToggleEquipStatus(int idx)
        {
            _items[idx].IsEquipped = !_items[idx].IsEquipped;
        }

       
    }
}
