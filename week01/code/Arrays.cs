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

        // PLAN:
        // 1. Create a new array of type double with the given size 'length'.
        // 2. Use a for loop to iterate from 0 to length - 1.
        // 3. For each index i in the array, calculate the i-th multiple by multiplying 'number' by (i + 1).
        //    This is because the first multiple is 1 * number, second is 2 * number, etc.
        // 4. Store the result of the multiplication in the i-th position of the array.
        // 5. After the loop ends, return the filled array.

        // Step 1: Create the array.
        double[] multiples = new double[length];

        // Step 2: Loop 'length' times. We use 'i' as a 0-based index for the array.
        for (int i = 0; i < length; i++)
        {
            // Step 3 & 4: Calculate the multiple and assign it to the array.
            // The multiplier is (i + 1) to get 1, 2, 3, ... instead of 0, 1, 2, ...
            multiples[i] = number * (i + 1);
        }

        // Step 5: Return the final array.
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. First, determine the number of elements in the list (data.Count).
        // 2. Identify the last 'amount' elements that will be moved to the front.
        //    This can be done using GetRange(data.Count - amount, amount).
        // 3. Identify the remaining elements (from index 0 to data.Count - amount - 1).
        //    This is the first part of the list using GetRange(0, data.Count - amount).
        // 4. Clear the original list (or optionally remove all elements, or just overwrite).
        // 5. Add the elements from step 2 (the rotated portion) to the list.
        // 6. Add the elements from step 3 (the remaining portion) after that.

        // Step 1: No need to store data.Count in a variable since List.Count is efficient.
        // Step 2: Get the last 'amount' elements.
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 3: Get the first part of the list that stays after the rotated values.
        List<int> head = data.GetRange(0, data.Count - amount);

        // Step 4: Clear the original list to prepare for the reordered values.
        data.Clear();

        // Step 5 & 6: Add the rotated values followed by the remaining original values.
        data.AddRange(tail);
        data.AddRange(head);
    }
}
