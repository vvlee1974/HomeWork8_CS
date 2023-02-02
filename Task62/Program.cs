/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:

01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

/* АЛГОРИТМ
1. Двигаемся по периметру квадрата "вправо - вниз - влево - вверх" до тех пор, пока есть пустые ячейки. (while -> for -> for)
2. После каждого полного прохода квадрата длина каждой стороны следующего квадрата уменьшаются на 2 позиции.
3. При каждом прохо;дении стороны квадрата включается счётчик соответствующей стороны. (x, y) 
*/
int GetNumber(string message)
{
    int result = 0;

    Console.Write(message);

    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Введено не число. Повторите ввод: ");
        }
    }
    return result;
}

int[,] InitSnakeArray(int rowsX, int columnsY)
{
    int[,] array = new int[rowsX, columnsY];

    int product = rowsX * columnsY;
    int x = 0;
    int y = 0;
    int count = 1;

    while (count <= product)
    {
        for (int i = 0; i < 4; i++)// вправо-вниз-влево-вверх
        {
            for (int j = 0; j < ((rowsX < columnsY) ? columnsY : rowsX) ; j++)
            {
                if (i == 0 && j < columnsY - y )
                    array[i + x, j + y] = count++;

                if (i == 1 && j < rowsX - x && j != 0 )
                    array[j + x, columnsY - 1] = count++;

                if (i == 2 && j < columnsY - y && j != 0 )
                    array[rowsX - 1, columnsY - (j + 1)] = count++;

                if (i == 3 && j < rowsX - (x + 1) && j != 0 )
                    array[rowsX - (j + 1), x] = count++;
            }
        }
        rowsX--;
        columnsY--;
        x += 1;
        y += 1;
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
                Console.Write($" {array[i, j]} ");
            else
                Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int rowsX = GetNumber("Введите количество строк: ");
int columnsY = GetNumber("Введите количество столбцов: ");

int[,] arr = InitSnakeArray(rowsX, columnsY);

PrintArray(arr);