using System;

namespace triangleArea
{
    class TriangleCalculator 
    {
        public void run()
        {

            Console.WriteLine("Welcome to the trigale area calculator!\n");
            int b = ReadInt("Triangle base: ");
            int h = ReadInt("Triangle height: ");
            Triangle triangle = new Triangle(b, h);
            Console.WriteLine("\nThe area of the triangle is " + triangle.area);
        }

        public int ReadInt(string msg)
        {
            Console.Write(msg);
            string input = Console.ReadLine();
            int val;
            while(!int.TryParse(input, out val))
            {
                Console.WriteLine("Invalid input...");
                Console.Write(msg);
                input = Console.ReadLine();
            }
            return val;
        }


    }
}

