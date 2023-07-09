// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortSingleArray(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        int minPosition = i;

        for (int j = i + 1; j < arr.Length; j++)
        {
            if(arr[j] < arr[minPosition]) minPosition = j;
        }

        int temporary = arr[i];
        arr[i] = arr[minPosition];
        arr[minPosition] = temporary;
    }

    //Console.WriteLine(String.Join(", ", arr));
}

void SortRowsArray(int[,] array)
{
    int[] rowArray = new int[array.GetLength(1)];
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            rowArray[j] = array[i, j];
        }
        SortSingleArray(rowArray);
        Console.WriteLine(String.Join(" ", rowArray));
    }
}
