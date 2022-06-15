namespace TasksAndSolutions.Codewars;

internal static class First_non_repeating_character
{
    public static string FirstNonRepeatingLetter(string s)
    {
        HashSet<char> hash = new();

        // if you use hash for unique, the sequence may change
        List<char> unique = new List<char>();
        Dictionary<byte, char> dict = new();


        char ch;
        for (int i = 0; i < s.Length; i++)
        {
            ch = char.ToUpper(s[i]);

            if (hash.Contains(ch))
            {
                unique.Remove(ch);
            }
            else
            {
                hash.Add(ch);
                unique.Add(ch);
            }
        }
        char? item = unique.FirstOrDefault();

        if (item != null)
        {
            for (int i = 0; i < s.Length; i++)
            {
                ch = char.ToUpper(s[i]);
                if (item == ch)
                {
                    return s[i].ToString();
                }
            }
        }

        return "";
    }
}
