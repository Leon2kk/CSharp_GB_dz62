using System.Collections.Generic;

namespace seminar8
{
    // Задача 62. Заполните спирально массив 4 на 4.
    // Например, на выходе получается вот такой массив:
    // 1 2 3 4
    // 12 13 14 5
    // 11 16 15 6
    // 10 9 8 7
    class dz62
    {
        public static void Main()
        {
            Console.Clear();

            //определяем размерность            
            int m = 7, n = 7;

            int[,] mas= new int[m, n];

            //Заполняем массив из списка
            ArrayFilling(mas);

            //Выводим массив
            ArrayToPrint(mas, ConsoleColor.DarkYellow);

            Console.WriteLine("The end ....");
        }

        public static void ArrayFilling(int[,] mas)
        {
            bool isToRight = false,
                  isToLeft = false,
                  isToUp   = false,
                  isToDown = false;
            
            int left  = 0,
                right = mas.GetLength(1) - 1,
                top   = 0,
                down  =  mas.GetLength(0) - 1;
            
            int increment = 0;

            isToRight = true;

            while (increment < mas.GetLength(0) * mas.GetLength(1))
            {                   
                if (isToRight)
                {
                    for (int j = left; j <= right; j++)
                    {
                        mas[top, j] = ++increment;
                    }
                    top++;
                    isToRight = false;
                    isToDown = true;
                }

                if (isToDown)
                {
                    for (int i = top; i <= down; i++)
                    {
                        mas[i, right] = ++increment;
                    }
                    right--;
                    isToDown = false;
                    isToLeft = true;
                }

                if (isToLeft)
                {
                    for (int j = right; j >= left; j--)
                    {
                        mas[down, j] = ++increment;
                    }
                    down--;
                    isToLeft = false;
                    isToUp = true;
                }


                if (isToUp)
                {
                    for (int i = down; i >= top; i--)
                    {
                        mas[i, left] = ++increment;
                    }
                    
                    left++;
                    isToUp = false;
                    isToRight = true;
                }

                ArrayToPrint(mas, ConsoleColor.Green);

                Console.ReadKey();
            }

        }


        public static void ArrayToPrint(int[,] mas, ConsoleColor color = ConsoleColor.Gray)
        {   
            Console.Clear();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {                    
                   if (mas[i, j] > 0)
                   {
                        Console.ForegroundColor = color;
                   }

                   Console.Write($"{mas[i, j]}\t");
                   Console.ResetColor();

                }
                Console.WriteLine();
            }
        }
    }
}
