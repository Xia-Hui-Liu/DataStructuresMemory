﻿using System;

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
                        break;
                    case '-':
                        if (theList.Contains(value))// check if the list contains value
                            theList.Remove(value);
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
            Console.WriteLine($"Count:{theList.Count}, Capacity:{theList.Capacity}");// log out the number of item in the list and the capacity
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

            Queue<string> queue = new();

            while (true)
            {
                Console.WriteLine("Using + to enqueue an item or - to dequeue an item. Type 'exit' to quit: ");
                string ? input = Console.ReadLine();

                if (input == "exit")// check if input is 'exit' then exit the program
                    break;
                if (string.IsNullOrEmpty(input))// check input is null 
                {
                    Console.WriteLine("Invalid input. Please use + to enqueue an item or - to dequeue an item.");
                    continue;
                }
                
                char nav = input[0];
                string value = input[1..];// using range operator to create substring start from index 1

                 switch(nav)
                {
                    case '+':
                        queue.Enqueue(value);// enqueue item with input value
                        break;
                    case '-':
                        if (queue.Count > 0)// check if the queue is empty
                            queue.Dequeue(); // dequeue item from the queue
                        else
                        {
                            Console.WriteLine("Queue is empty.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please only using + or - ");
                        break;
                }
                PrintQueue(queue);// call the fuction PrintQueue to print out every item after Enqueued and Dequeued
            }       
        }

        private static void PrintQueue(Queue<string> queue)
        {
            foreach (string item in queue)
            {
                Console.WriteLine(item);
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
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

