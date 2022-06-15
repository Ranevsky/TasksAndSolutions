using System.Text;

namespace TasksAndSolutions.Codewars;

internal class Title_Case
{
    public static string TitleCase(string title, string minorWords = "")
    {
        string[] titleWords = title.Split();
        StringBuilder sb = new(title.Length + 1);

        string[]? words = null;

        if (minorWords != null && minorWords.Length > 0)
        {
            words = minorWords.ToLower().Split();
        }

        sb.Append(titleWords[0].ToLower() + " ");

        // Checking punctuation marks
        if (sb[0] >= 97 && sb[0] <= 122)
        {
            CharacterToUpper(sb, 0);
        }

        for (int i = 1; i < titleWords.Length; i++)
        {
            int count = titleWords[i].Length + 1;
            string word = titleWords[i].ToLower();


            sb.Append(word + " ");

            if (!(words != null && Array.Exists(words, w => word.Equals(w))))
            {
                int beginningOfWord = sb.Length - count;
                CharacterToUpper(sb, beginningOfWord);
            }
        }

        sb.Length -= 1;
        return sb.ToString();
        
        static void CharacterToUpper(StringBuilder sb, int index)
        {
            sb[index] = (char)(sb[index] - 32);
        }
    }
}
