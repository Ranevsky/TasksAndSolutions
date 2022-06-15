namespace TasksAndSolutions.Codewars;
internal static class Sort_the_odd
{
    public static int[] SortArray(int[] array)
    {
        List<int> list = new();
        
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 1)
            {
                list.Add(array[i]);
            }
        }
        
        list.Sort();
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 1)
            {
                array[i] = list[count];
                count += 1;
            }
        }
        return array;
    }
}
