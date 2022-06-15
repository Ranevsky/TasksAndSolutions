namespace TasksAndSolutions.Codewars;

internal static class Greed_is_Good
{
    public static int Score(int[] dice)
    {
        byte[] arr = new byte[6];
        int sum = 0;
        for (int i = 0; i < dice.Length; i++)
        {
            arr[dice[i] - 1]++;
        }

        if (arr[0] >= 3)
        {
            arr[0] -= 3;
            sum += 1000;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 3)
            {
                arr[i] -= 3;
                sum += (i + 1) * 100;
            }
        }

        if (arr[0] >= 1)
        {
            sum += arr[0] * 100;
        }

        if (arr[4] >= 1)
        {
            sum += arr[4] * 50;
        }

        return sum;
    }
}