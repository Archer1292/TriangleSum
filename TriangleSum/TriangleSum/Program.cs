using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TriangleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Рассчитать самую большую сумму треугольника по основанию.");
            string filePath = "../../../Redirecting.txt";
            MaxSumFinder max1 = new MaxSumFinder(filePath);
            Console.WriteLine("Максимальная сумма по треугольнику - "+ max1.FindMaxSum());

            Console.WriteLine("Дополнительное задание.");
            filePath = "../../../RedirectingHard.txt";
            MaxSumFinder max2 = new MaxSumFinder(filePath);
            Console.WriteLine("Максимальная сумма по треугольнику - "+ max2.FindMaxSum());
            Console.ReadKey();
        }
       

        
    }
}
