using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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
        //Doesn't add numbers of they're at the end of a row
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
            bool add = false;
            string temp = "";
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if ((add && temp != ""))
                {
                    total += int.Parse(temp);
                    temp = "";
                    add = false;
                }

                //iterates columns
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    //iterates rows
                    if (char.IsNumber(_grid[x, y]))
                    {
                        temp += _grid[x, y]; //concats digits to string
                        //temp added to total if "symbol" detected adjacent to num
                        //Console.WriteLine(_grid[x, y]);
                        if (CheckDirections(ref _grid, ref x, ref y) && !add)
                        {
                            add = true;
                        }
                    }
                    else if ((add && temp != ""))
                    {
                        total += int.Parse(temp);
                        temp = "";
                        add = false;
                    }
                    //Console.WriteLine(total);
                    else
                    {
                        temp = "";
                    }
                }
            }
            Console.WriteLine($"Total: {total}");
        }
        private bool CheckDirections(ref char[,] _grid, ref int x, ref int y)
        {
            char[] symbols = { '$', '%', '&','*','+','=','-','@','/','?','#','*' };
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
                            //if (_y != y + 2) Console.Write($"{_x}: {_y}: {_grid[_x, _y]} ");
                            if (_x >= _grid.GetLength(0)) { }
                            else if (_y >= _grid.GetLength(1)) { }
                            else
                            {
                                if (symbols.Contains(_grid[_x, _y]))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return false;
        }
    }
}
