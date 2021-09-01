using System;

namespace printAPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("The character used in the triangle: ");
            char character = Convert.ToChar(Console.ReadLine());

            Console.Write("The height of the triangle: ");
            int height = Convert.ToInt32(Console.ReadLine());

            int row = 1;
            string line;

            for(int i = 0; i < height; i++ ){
                line = "";
                line += new String(' ', height-i);
                line += new String(character, row + i);
                line += new String(' ', height-i);

                Console.WriteLine(line);
                row++;
            }
        }
    }
}
