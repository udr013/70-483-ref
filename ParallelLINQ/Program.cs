using System;
using System.Collections;
using System.Linq;

namespace ParallelLINQ
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        public static bool CheckCity(string name)
        {
            if (name == "")
            {
                throw new ArgumentException(name);
            }
            return true;
        }

        static void Main(string[] args)
        {

            Person[] people = new Person[]
            {
            new Person { Name = "Alan", City = "Hull"},
            new Person { Name = "Bery", City = "Seattle"},
            new Person { Name = "Charles", City = "London"},
            new Person { Name = "David", City = "Seattle"},
            new Person { Name = "Eddy", City = "Paris"},
            new Person { Name = "Fred", City = "Seattle"},
            new Person { Name = "Gordon", City = "Hull"},
            new Person { Name = "Henry", City = "Seattle"},
            new Person { Name = "Isaac", City = "Seatlle"},
            new Person { Name = "James", City = ""},
            new Person { Name = "Kim", City = "Seattle"}
            };
            // LINQ Language-INtegrated-Query
            //AsParallel will determine if run in parallel will speed things up or not and do so
            ParallelQuery<Person> result = from person in people.AsParallel() where person.City == "Seattle" select person;

            foreach (Person person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("-----------------");

            result = from person in people.AsParallel().
                     // use a max of four cpu's
                     WithDegreeOfParallelism(4).
                     //force paralism if improving or not
                     WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                     where person.City == "Seattle"
                     select person;

            foreach (Person person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("-----------------");

            result = from person in people.AsParallel()
                     //using AsOrdered to preserve data ordering
                     .AsOrdered()
                     where person.City == "Seattle"
                     select person;

            foreach (Person person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("-----------------");

            //Note diff resulttype
            IEnumerable bla = (from person in people.AsParallel()
                       where person.City == "Seattle"
                       orderby (person.Name)
                       select new
                       {
                           Name = person.Name
                       })
                          //use AsSequential to preserve ordering before the take
                          .AsSequential().Take(4);

            foreach (var person in bla)

            {
                Console.WriteLine(person);
            }

            Console.WriteLine("-----------------");

            result = from person in people.AsParallel() where person.City == "Seattle" select person;
            // ForAll IS parallel by nature unlike forEach and will run before the query is complete, thus will not reflect input order
            result.ForAll(person => Console.WriteLine(person.Name));

            Console.WriteLine("-----------------");

            try
            {
                result = from person 
                         in people.AsParallel()
                         where CheckCity(person.City)
                         select person;

                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            }
 

            Console.WriteLine("Hit any button to exit");
            Console.ReadKey();
        }


    }
}
