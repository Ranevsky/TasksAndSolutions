using System.Text;

using TasksAndSolutions.LeetCode;

using static System.Net.Mime.MediaTypeNames;

namespace TasksAndSolutions.Codewars;


// https://www.codewars.com/kata/51b66044bce5799a7f000003/train/csharp
internal class Roman_Numerals_Helper
{
    private static readonly Dictionary<int, char> intSymbols = new()
    {
        { 1, 'I' },
        { 5, 'V' },
        { 10, 'X' },
        { 50, 'L' },
        { 100, 'C' },
        { 500, 'D' },
        { 1000, 'M' }
    };
    private static readonly Dictionary<char, int> romanSymbols = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    private static readonly Dictionary<char, char[]> subtractionSymbols = new()
    {
        { 'I', new char[] { 'V', 'X' } },
        { 'X', new char[] { 'L', 'C' } },
        { 'C', new char[] { 'D', 'M' } },
    };

    public static int FromRoman(string romanNumeral)
    {
        //Validation();
        int number = 0;
        int numeral;
        for (int i = 0; i < romanNumeral.Length; i++)
        {
            numeral = 0;
            // Symbol that can take away
            if (i + 1 < romanNumeral.Length && subtractionSymbols.TryGetValue(romanNumeral[i], out var sub))
            {
                // Subtracting symbol is in a pair
                if (sub.Contains(romanNumeral[i + 1]))
                {
                    numeral += romanSymbols[romanNumeral[i + 1]];
                    numeral -= romanSymbols[romanNumeral[i]];
                    i++;
                }
                else
                {
                    numeral += romanSymbols[romanNumeral[i]];
                }
            }
            else
            {
                numeral += romanSymbols[romanNumeral[i]];
            }
            number += numeral;
        }

        return number;
    }
    public static string ToRoman(int n)
    {
        int num = n;
        var romanBuilder = new StringBuilder();

        int length = GetLengthLog(n);

        int ten = 1;
        for (int i = 0; i < length-1; i++)
        {
            ten *= 10;
        }

        int number;
        for (int i = 0; i < length; i++, ten /= 10)
        {
            number = ((n / ten) % 10) * ten;

            string roman = string.Empty;
            int digit = number / ten;

            if (digit <= 3)
            {
                for (int j = 0; j < digit; j++)
                {
                    romanBuilder.Append(intSymbols[ten]);
                }
            }
            else if(digit >= 4 && digit <= 8)
            {
                int digit1 = digit - 5;
                if (digit1 == -1)
                {
                    // 4
                    string txt = intSymbols[ten] + string.Empty + intSymbols[5 * ten];
                    romanBuilder.Append(txt);
                }
                else if(digit1 == 0)
                {
                    // 5
                    romanBuilder.Append(intSymbols[5 * ten]);
                }
                else
                {
                    // 6-8
                    romanBuilder.Append(intSymbols[5 * ten]);
                    for (int j = 0; j < digit1; j++)
                    {
                        romanBuilder.Append(intSymbols[ten]);
                    }
                }
            }
            else
            {
                string txt = intSymbols[ten] + string.Empty + intSymbols[ten * 10];
                romanBuilder.Append(txt);
            }
        }

        return romanBuilder.ToString();
    }

    private static int GetLengthLog(int num)
    {
        num = Abs(num);

        if (num == 0)
        {
            // In Math.Log10 args not equals zero
            num = 1;
        }

        int length = (int)(Math.Log10(num) + 1);
        return length;

        int Abs(int num)
        {
            if (num >= 0)
            {
                return num;
            }


            if (num == int.MinValue)
            {
                num = num + 1;
            }

            num *= -1;

            return num;
        }
    }    

}
