using System;
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
            Randomizer.Seed = new Random(1338);

            int rows = 0;
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

            List<StringBuilder> FakeUsers = new List<StringBuilder>(rows);
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
                Console.WriteLine(str);
                ErrorGen error = new ErrorGen(str, locale);
                error.RandError(averageErrors);
                Console.WriteLine(str);
            } 
              
        }
        private static void ParseArgs(string[] args, out int rows, out double averageErrors, out string locale)
        {
            rows = Int32.Parse(args[1]);
            averageErrors = Double.Parse(args[2], CultureInfo.InvariantCulture);
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