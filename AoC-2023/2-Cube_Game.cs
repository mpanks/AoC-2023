using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023
{
    internal class _2_Cube_Game
    {
    }
    public class Challenge_2
    {
        private string _file;
        private List<string> _games = new List<string>();
        private int red = 12;
        private int green = 13;
        private int blue = 14;
        public Challenge_2()
        {
            _file = @"C:\\Users\\matth\\OneDrive\\Documents\\Comp Sci\\AoC\\2023\\AoC-2023\\2-Cube_Game_Strings.txt";
        }
        public void ReadFile()
        {

        }
        public void Execute()
        {
            using (StreamReader sr = new StreamReader(_file))
            {
                while (!sr.EndOfStream)
                {
                    _games.Add(sr.ReadLine());
                }
            }

            int total = 0;
            for (int j = 0; j < _games.Count; j++)
            {
                int minGreen = 0;
                int minBlue = 0;
                int minRed = 0;

                int remove = 0;
                if (j < 10) remove = 8;
                else if (j < 100) remove = 9;
                else remove = 10;
                string newGame = _games[j].Substring(remove);
                // bool possible = true;

                string[] hands = newGame.Split("; ");
                foreach (string cubes in hands)
                {
                    //if (possible)
                    //{
                    string[] colour = cubes.Split(' ');
                    for (int i = 1; i < colour.Length; i += 2)
                    {
                        if (colour[i].Contains("green"))
                        {
                            if (int.Parse(colour[i - 1]) > minGreen)
                            {
                                minGreen = int.Parse(colour[i - 1]);
                            }
                        }
                        else if (colour[i].Contains("blue"))
                        {
                            if (int.Parse(colour[i - 1]) > minBlue)
                            {
                                minBlue = int.Parse(colour[i - 1]);
                            }
                        }
                        else if (colour[i].Contains("red"))
                        {
                            if (int.Parse(colour[i - 1]) > minRed)
                            {
                                minRed = int.Parse(colour[i - 1]);
                            }
                        }
                        //        if (possible && colour[i].Contains("green"))
                        //        {
                        //            if (int.Parse(colour[i - 1]) > green)
                        //            {
                        //                possible = false; goto Afterloop;
                        //            }
                        //        }
                        //        else if (possible && colour[i].Contains("blue"))
                        //        {
                        //            if (int.Parse(colour[i - 1]) > blue) { possible = false; goto Afterloop; }

                        //        }
                        //        else if (possible && colour[i].Contains("red"))
                        //        {
                        //            if (int.Parse(colour[i - 1]) > red) { possible = false; goto Afterloop; }
                        //        }
                    }
                }
                //if (minGreen >= 100)
                //{
                //    minGreen = 0;
                //}
                //if (minBlue >= 100)
                //{
                //    minBlue = 0;
                //}
                //if (minRed >= 100)
                //{
                //    minRed = 0;
                //}
                total += (minBlue * minGreen * minRed);
                //else { goto Afterloop; }

                //Afterloop:
                //if (possible)
                //{
                //    total += j + 1;
                //    possible = false;
                //}
            }
            Console.WriteLine(total);
        }
    }
}
