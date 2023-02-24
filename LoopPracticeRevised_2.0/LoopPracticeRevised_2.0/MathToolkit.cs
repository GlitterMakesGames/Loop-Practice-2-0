/*
 * Author: Delaina Hardwick
 * Student ID: 1071204
 * Date Completed: 2/24/2023 (Friday)
 * Summary: This class contains all the little math tools 
 * I need, such as random number generation, a recursive 
 * factorial function, and a function to split a string using 
 * delimiters into an array of integers.
 */
public class MathToolkit
{
    //For Problem #2
    private static int[] sumArray = new int[10];
    private static int sumArray_Index = 0;
    private static bool firstIteration = true;
    private static int tempIndex = 0;
    //For Problem #4
    private static Random rng = new Random();
    private static int _chosenNum = 0;
    public static int chosenNum { get => _chosenNum; }
    //For Problem #5
    private static char[] delimiters = {',', ' '};
    private static string[] inputArray;

    //Definitely not efficient at all, but it gets
    //the job done. Maybe don't enter the number 1 million :P
    public static int divisibleByThree(int dividend)
    {
        int count = 0;
        for(int i = 1; i <= dividend; i++)
        {
            if ((i%3) == 0)
            {
                count++;
            }
        }
        return count;
    }

    //Recursively calculates a new sum each time 
    //the function is called.
    public static int sumAllInputs(int addend)
    {
        if(firstIteration)
        {
            if(sumArray_Index <= 9)
            {
                sumArray[sumArray_Index] = addend;
            }
            tempIndex = sumArray_Index;
            sumArray_Index++;

            /*NOTE: A new value should be added to the array 
             * ONLY if this is the first iteration! Same goes 
             * for incrementing the next index to be used to 
             * insert a value!
             */
            firstIteration = false;
        }

        //This is the part that actually calculates and 
        //returns a sum, so this code should run every time.
        if (tempIndex > 0)
        {
            return addend + sumAllInputs(sumArray[--tempIndex]);
        }
        else
        {
            firstIteration = true;
            return addend;
        }
    }

    /*As mentioned in the class "WeekFiveProblems"
     * this will reset both the sumArray and sumArray_Index
     * to default values so that the method "ProblemTwo" 
     * can be reused.
     */
    public static void resetAllInputs()
    {
        for (int i = sumArray_Index - 1; i >= 0; i--)
        {
            sumArray[i] = 0;
        }
        sumArray_Index = 0;
    }

    public static int factorial(int facBase)
    {
        if (facBase == 1)
        {
            return 1;
        }
        else
        {
            return facBase * factorial(--facBase);
        }
    }

    public static void getRandNum()
    {
        _chosenNum = rng.Next(1, 11);
    }

    public static bool guessingGame(int guess)
    {
        if (guess == _chosenNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*Uses delimiters to separate the original string into 
     * an array of strings, which is then iterated through 
     * so that each value can be converted into an int for 
     * comparison.
    */
    public static int getBiggestNum(string input)
    {
        inputArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        int? biggest = null;
        foreach(string s in inputArray)
        {
            int temp = Int32.Parse(s);
            if (biggest != null
                && temp > biggest)
            {
                biggest = temp;
            }
            else if (biggest == null)
            {
                biggest = temp;
            }
        }
        return biggest.GetValueOrDefault();
    }
}