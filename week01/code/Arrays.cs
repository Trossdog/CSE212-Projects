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
        // Establish an array to return
        double[] multiples = new double[length];

        // Make a loop to caluclate the multiples
        for (int i = 0; i < multiples.Length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // return the array
        return multiples;

    
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
        /// check if the list is not empty
        if (data == null || data.Count == 0)
            return;

        /// find out how much to rotate the list especially
        /// if we need to rotate more than the size of the list
        amount = amount % data.Count;

        /// only rotates if theres more than 0 numbers in the range
        if (amount > 0){
            /// defines a variable as the last number
            var last_number = data.GetRange(data.Count - amount, amount);

            /// Removes the numbers from the index location
            data.RemoveRange(data.Count - amount, amount);

            /// puts the removed elements onto the front of the list
            data.InsertRange(0, last_number);
        }
        
    }
}
