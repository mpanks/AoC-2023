﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023
{
    internal class _1_Calibration
    {
    }
    //File of strings
    //Part 1: get digits in strings
    //Concat first and last digit together
    //Calculate total from all strings
    //Part 2: some of the numbers are written, these are also digits
    public class Challenge_1
    {
        private string FileName;
        public Challenge_1()
        {
            FileName = @"C:\\Users\\matth\\OneDrive\\Documents\\Comp Sci\\AoC\\2023\\AoC-2023\\1-Calibration_Strings.txt";
        }
        public void Execute()
        {
            ReadFile();
        }
        public void ReadFile()
        {
            List<string> strings = new List<string>();
            using (StreamReader sr = new StreamReader(FileName))
            {
                while (!sr.EndOfStream)
                {
                    strings.Add(sr.ReadLine());
                }
            }
            GetDigits(ref strings);
        }
        public void GetDigits(ref List<string> strings)
        {
            List<int> digits = new List<int>();
            for (int j = 0; j < strings.Count(); j++)
            {

                List<int> ints = new List<int>();
                int count = 0;
                string check = string.Empty;
                for (int i = 0; i < strings[j].Length; i++)
                {
                    if (char.IsDigit(strings[j][i]))
                    {
                        string ch = strings[j][i].ToString();
                        int val = int.Parse(ch);
                        ints.Add(val);
                        count++;
                    }
                    else
                    {
                        check += strings[j][i];
                        string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                        for (int a = units.Count() - 1; a >= 0; a--)
                        {
                            if (check.ToLower().Contains(units[a]))
                            {
                                ints.Add(a);
                                //check = string.Empty;
                                char final = check[check.Length - 1];
                                check = final.ToString();
                            }
                        }
                    }
                }
                int digit = Convert.ToInt32(String.Format("{0}{1}", ints[0], ints[ints.Count() - 1]));
                digits.Add(digit);
            }
            Total(ref digits);
        }
        public void Total(ref List<int> digits)
        {
            int total = 0;
            foreach (int i in digits)
            {
                total += i;
            }
            Console.WriteLine(total.ToString());
        }
    }
}
