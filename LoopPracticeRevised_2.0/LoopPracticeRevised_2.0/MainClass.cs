/*
 * Author: Delaina Hardwick
 * Student ID: 1071204
 * Date Completed: 2/24/2023 (Friday)
 * Summary: Code that solves 5 problems testing my ability 
 * to use loops and arrays. I took the liberty of exploring 
 * and/or reviewing other programming concepts as well.
 * 
 * The class "MainClass" contains main loop: allowing the user 
 * to indefinitely test out the five problems until they quit.
 * 
 * The class "WeekFiveProblems" handles all interactions with 
 * the user outside of the main loop.
 * 
 * The class "MathToolkit" contains all the little math tools 
 * I need, such as random number generation, a recursive 
 * factorial function, and a function to split a string using 
 * delimiters into an array of integers.
 * 
 * I haven't used delimiters in forever! It's been so nice to 
 * brush the dust off these old programming skills :)
 * 
 * Also, I only used exception handling in the class "MainClass"
 * because I'm lazy :)
 */

using static MathToolkit;
using static WeekFiveProblems;
class MainClass
{
    public static void Main(string[] args)
    {
        bool running = true;
        string userChoice = "";
        int num = 0;

        while(running)
        {
            Console.WriteLine("Please enter an integer 1 through 5 corresponding");
            Console.WriteLine("to the problem you would like to test.");
            Console.Write("Otherwise, enter 0 to exit: ");
            userChoice = Console.ReadLine();
            try
            {
                num = Int32.Parse(userChoice);
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Input. Try again.\n");
                continue;
            }

            switch(num)
            {
                case 1:
                    Console.WriteLine();
                    ProblemOne();
                    break;
                case 2:
                    Console.WriteLine();
                    ProblemTwo();
                    break;
                case 3:
                    Console.WriteLine();
                    ProblemThree();
                    break;
                case 4:
                    Console.WriteLine();
                    ProblemFour();
                    break;
                case 5:
                    Console.WriteLine();
                    ProblemFive();
                    break;
                case 0:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input. Try Again.\n");
                    break;
            }
        }
    }
}

public class WeekFiveProblems
{
    static string input = "";
    static string output = "";
    static int temp;
    static bool win = false;

    /*
     * Problem 1: Write a program to count 
     * how many numbers between 1 and 100 
     * are divisible by 3 with no remainder.
     * 
     * NOTE: In my particular code, the user 
     * may choose any positive integer, not 
     * just 100 :)
     */
    public static void ProblemOne()
    {
        Console.WriteLine("How many numbers are divislbe by three");
        Console.WriteLine("between 1 and your number?");
        Console.Write("Please enter a positive integer: ");
        int dividend = Int32.Parse(Console.ReadLine());
        output = divisibleByThree(dividend) + "";
        Console.WriteLine("There are " + output + " numbers divisible by three between 1 and " + dividend);
        Console.WriteLine();
    }

    /*
     * Problem 2: Continuously ask the user to enter 
     * a number or "ok" to exit. Calculate the sum of 
     * all the previously entered numbers.
     * 
     * NOTE: Due to the infinite nature of the "main 
     * loop" (as I called it in the summary at the top)
     * this method will call a "resetAllInputs" method 
     * after completion so that it will once again work 
     * with its default values when this method is 
     * called again! :)
     */
    public static void ProblemTwo()
    {
        Console.WriteLine("Please enter all the integers you would like to add (maximum of 10).");
        Console.WriteLine("One at a time, please. Otherwise, enter \"ok\" to move on.\n");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter the Next Number: ");
            input = Console.ReadLine();

            if (input.Equals("ok", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                break;
            }

            temp = Int32.Parse(input);
            output = sumAllInputs(temp) + "";
            Console.WriteLine("The total sum is now " + output);

            if (i == 9)
            {
                Console.WriteLine("\nYou have used up all your numbers.\n");
            }
        }
        resetAllInputs();
    }

    /*
     * Problem 3: Ask the user to enter a number.
     * Then compute the factorial of the number.
     * 
     * Ah, such a classic :P :P :P
     */
    public static void ProblemThree()
    {
        Console.Write("Please enter an integer for the factorial calculation: ");
        input = Console.ReadLine();
        output = factorial(Int32.Parse(input)) + "";
        Console.WriteLine(input + "! is equal to " + output);
        Console.WriteLine();
    }

    /*
     * Write a program that picks a random number 
     * between 1 and 10. Give the user 4 chances 
     * to guess the number. Display "You Win!" or 
     * "You Lose" depending on the outcome.
     * 
     * Note: For the convenience of anyone grading this, 
     * a comment has been added which can be used to display 
     * the correct number for the user to guess.
     */
    public static void ProblemFour()
    {
        getRandNum();
        //For Debugging:
        //Console.WriteLine(MathToolkit.chosenNum);
        for (int attempts = 0; attempts < 4; attempts++)
        {
            Console.Write("Enter your guess (1-10): ");
            input = Console.ReadLine();
            if (guessingGame(Int32.Parse(input)))
            {
                win = true;
                Console.WriteLine("You Win!");
                break;
            }
            else
            {
                win = false;
                Console.WriteLine("Incorrect!");
            }
        }
        if (!win)
        {
            Console.WriteLine("You Lose!");
        }
        Console.WriteLine();
    }

    /*
     * Ask the user to enter a series of numbers separated by commas.
     * Find the largest value of all the entered numbers.
     * 
     * Note: Both commas AND spaces are used as delimiters, and 
     * empty strings (aka. "empty entries") are ignored.
     * 
     * HOWEVER, there is no input validation to make sure that the 
     * values bewteen commas and spaces are indeed integers!
     * Please keep this in mind!
     */
    public static void ProblemFive()
    {
        Console.WriteLine("Please enter a list of integers separated by commas.");
        Console.WriteLine("Press \"Enter\" when done.");
        Console.Write("Type Here: ");
        input = Console.ReadLine();
        output = getBiggestNum(input) + "";
        Console.WriteLine("The biggest number in the list provided is " + output);
        Console.WriteLine();
    }
}