namespace TasksAndSolutions.Codewars;

internal class Count_IP_Addresses
{
    public static long IpsBetween(string start, string end)
    {
        long[] startArrIp = GetLongArrFromString(start);
        long[] endArrIp = GetLongArrFromString(end);

        long startIp = GetLongFromIp(startArrIp);
        long endIp = GetLongFromIp(endArrIp);

        return startIp >= endIp ?
            startIp - endIp :
            endIp - startIp;

        long[] GetLongArrFromString(string obj)
        {
            string[] ipString = obj.Split('.');
            long[] ipLong = new long[ipString.Length];
            for (int i = 0; i < ipString.Length; i++)
            {
                ipLong[i] = long.Parse(ipString[i]);
            }

            return ipLong;
        }
        long GetLongFromIp(long[] arr)
        {
            long ratio = 256;
            long value = arr[arr.Length - 1];

            for (int i = arr.Length - 2; i >= 0; i--, ratio *= 256)
            {
                value += arr[i] * ratio;
            }
            return value;
        }
    }
}
