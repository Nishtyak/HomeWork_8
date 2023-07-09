// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int m = EnterNumberInt("Введите количество строк: ");
int n = EnterNumberInt("Введите количество столбцов: ");
int min = EnterNumberInt("Введите минимальное число: ");
int max = EnterNumberInt("Введите максимальное число: ");
int[,] array = FillArray(m, n, min, max);
PrintArray(array);
Console.WriteLine();
SortRowsArray(array);

int EnterNumberInt(string message)
{
    int num = 0;
    Console.Write(message);
    while(!int.TryParse(Console.ReadLine(), out num))
        Console.WriteLine("Введите число!");
    return num;
}

int[,] FillArray(int m, int n, int min, int max)
{
    int[,] arr = new int[m, n];
    Random random = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = random.Next(min, max + 1);
        }
    }
    return arr;
}

void PrintArray (int[,] arr)
{
    Console.WriteLine();
    //Console.WriteLine($"m = {arr.GetLength(0)}, n = {arr.GetLength(1)}");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}

void SortRowsArray(int[,] array)
{
    int[] rowSum = new int[array.GetLength(0)];
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        rowSum[i] = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            rowSum[i] += array[i, j];
        }
    }
    
    int indexMinRow = FindIndexMin(rowSum);
    //Console.WriteLine(String.Join(" ", rowSum));
    Console.WriteLine($"Строка с наименьшей суммой элементов: {indexMinRow}");
}

int FindIndexMin(int[] array)
{
    int min = array[0];
    int indexMin = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if(array[i] < min) 
        {
            min = array[i];
            indexMin = i;
        }
    }
    return indexMin;
}

