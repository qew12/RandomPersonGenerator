﻿using System;
using System.Text;
using Bogus;
using System.Collections.Generic;
using System.Globalization;

namespace Task3
{
    

    class Program
    {
        
        static void Main(string[] args)
        {
            Randomizer.Seed = new Random();

            uint rows = 0;
            double averageErrors = 0.0;
            string locale = "";
            
            try
            {
                ParseArgs(args, out rows, out averageErrors, out locale);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            List<StringBuilder> FakeUsers = new List<StringBuilder>((int)rows);
            UserGenerator.SetLocale(locale);
            Faker<TableUser> generator = UserGenerator.GetInstace();
            
            for (int i = 0; i < rows; i++)
            {
                TableUser user = generator.Generate();  
                user.FillStr();
                FakeUsers.Add(user.FullData);
            }

            foreach(StringBuilder str in FakeUsers)
            {
                ErrorGen error = new ErrorGen(str, locale);
                error.RandError(averageErrors);
                Console.WriteLine(str);
            } 
              
        }
        private static void ParseArgs(string[] args, out uint rows, out double averageErrors, out string locale)
        {
            if(args.Length < 2)
            {
                throw new ArgumentException("Unavailable number of parameters");
            }
            rows = uint.Parse(args[1]);
            if(args.Length > 2)
            {
                averageErrors = Double.Parse(args[2], CultureInfo.InvariantCulture);
                if(averageErrors < 0.0) averageErrors = 0.0;
            }
            else averageErrors = 0.0;

            switch (args[0])
            {
                case "en_US":
                locale = "en";break;

                case "ru_RU":
                locale = "ru";break;

                case "be_BY":
                locale = "by";break;

                default:
                throw new ArgumentException("Incorrect locale , available - en_US, ru_RU, be_BY");
            }

        }

    }
}