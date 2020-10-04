﻿using System;
using System.Linq;

namespace TimeQLine.Core
{
    public class ParsedData
    {
        public string MainCommand { get; set; }
        public string OperationCommand { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public ParsedData(string main, string operation = "", string hours = "", string minutes = "", string seconds = "")
        {
            MainCommand = main;
            OperationCommand = operation;

            Hours = GetTimeInt(hours);
            Minutes = GetTimeInt(minutes);
            Seconds = GetTimeInt(seconds);
        }

        public int OverallSeconds()
        {
            return (Hours * 60 * 60 + (Minutes * 60) + Seconds);
        }

        private int GetTimeInt(string str)
        {
            if (str != "")
            {
                string numberString = String.Join("", str.Where(char.IsDigit));
                int number = Convert.ToInt32(numberString);

                if (str.Contains("-"))
                {
                    number *= -1;
                }
                return number;
            }
            else
                return 0;
        }
    }
}
