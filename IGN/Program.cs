using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGN
{
    class Program
    {
        static void Main()
        {
            Person person = new Person
            {
                Name = "John",
                Age = 30,
                Hobbies = new List<string> { "Reading", "Cycling" }
            };

            string result = ClassHelper.GetPropertiesAndValues(person);
            Console.WriteLine(result);
        }
    }
}
