namespace _7.Folkeskole
{
    class School
    {
        public string Name {get; set;}
        public string City {get; set;}

        public School(string name, string city)
        {
            Name = name;
            City = city;
        }

        override
        public string ToString()
        {
            return $"Name: {Name}\nCity: {City}";
        }
    }
}
