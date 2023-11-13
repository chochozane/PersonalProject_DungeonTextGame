
using ConsoleTables;

namespace DunDunDungeon
{

    internal partial class Program
    {

        private static Character player1;
        private static Item muIronArmor;
        private static Item oldSword;


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
            muIronArmor = new Item("무쇠갑옷", "방어력 +5", "무쇠로 만들어져 튼튼한 갑옷입니다.");
            oldSword = new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검입니다.");
        }


        // 게임 시작 화면
        static void ShowGameStartScene()
        {
            Console.WriteLine("DunDunDungeon");
            Console.WriteLine("\n");
            Console.WriteLine("Press Enter to Start !");
            Console.ReadLine();
        }


        // 스파르타 마을
        static void ShowSpartaVill()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.(숫자만 입력해주세요!)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            Console.ResetColor();
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    ShowStatus(); // 상태 보기
                    break;

                case 2:
                    ShowInvent(); // 인벤토리
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    // 아직 메뉴 이동 연결 못 시킴 !
                    Console.WriteLine("1. 상태보기\n2. 인벤토리\n");
                    Console.WriteLine("다시 입력해주세요.(숫자만 입력해주세요!)");
                    break;
            }
        }


        // 상태 보기
        static void ShowStatus()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기"); // text color and weight 변경해보자!
            Console.ResetColor();

            Console.WriteLine("캐릭터의 정보가 표시됩니다");
            Console.WriteLine();
            Console.WriteLine($"{player1.name} ({player1.job})");
            Console.WriteLine($"Lv. {player1.level}");
            Console.WriteLine($"공격력 : {player1.atk}");
            Console.WriteLine($"방어력 : {player1.def}");
            Console.WriteLine($"체력 : {player1.hp}");
            Console.WriteLine($"Gold : {player1.gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.(숫자만 입력해주세요!)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (input == 0)
            {
                ShowSpartaVill();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                // 아직 메뉴 이동 연결 못 시킴 !
            }
        }


        // 인벤토리
        static void ShowInvent()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리"); // text color and weight 변경해보자!
            Console.ResetColor();

            Console.WriteLine("보유 중인 아이템입니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            ShowItem();
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.(숫자만 입력해주세요!)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());
            Console.ResetColor();

            switch (input)
            {
                case 1:
                    // 장착 관리로 이동
                    ShowEquipSetting();
                    break;
                case 0:
                    // 나가기
                    ShowSpartaVill();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    // 아직 메뉴 이동 연결 못 시킴 !
                    break;
            }

        }


        // 아이템 목록
        static void ShowItem()
        {
            var table = new ConsoleTable("아이템 이름", "효과", "설명");
            table.AddRow(muIronArmor.Name, muIronArmor.Effect, muIronArmor.Description);
            table.AddRow(oldSword.Name, oldSword.Effect, oldSword.Description);
            // table 의 format 을 default 로 해놓으면 표 하단에 Count 가 나오는데 어떻게 없애지 ??
            // 일단 table 의 format 을 alternative 으로 바꾸니 표는 덜 예쁘지만 count 는 안 뜬다 !
            table.Write(Format.Alternative);
        }


        // 장착 관리
        static void ShowEquipSetting()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("인벤토리 - 장착 관리"); // text color and weight 변경해보자!
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("1 [E]무쇠갑옷\t | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
            Console.WriteLine("2 낡은 검\t | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.(숫자만 입력해주세요!)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());
            Console.ResetColor();

            switch (input)
            {
                case 1:
                    Console.WriteLine("기능 구현중입니다 ^_^");
                    break;
                case 2:
                    Console.WriteLine("기능 구현중입니다 ^_^");

                    break;
                case 0:
                    ShowInvent();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    // 아직 메뉴 이동 연결 못 시킴 !
                    break;
            }
        }
    }
}
