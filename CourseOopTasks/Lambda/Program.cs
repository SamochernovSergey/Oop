using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Ivan", 13),
                new Person("Ivan", 21),
                new Person("Andrey", 21),
                new Person("Igor", 23),
                new Person("Elena", 23),
                new Person("Elena", 25),
                new Person("Veronicka", 19),
                new Person("Oleg", 54),
                new Person("Oleg", 16),
                new Person("Evgeniy", 18),
                new Person("Radick", 11)
            };

            Console.WriteLine("Оригинальный список: ");
            Console.WriteLine(string.Join(",", persons));

            List<string> unicalNamesString = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Список уникальных имён: ");
            Console.WriteLine("Имена:" + string.Join(",", unicalNamesString));

            List<Person> youngPeople = persons
                .Where(p => p.Age < 18)
                .ToList();

            Console.WriteLine("Список людей младше 18 лет");
            Console.WriteLine(string.Join(",", youngPeople));

            double youngPeoplesAverage = youngPeople
               .Average(p => p.Age);

            Console.WriteLine("Средний возраст = {0}", youngPeoplesAverage);

            Dictionary<string, double> personsByAge = persons
                .GroupBy(p => p.Name)
                .ToDictionary(x => x.Key, x => x.Average(p => p.Age));

            Console.WriteLine("Словарь содержит: ");

            foreach (var e in personsByAge)
            {
                Console.WriteLine(e);
            }

            List<string> people = persons
                .Where(p => p.Age > 20 && p.Age < 45)
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name)
                .ToList();

            Console.WriteLine("Список имён людей c возрастом старше 20 лет и моложе 45 лет отсортированных в порядке убывания возраста");
            Console.WriteLine(string.Join(",", people));

            Console.WriteLine("Введите колличество элементов");

            int digit = Convert.ToInt32(Console.ReadLine());

            foreach (double n in GetSqrt().Take(digit))
            {
                Console.WriteLine(n);
            }
        }

        public static IEnumerable<double> GetSqrt()
        {
            int i = 0;
            while (true)
            {
                yield return Math.Sqrt(i);
                ++i;
            }
        }
    }
}