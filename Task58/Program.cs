/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int[,] InitMatrixA(int rowA, int columnsA)
{
    int[,] array = new int[rowA, columnsA];
    Random rnd = new Random();

    for (int i = 0; i < rowA; i++)
    {
        for (int j = 0; j < columnsA; j++)
        {
            array[i, j] = rnd.Next(1, 10);
        }
    }
    return array;
}

int[,] InitMatrixB(int rowB, int columnsB)
{
    int[,] array = new int[rowB, columnsB];
    Random rnd = new Random();

    for (int i = 0; i < rowB; i++)
    {
        for (int j = 0; j < columnsB; j++)
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

int[,] ProductOfMatrix(int[,] arrayA, int[,] arrayB)
{
    int[,] product = new int[arrayA.GetLength(0), arrayB.GetLength(1)];

    for (int i = 0; i < product.GetLength(0); i++)
    {
        for (int j = 0; j < product.GetLength(1); j++)
        {
            int temp = 0;
            for (int k = 0; k < arrayA.GetLength(1); k++)
            {
                temp += arrayA[i, k] * arrayB[k, j];
            }
            product[i, j] = temp;
        }
    }
    return product;
}

int[,] arrayA = InitMatrixA(2, 2);
int[,] arrayB = InitMatrixB(2, 2);

Console.WriteLine();
PrintArray(arrayA);
Console.WriteLine();
PrintArray(arrayB);
Console.WriteLine();
int[,] product = ProductOfMatrix(arrayA, arrayB);
Console.WriteLine("Результирующая матрица: ");
PrintArray(product);