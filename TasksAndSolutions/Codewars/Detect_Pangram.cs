namespace TasksAndSolutions.Codewars;

internal static class Detect_Pangram
{
    const byte countInABC = 26;
    public static bool IsPangram(string str)
    {
        HashSet<char> hash = new(countInABC);
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                hash.Add(char.ToUpper(str[i]));
            }
        }

        return hash.Count == countInABC ? true : false;
    }
}
