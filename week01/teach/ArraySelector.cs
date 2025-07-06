public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List <int> values = new();
        int index1 = 0;
        int index2 = 0;
        
        foreach (var item in select)
        {

            if (item == 1)
            {
                values.Add(list1[index1]);
                index1++;
            }
            else
            {
                values.Add(list2[index2]);
                index2++;
            }

        }
        return values.ToArray();
    }
}