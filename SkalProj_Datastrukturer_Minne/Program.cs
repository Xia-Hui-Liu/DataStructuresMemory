using System;
using System.Reflection.Metadata;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            /*
              När ökar listans kapacitet? Med hur mycket ökar kapaciteten? 
              Den ökar från storlek 1, men från 1 till 4 så förblir kapaciteten densamma vid 4. 
              Från storlek 5-8 förblir kapaciteten densamma vid 8.
              Från storlek 9-13 förblir kapaciteten densamma vid 16.

              Varför ökar inte listans kapacitet i samma takt som element läggs till?
              För att när vi lägger till element omallokerar den periodiskt en större array och kopierar de befintliga elementen till den nya arrayen.

              Minskar kapaciteten när element tas bort ur listan?
              Nej, det gör inte. Storleken ändras inte automatiskt.

              När är det då fördelaktigt att använda en egendefinierad array istaället för en lista?
              När vi vet den exakta storleken på kollektionen vi behöver och den kommer int att ändras och om vi vill minimera minneskostnader.
             */

            List<string> theList = new List<string>();//initialize an empty list out side of the loop, ensures the list isn't re-initialized with each iteration

            while (true)// Starts an infinite loop using while (true)
            {
                Console.WriteLine("Using + to add a name or - to remove a name from the list. Type 'exit' to quit: ");
            
                string ? input = Console.ReadLine();

                if (input == "exit")// check if input is 'exit' then exit the program
                    break;
                if (string.IsNullOrEmpty(input) || input.Length < 2 )// check input is null or input length less than 2
                {
                    Console.WriteLine("Invalid input. Please use + to add or - to remove a name.");
                    continue;
                }
                
                char nav = input[0];
                string value = input[1..];// using range operator to create substring start from index 1
                switch(nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Count:{theList.Count}, Capacity:{theList.Capacity}");
                        break;
                    case '-':
                        if (theList.Contains(value))// check if the list contains value
                         {  
                            theList.Remove(value);
                            Console.WriteLine($"Count:{theList.Count}, Capacity:{theList.Capacity}");
                         }
                        else
                        {
                            Console.WriteLine(value + " not found in the list.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please only using + or - ");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();

            while (true)
            {  
                Console.WriteLine("Welcome to ICA Queue-checkout system.");
                Console.WriteLine("To join the queue, press '+' or press '-' to cancel:  ");
                Console.WriteLine("Type 'exit' to quit : ");

                var keyInfo = Console.ReadKey();

                switch(keyInfo.KeyChar)
                {
                    case 'e':
                    case 'E':
                        return;

                    case '+':
                        Console.WriteLine("\nEnter your name: ");
                        string ? value = Console.ReadLine();
                        if(string.IsNullOrEmpty(value))
                            Console.WriteLine("Invalid input. Using + to join the queue or - to cancel.");
                        else
                        {
                            queue.Enqueue(value);// enqueue item with input value
                            Console.WriteLine($"{value} ställer sig i kön.");
                            Console.WriteLine($"There are { queue.Count -1 } person in front of you!");
                        }
                        break;

                    case '-':
                        if (queue.Count > 0)// check if the queue is empty
                         {
                            var dequeuedItem = queue.Dequeue(); // dequeue item from the queue
                            Console.WriteLine($"\n{dequeuedItem} has been removed from the queue.");
                         }
                        else
                            Console.WriteLine("ICA öppnar och kön till kassan är tom.");
                        break;

                    default:
                        Console.WriteLine("Please only using + or - ");
                        break;
                }
            }       
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.WriteLine("Enter a text message to reverse: ");
            string ? userInput = Console.ReadLine();

            string reversedString = ReverseText(userInput);
            Console.WriteLine("Reversed string:");
            Console.WriteLine(reversedString);
        
        }

        private static string ReverseText(string? input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Stack<char> chars = new Stack<char>();
                foreach(var c in input)
                {
                    chars.Push(c);
                }

                char[] reversedChars = new char[input.Length];

                for (var i = 0; i < input.Length; i++)
                {
                    reversedChars[i] = chars.Pop();
                }
                return new string(reversedChars);
            }
            else 
            {
                Console.WriteLine("Please enter a value: ");
                return string.Empty;
            }
        
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

             Console.WriteLine("Enter a string with parentheses: ");

             string ? input  = Console.ReadLine();
             bool wellFormed = CheckString(input);
             
             Console.WriteLine(wellFormed);
             Console.WriteLine("Your input is " + (wellFormed ? " well formed" : "not well formed"));
             
        }

        private static bool CheckString(string? input)
        {
            Stack<char> chars = new Stack<char>();

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            else
            {
                foreach(var c in input)
                {
                    if (c is '(' or '{' or '[')
                    {
                        chars.Push(c);
                    }
                    else if (c is ')' or ']' or '}')
                    {
                        if (chars.Count == 0 || !IsMatchingPair(chars.Pop(), c))
                        {
                            return false;
                        }
                    }
                }
            }
           return chars.Count == 0;
        }

        private static bool IsMatchingPair(char opeing, char closing)
        {
            return 
            (opeing == '(' && closing == ')') ||
            (opeing == '[' && closing == ']') ||
            (opeing == '{' && closing == '}');
        }
    }
}

