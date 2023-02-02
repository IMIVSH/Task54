// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.Clear();

int GetDataFromUser(string message)
{
    PrintInColor(message, ConsoleColor.Blue);
    int result = int.Parse(Console.ReadLine()!);
    Console.WriteLine();
    return result;
}

void PrintInColor(string data, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(data);
    Console.ResetColor();
}

int[,] Get2DDoubleArray(int colLength, int rowLength, int start, int finish)
{
    int[,] array = new int[colLength, rowLength];
    for (int i = 0; i < colLength; i++)
    {
        for (int j = 0; j < rowLength; j++)
        {
            array[i, j] = new Random().Next(start, finish + 1);
        }
    }
    return array;
}

void Print2DArray(int[,] array)
{
    Console.Write(" \t");
    for (int j = 0; j < array.GetLength(1); j++)
    {
        PrintInColor(j + "\t", ConsoleColor.Green);
    }
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        PrintInColor(i + "\t", ConsoleColor.Green);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] OrderedArray(int[,] array)
{
    Console.WriteLine();
    int curcles = 0;
    while(curcles < array.GetLength(1))
    {
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1)-1; j++)
        {
                if (array[i, j] < array[i, j+1])
            {
                int change = array[i, j];
                array[i, j] = array[i, j+1];
                array[i, j+1] = change;
            }
        }
    }
    curcles++;
    }
    return array;
}

int m = GetDataFromUser("Введите количество строк: ");
int n = GetDataFromUser("Введите количество столбцов: ");
int[,] array = Get2DDoubleArray(m, n, 0, 10);
Print2DArray(array);
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Упорядоченный массив: ");
Console.ResetColor();
int[,] arrayInOrder = OrderedArray(array);
Print2DArray(arrayInOrder);