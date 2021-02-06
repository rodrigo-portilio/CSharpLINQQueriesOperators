using System;
using System.Linq;

namespace CSharpLINQQueriesOperators
{
    class Program
    {    
        static string[] users = new []{ "Emily", "Jacob", "Thomas" };

        static void Main(string[] args)
        {
            Console.WriteLine("Select a option:");
            Console.WriteLine("1 - WhereAndOrderByClause");
            Console.WriteLine("2 - GroupClause");
            var option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    WhereAndOrderByClause();
                    break;
                case 2:
                    GroupClause();
                    break;
                default:
                    Console.WriteLine("Option invalid!");
                    break;
            }
        }

        static void WhereAndOrderByClause()
        {
            var userQuery = 
                from user in users
                where user.Contains("m") // Where Clause
                orderby user.Length ascending // Orderby Clause | Can arrange the result in ascending or descending order
                select user;

            userQuery.Count(); // Execute the query            

            foreach (var user in userQuery)
            {
                Console.WriteLine(user);
            }
        }
        static void GroupClause()
        {            

            var userQuery =
                from user in users
                group user by user.Length into userGroup
                select userGroup;
            
            foreach (var userGroup in userQuery)
            {
                Console.WriteLine($"{userGroup.Key} characters long", userGroup.Key);
                foreach (var user in userGroup)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
