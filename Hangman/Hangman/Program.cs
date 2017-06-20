﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        const string path = "dict.txt";
        // checks if user input is valid
        private static bool IsValid(int low, int high, int userInput)
        {
            bool boolVal = false;
            if(userInput > low && userInput < high)
            {
                boolVal = true;
            }
            return boolVal;
        }
        // getting valid entry between a set low and high
        private static int GetValidEntry(int low, int high, int userInput, string prompt = "")
        {
            Console.WriteLine("inside valid entry");
            Console.Write(prompt);
            int userInt = int.Parse(Console.ReadLine());
            if(userInt < high + 1 && userInt > low - 1) 
            {
                return userInt;
            } else
            {
                Console.WriteLine("Invalid entry");
                return 0;
            }
        }
        private static string SelectRandomWord()
        {
            string[] words = System.IO.File.ReadAllLines(path);
            int wordArrLength = words.Length;
            // getting len of file to choose a rand index
            Random rand = new Random();
            int randIndex = rand.Next(0, wordArrLength);
            string randWord = words[randIndex];
            return randWord;
        }
        private static int MainMenu()
        {
            int userChoice;
            // start main menu
            Console.WriteLine("Welcome to Hangman -- Created by Crandon");
            Console.WriteLine("Choose an option below");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Continue Game");
            Console.WriteLine("4. Exit Game");
            userChoice = int.Parse(Console.ReadLine());
            while(!IsValid(0, 5, userChoice))
            {
                Console.WriteLine("your choice was: " + userChoice);
                // get valid user option
                userChoice = GetValidEntry(0, 5, userChoice, "Enter valid option: ");
            }

            return userChoice;
        }

        static void Main(string[] args)
        {
            // get and store rand word
            string randWord = SelectRandomWord();
            Console.WriteLine(randWord);
            MainMenu();
            Console.ReadKey();
        }
    }
}