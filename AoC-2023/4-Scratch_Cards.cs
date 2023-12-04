using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023
{
    internal class _4_Scratch_Cards
    {
    }
    //Two sets of numbers, left and right
    //Left is winning numbers, right is held numbers
    //Compare numbers in left set and right set
    //First match is 1 point, each match after that doubles point value for that card
    //Find sum of points earned 
    public class Challenge_4
    {
        private string FilePath = @"C:\\Users\\matth\\OneDrive\\Documents\\Comp Sci\\AoC\\2023\\AoC-2023\\4-Scratch_Cards.txt";
        private List<string> Cards = new List<string>();
        public Challenge_4() { }
        public void Execute()
        {
            ReadFile();
        }
        private void ReadFile()
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    string card = sr.ReadLine();
                    Cards.Add(card.Split(": ")[1]);
                }
            }
            GetNumbers();
        }
        private void GetNumbers()
        {
            string temp = string.Empty;

            bool isFirstSet = true;
            int total = 0;
            int count = 0;
            int val = 0;

            int[] currentWinning = new int[10];
            int[] currentHeld = new int[25];
            currentHeld[24] = 0;

            foreach (string String in Cards)
            {
                if (temp!="")
                {
                    //Adds last number on RHS
                    if (isFirstSet)
                    {
                        currentWinning[count] = int.Parse(temp);
                        count++;
                        if (count >= 10) count = 0;
                    }
                    else
                    {
                        currentHeld[count] = int.Parse(temp);
                        count++;
                        if (count >= 24) count = 0;
                    }
                    temp = string.Empty;
                    if (currentHeld[24] != 0)
                    {
                        //Calculates point value for the current card
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 25; j++)
                            {
                                if (currentWinning[i] == currentHeld[j])
                                {
                                    if (val == 0)
                                    {
                                        val = 1;
                                    }
                                    else { val *= 2; }
                                }
                            }
                        }
                        currentHeld[24] = 0;
                        total += val;
                        val = 0;
                    }
                    else { Console.WriteLine("Shouldn't happen"); }
                }
                
                isFirstSet = true;
                temp = string.Empty;

                foreach (char ch in String)
                {
                    //Check if int
                    //Cancat int to string, parse to list
                    if (char.IsDigit(ch))
                    {
                        temp += ch;
                    }
                    else if (ch == '|')
                    {
                        isFirstSet = false;
                    }
                    else if (temp == "") { }
                    else
                    {
                        if (isFirstSet)
                        {
                            currentWinning[count] = int.Parse(temp);
                            temp = string.Empty;
                            count++;
                            if (count == 10) count = 0;
                        }
                        else
                        {
                            currentHeld[count] = int.Parse(temp);
                            temp = string.Empty;
                            count++;
                            if (count == 25) count = 0;
                        }
                    }
                }
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}
