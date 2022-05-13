namespace TasksAndSolutions.LeetCode;

internal class Roman
{
    private string roman = null!;
#nullable disable
    public Roman(string roman)
    {
        if (roman == null)
        {
            throw new ArgumentNullException(nameof(roman));
        }
        SetRoman(roman);
    }
#nullable enable
    public void SetRoman(string roman)
    {
        this.roman = roman.Trim().ToUpper();
    }

    private static readonly Dictionary<char, int> romanSybmols = new()
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
    private void Validation()
    {
        int repition = 0;
        for (int i = 0; i < roman.Length; i++)
        {
            if (!romanSybmols.ContainsKey(roman[i]))
            {
                throw new Exception($"Unknown symbol '{roman[i]}'");
            }
            if (i + 1 < roman.Length && roman[i] == roman[i + 1])
            {
                repition++;
                if (repition == 3)
                {
                    string errorString = roman.Substring(i - 2, 4);
                    throw new Exception($"It is not allowed to repeat more than 3 times the symbol '{errorString}'");
                }
            }
            else
            {
                repition = 0;
            }
        }
    }

    public int ConvertToInteger()
    {
        Validation();
        int number = 0;
        int numeral;
        for (int i = 0; i < roman.Length; i++)
        {
            numeral = 0;
            // Symbol that can take away
            if (i + 1 < roman.Length && subtractionSymbols.TryGetValue(roman[i], out var sub))
            {
                // Subtracting symbol is in a pair
                if (sub.Contains(roman[i + 1]))
                {
                    numeral += romanSybmols[roman[i + 1]];
                    numeral -= romanSybmols[roman[i]];
                    i++;
                }
                else
                {
                    numeral += romanSybmols[roman[i]];
                }
            }
            else
            {
                numeral += romanSybmols[roman[i]];
            }
            number += numeral;
        }

        return number;
    }
    public override string ToString()
    {
        return roman;
    }
}
