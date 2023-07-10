// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int m1 = EnterNumberInt("Введите количество строк первой матрицы: ");
int n1 = EnterNumberInt("Введите количество столбцов первой матрицы: ");
int m2 = n1;
int n2 = EnterNumberInt("Введите количество столбцов второй матрицы: ");
int min = EnterNumberInt("Введите минимальное число: ");
int max = EnterNumberInt("Введите максимальное число: ");
int[,] array1 = FillArray(m1, n1, min, max);
int[,] array2 = FillArray(m2, n2, min, max);
Console.WriteLine();
Console.WriteLine("Первая матрица: ");
PrintArray(array1);
Console.WriteLine("Вторая матрица: ");
PrintArray(array2);
int[,] multipliedArray = MultiplyArrays(array1, array2);
Console.WriteLine("Результат: ");
PrintArray(multipliedArray);

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
    //Console.WriteLine();
    //Console.WriteLine($"m = {arr.GetLength(0)}, n = {arr.GetLength(1)}");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MultiplyArrays(int[,] array1, int[,] array2)
{
    int[,] multipliedArray = new int[array1.GetLength(0), array2.GetLength(1)];

    for (int i = 0; i < multipliedArray.GetLength(0); i++)
    {
        for (int j = 0; j < multipliedArray.GetLength(1); j++)
        {
            multipliedArray[i, j] = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                multipliedArray[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }
    return multipliedArray;
}
