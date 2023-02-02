/* Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int[,] InitMatrix(int rows, int columns)
{
    int[,] array = new int[rows, columns];

    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = rnd.Next(1, 10);
        }
    }

    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[] SumRowsOfMatrix(int[,] matrix)
{
    int[] sum = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sumrow = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumrow += matrix[i, j];

            sum[i] = sumrow;
        }
        Console.WriteLine($"Сумма чисел в строке {i + 1} = {sum[i]} ");
    }
    return sum;
}

int GetMinSum(int[] array)
{
    int minsum = array[0];

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < minsum) minsum = array[i];
    }
    Console.WriteLine();
    
    return minsum;
}

int rows = 4;
int columns = 4;

int[,] matrix = InitMatrix(rows, columns);

PrintArray(matrix);
Console.WriteLine();

int[] sum = SumRowsOfMatrix(matrix);

int index = Array.IndexOf(sum, sum.Min());
int minsum = GetMinSum(sum);

Console.WriteLine($"Минимальная сумма чисел в строке {index + 1} = {minsum} ");