using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    internal class Person
    {
        public string Name;
        public int Age;
        public List<string> Hobbys = new List<string>();

        public override string ToString()
        {
            return $"{Name} is {Age} and likes {String.Join(", ", Hobbys)}";
            Console.ReadLine(); 
        }
    }
}
