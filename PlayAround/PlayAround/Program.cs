using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayAround
{
    class Program
    {



        static void fred(ref int e)
        {
            e++;
           
        }


        static void Main(string[] args)
        {
            linearSeach lineSearch = new linearSeach();

            string searchChoice;
            int validChoiceChecker = 0;

            Console.WriteLine ("Please input a range for me to guess." + "\n\n");
            Console.WriteLine ("First, please give me the minimum number of the range." + "\n\n");
            Global.minNumber = int.Parse(Console.ReadLine());
            Console.WriteLine ("Now, please give me the maximum number of the range." + "\n\n");
            Global.maxNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to use a linear search?" +  "\n\n");
            while (validChoiceChecker == 0)
            {
                Console.WriteLine("Please input l for linear or b for binary." + "\n\n");
                searchChoice = Console.ReadLine();

                if (searchChoice == "l" || searchChoice == "L")
                {
                    // this preforms a search for the correct number based upon a linear search.
                    validChoiceChecker++;
                    lineSearch.Search();

                }
            }
            //// initalising and declaration must happen at the same time...?
            //int health = 10;



            //// Declaration of a list in C#
            //List<int> food = new List<int>();

            //// Adding to a list.
            //food.Add(30);


            //food.Add(50);
            //// "For each item in the list, do this"

            //foreach (var item in food)
            //{
            //    if (item == 50)
            //    {
            //        food.Remove(item);
            //    }
            //}



            //food.ForEach(Console.WriteLine);


            //health = 50;
            //int health2 = health;
            //Singleton.increment();
            //Singleton.increment();
            //Singleton.increment();


            //string health1 = health.ToString();
            //string health2String = health2.ToString();
            //int a = Singleton.number;


            //CFoo foo1 = new CFoo();
            //CFoo foo2 = new CFoo();

            //foo1.val = 10;
            //foo2.val = 50;

            // Console.WriteLine(foo1.val);
            //Console.WriteLine(foo2.val);


            // Where code is run.
            //// Class definition and declarations have to happen in main.
            //myClass MyClass = new myClass();
            //int answer = MyClass.simpleAdditionFunction(health, 4);

            //Console.Write(answer);
            //string name = Console.ReadLine();
            //Console.Write("Hello " + name);
            //Console.Write(health1, health2String);



            while (true) ; // keeps the console window open


            

        }

       
    }
}
