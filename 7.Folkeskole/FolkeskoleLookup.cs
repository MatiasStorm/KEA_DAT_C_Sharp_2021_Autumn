using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace _7.Folkeskole
{
    class FolkeskoleLookup 
    {
        private string schoolName = "";
        private static readonly string folderPath = Environment.CurrentDirectory;
        private List<School> schools = new List<School>();
        private int startCol;

        public FolkeskoleLookup(){
            readData();
        }

        private void readData(){
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);  // Needed to handle the 1252 encoding of folkeskole.csv, also install nuget package: System.Text.Encoding.CodePages
            CultureInfo pt = CultureInfo.GetCultureInfo("da-DK");                                   // Get the danish culture info
            Encoding encoding = Encoding.GetEncoding(pt.TextInfo.ANSICodePage);                     // Extract the encoding 
            StreamReader file = new StreamReader(folderPath + "/folkeskole.csv",encoding , true); 
            string line, schoolName, schoolCity;
            string[] splitLine;
            file.ReadLine(); // Skip the first line, defines the structure
            while ((line = file.ReadLine()) != "")
            {
                splitLine = line.Split(';');
                schoolName = splitLine[2];
                schoolCity = splitLine[6];
                schools.Add(new School(schoolName, schoolCity));
            }
            file.Close();
        }

        public void Run()
        {
            ConsoleKeyInfo key;
            bool hinting = true;
            Console.Write("Type school name: ");
            (int col, int row) = Console.GetCursorPosition();
            startCol = col;
            while (hinting) 
            {
                key = Console.ReadKey();
                hinting = keyHandler(key);
                updateHint(picked: hinting ? false : true);
            }
            Console.WriteLine("\nThe School you picked was:\n" + getMatchingSchool().ToString());
        }

        private bool keyHandler(ConsoleKeyInfo key)
        {
            switch(key.Key)
            {
                case ConsoleKey.Enter:
                    return false;
                case ConsoleKey.Backspace:
                    if (schoolName.Length > 0)
                    {
                        schoolName = schoolName.Substring(0, schoolName.Length - 1);
                    }
                    break;
                default:
                    schoolName += key.KeyChar;
                    break;
            }
            return true;
        }

        private void ClearLineFrom(int col, int row)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(new String(' ', Console.WindowWidth - col));
            Console.SetCursorPosition(col, row);
        }

        private void updateHint(bool picked = false){
            School schoolHint = getMatchingSchool();
            ( int col, int row ) = Console.GetCursorPosition();
            ClearLineFrom(startCol, row);
            if (schoolHint == null)
            {
                Console.Write(schoolName);
            }
            else 
            {
                Console.Write(schoolHint.Name.Substring(0, schoolName.Length));
                if ( !picked ) Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(schoolHint.Name.Substring(schoolName.Length));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private School getMatchingSchool()
        {
            return schools.Find(s => s.Name.ToLower().StartsWith(schoolName.ToLower()));
        }
    }
}
