public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        List<double> multiples = new(); //Creating a list to store the multiples

        for (int i = 1; i <= length; i++) //A for loop to iterate the times determined by the length the user is going to set
        {
            double MultipleOf = number * i; //Multiplying the number initially set by the user starting by 1 and so on untill reaching the limit imposed by the length
            multiples.Add(MultipleOf); //After each multiplication, the program adds the multiples to the multiples list
        }

        return multiples.ToArray(); // replace this return statement with your own
    }

    public static void RunMultiplesOf() //This function can be used to run the code wrote in the MultiplesOf function
    {
        double number = 10; //Setting the number we want to get the multiples for
        int length = 3; //Setting the number of multiples we want for the number we intially set.

        List<double> list = MultiplesOf(number, length).ToList();//This line creates a list of numbers based on the MultiplesOf function output.
                                                                
        Console.WriteLine($"Here are {length} multiples of {number}: {string.Join(", ", list)}");//Printing the resulting list to the console.
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Slicing the original list to get the values we want to put at the start of it.
        //Using the GetRange method inversely, we are able to select values from the end to the start of the list
        List<int> slicedValues = data.GetRange(data.Count - amount, amount);

        //Selecting the values that we didn't slice from the list
        //This step consist of storing those values from the beginning of the list to where the sliced values begin.
        List<int> notSlicedValues = data.GetRange(0, data.Count - amount);

        //Erase the data of the original list to live it empty
        data.Clear();

        //Adding the values we segmented to the start of the list using the AddRange method.
        data.AddRange(slicedValues);

        //Adding the values we didn't segmented to the end of the list.
        data.AddRange(notSlicedValues);
    }

    public static void RunRotateListRight() //This function is to implement the code wrote in the RotateListRight function.
    {
        List<int> ints = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Creating a list of integers to then modify it using the RotateListRight code.

        RotateListRight(ints, 3);//Calling the RotateListRight method with the list of integers we created used as one of the parameters to create the rotated list.

        Console.WriteLine($"Formatted list: {string.Join(",", ints)}");//Finally, show the resulting list with the console.

    }
}
