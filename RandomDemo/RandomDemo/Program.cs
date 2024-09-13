using System.Globalization;
using System.Text;

namespace RandomDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            //string[] input = Console.ReadLine().Split().ToArray();
            //int counter = 0;

            //while (true)
            //{
            //    for (int i = 0; i < input.Length; i++)
            //    {
            //        sb.Append(input[random.Next(0, input.Length)] + " ");
            //    }
            //    counter++;

            //    if (sb.ToString().TrimEnd() == string.Join(" ", input))
            //    {
            //        Console.WriteLine(counter);
            //        break;
            //    }
            //    sb.Clear();
            //}

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next());

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(10, 101));

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(100, 101));

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(-100, 100));

            //Random randomWithSeed = new Random(5);

            //for (int i = 0; i < 10; i++)
            //Console.WriteLine(randomWithSeed.Next(20));

        
            string inputDate = Console.ReadLine()!;

            DateTime dateTime;

            //dateTime = DateTime.ParseExact(inputDate!, "d-M-yyyy", CultureInfo.InvariantCulture);

            //dateTime = new DateTime(int.Parse(inputDate.Split("-")[2]), 
            //    int.Parse(inputDate.Split("-")[1]), 
            //    int.Parse(inputDate.Split("-")[0]));

            bool isOk = DateTime.TryParseExact(inputDate, 
                "d-M-yyyy", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out dateTime);
            
            Console.WriteLine(dateTime.DayOfWeek);
            

            
        
        
        }
    }
}
