// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int m = EnterNumberInt("Введите количество строк: ");
int n = EnterNumberInt("Введите количество столбцов: ");
int[,] array = new int[n, m];
PrintArray(array);
//FillArraySpiral(0, 0, 1);
FillArraySpiral2(array);
PrintArray(array);


int EnterNumberInt(string message)
{
    int num = 0;
    Console.Write(message);
    while(!int.TryParse(Console.ReadLine(), out num))
        Console.WriteLine("Введите число!");
    return num;
}

void PrintArray (int[,] arr)
{
    Console.WriteLine();
    //Console.WriteLine($"m = {arr.GetLength(0)}, n = {arr.GetLength(1)}");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(string.Format("{0:00}", arr[i, j]) + " ");
        }
        Console.WriteLine();
    }
}

void FillArraySpiral(int iCurrent, int jCurrent,int currentElement)
{
    if(iCurrent < n 
       && jCurrent < m 
       && iCurrent >= 0
       && jCurrent >= 0
       && array[iCurrent, jCurrent] == 0)
    {
        array[iCurrent, jCurrent] = currentElement;
        // iCurrent++;
        // jCurrent++;
        currentElement++;
        if(iCurrent - 1 > 0)
        {
            FillArraySpiral(iCurrent - 1, jCurrent, currentElement);
        }
        FillArraySpiral(iCurrent, jCurrent + 1, currentElement);
        FillArraySpiral(iCurrent + 1, jCurrent, currentElement);
        FillArraySpiral(iCurrent, jCurrent - 1, currentElement);
    }
    
}

void FillArraySpiral2(int[,] array)
{
    int iMin = 0;
    int iMax = array.GetLength(0) - 1;
    int jMin = 0;
    int jMax = array.GetLength(1) - 1;
    int element = 1;

    while (iMin <= iMax && jMin <= jMax)
    {
        for (int j = jMin; j <= jMax; j++)
        {
            array[iMin, j] = element++;    
        }
        iMin++;

        for (int i = iMin; i <= iMax; i++)
        {
            array[i, jMax] = element++;
        }
        jMax--;

        for (int j = jMax; j >= jMin; j--)
        {
            array[iMax, j] = element++;
        }
        iMax--;

        for (int i = iMax; i >= iMin; i--)
        {
            array[i, jMin] = element++;
        }
        jMin++;
    }    
}