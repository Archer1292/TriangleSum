using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TriangleSum
{
    class MaxSumFinder
    {
        string FilePath;
        int[][] TriangleArr;// треугольник
        
        public MaxSumFinder(string filePath) {
            FilePath = filePath;
        }
        /// <summary>
        /// читает из файла и создает масив-треугольник
        /// </summary>
        private void GetTriangleArr(){       
         try
            {               
                string[] lineArr = File.ReadAllLines(FilePath);
                TriangleArr = new int[lineArr.Length][];
                for (int i = 0; i < lineArr.Length; i++)
                {
                    TriangleArr[i] = lineArr[i].Split(' ').Select(n => int.Parse(n)).ToArray();
                }    
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                TriangleArr = null;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            
                TriangleArr = null;

            }
            catch
            {
                Console.WriteLine("Failed to read the file");
                TriangleArr = null;
            }

}

        /// <summary>
        /// проверяет правильность входящих данных(действиельно ли получается треугольник: кажды ряд имеет на 1 больше элементов)
        /// </summary>
        /// <returns></returns>
        private bool IsTriangleCorrect()
        {

            if (TriangleArr == null) return false;
            else
            for (int i = 0; i < TriangleArr.Length; )
            {
                if (TriangleArr[i].Length != ++i)
                {
                    TriangleArr = null;
                    Console.WriteLine("The input data does not match the triangle");
                    return false;
                }
                
            }
            return true;
        }

        /// <summary>
        /// возвращает наибольшую сумму 
        /// </summary>
        /// <returns></returns>
        public int FindMaxSum()
        {
            GetTriangleArr();
            if (IsTriangleCorrect())
            try
            {
                for (int i = TriangleArr.Length - 2; i > -1; i--)
                {
                    for (int j = 0; j < TriangleArr[i].Length; j++)
                    {
                        TriangleArr[i][j] = TriangleArr[i][j] + Math.Max(TriangleArr[i + 1][j], TriangleArr[i + 1][j + 1]);
                    }
                }
               
                return TriangleArr[0][0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index Out Of Range Exception, check the entered data");
                return -1;
            }

            return -1;

        }
        
    }
}
