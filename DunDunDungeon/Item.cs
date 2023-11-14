namespace DunDunDungeon
{

    internal partial class Program
    {
        class Item
        {
            public string Name { get; }
            public string Description { get; }
            public int Type { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public bool IsEquipped { get; set; }

            public static int ItemCnt = 0;

            public Item(string name, string description, int type, int atk, int def, int hp, bool isEquipped = false)
            {
                Name = name;
                Description = description;
                Type = type;
                Atk = atk;
                Def = def;
                Hp = hp;
                IsEquipped = isEquipped;
            }

            public void PrintItemStatDescription(bool withNumber = false, int idx = 0) // withNumber 는 장착 관리와 관련한 파라미터입니다 !
            {
                Console.Write("- ");
                if (withNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0}. ", idx);
                    Console.ResetColor();
                }
                if (IsEquipped)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("E");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.Write(PadRightForMixedText(Name, 15)); // 장착 중인 경우 9글자 출력.
                }
                else
                {
                    Console.Write(PadRightForMixedText(Name, 18)); // 여긴 이미 Item 안에 있기 때문에 Item.Name 이 아니고 Name ! & 장착 중이 아닌 경우 12글자 출력.
                }
                    Console.Write(" | ");


                // 삼항연산자 - 조건 ? 조건이 참이라면 : 조건이 거짓이라면
                if (Atk != 0)
                {
                    Console.Write($"Atk {(Atk >= 0 ? "+" : "")}{Atk}");
                }
                if (Def != 0)
                {
                    Console.Write($"Def {(Def >= 0 ? "+" : "")}{Def}");
                }
                if (Hp != 0)
                {
                    Console.Write($"Hp {(Hp >= 0 ? "+" : "")}{Hp}");
                }

                Console.Write(" | ");
                Console.WriteLine(Description);
            }

            // Padding 관련 함수
            public static int GetPrintableLength(string str)
            {
                int length = 0;
                foreach (char c in str)
                {
                    if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                    {
                        length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2 로 취급.
                    }
                    else
                    {
                        length += 1; // 나머지 문자에 대해 길이를 1 로 취급.
                    }
                }
                return length;
            }


            // Padding 관련 함수
            public static string PadRightForMixedText(string str, int totalLength) 
            {
                int currentLength = GetPrintableLength(str);
                int padding = totalLength - currentLength;
                return str.PadRight(str.Length + padding);
            }
        }
    }
}