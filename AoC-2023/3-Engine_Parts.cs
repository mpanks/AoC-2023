using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AoC_2023
{
    internal class _3_Engine_Parts
    {
    }
    public class Challenge_3
    {
        private bool debug = false;
        private string FilePath = @"C:\Users\matth\OneDrive\Documents\Comp Sci\AoC\2023\AoC-2023\3-Engine_Parts.txt";
        private char[,] _grid;
        public Challenge_3() { }
        public void Execute()
        {
            ReadFile();
        }
        public void ReadFile()
        {
            List<string> strings = new List<string>();
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    strings.Add(sr.ReadLine());
                }
            }
            CreateGrid(ref strings);
        }
        private void CreateGrid(ref List<string> strings)
        {
            _grid = new char[strings.Count, strings[0].Length];
            for (int i = 0; i < strings.Count; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    _grid[i, j] = strings[i][j];
                }
            }

            if (debug)
            {
                for (int i = 0; i < _grid.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        Console.Write(_grid[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            FindAjacent();
        }
        private void FindAjacent()
        {
            int total = 0;
            string temp = string.Empty;
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                bool add = false;
                //iterates columns
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    //iterates rows
                    if (_grid[x, y] != '.' && char.IsNumber(_grid[x, y]))
                    {
                        Console.WriteLine(_grid[x,y]);
                        if (CheckDirections(ref x, ref y) && add)
                        {
                            temp += _grid[x, y];
                        }
                    }
                }
                //if (temp != "")
                //{
                //    total += int.Parse(temp);
                //}
                //Console.WriteLine(total);
            }
        }
        private bool CheckDirections(ref int x, ref int y)
        {
            try
            {

                for (int _x = x - 1; _x <= x + 1; _x++)
                {
                    //checks left and right of co-ordinates
                    for (int _y = y - 1; _y <= y + 1; _y++)
                    {
                        //checks up and down co-ordinates
                        if (_x < 0) //Check if too far left, need to add right
                        {
                            //x OOB
                            break;
                        }
                        else if (_y < 0) //check if too far up, need to add down
                        {
                            //y OOB
                            break;
                        }
                        else
                        {
                            //Checks up, down, left, right
                            //Needs to be able to check diags
                            if(_y!=y+2) Console.Write($"{_x}: {_y}: {_grid[_x, _y]} ");
                        }
                    }
                }
                Console.WriteLine();

            }
            catch (Exception e) { }
            return false;
        }
    }
}
