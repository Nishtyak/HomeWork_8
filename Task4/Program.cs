// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[] sizes = EnterSizes();if(sizes[0] * sizes[1] * sizes[2] < 90)
{
    int[,,] array = FillArray(sizes);
    PrintArray(array);
}
else Console.WriteLine("С такими размерами невозможно создать трехмерный массив с неповторяющимися элементами!");

int[] EnterSizes()
{
    int dimention = 3;

    string input;
    int[] sizes = new int[dimention];
    Console.Write("Введите размеры трехмерного массива через пробел: ");
    input = Console.ReadLine();
    var tempMassiv = input.Split(' ');
    for(int i = 0; i < tempMassiv.Length; i++)
    {
        sizes[i] = int.Parse(tempMassiv[i]);
    }
    
    return sizes;
}

int[,,] FillArray(int[] sizes)
{
    int[,,] array = new int[sizes[0], sizes[1], sizes[2]];
    Random random = new Random();
    int tempElement;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                tempElement = 0;
                while(CheckRepeat(array, i, j, k, tempElement))
                {
                    tempElement = random.Next(10, 100);
                }
                array[i, j, k] = tempElement;
            }
        }
    }
    return array;
}

bool CheckRepeat(int[,,] array, int iCurrent, int jCurrent, int kCurrent, int element)
{
    if(element == 0) return true;
    for (int i = 0; i <= iCurrent; i++)
    {
        for (int j = 0; j <= jCurrent; j++)
        {
            for (int k = 0; k <= kCurrent; k++)
            {
                if(element == array[i, j, k])
                {
                    return true;
                }
            }
        }
    }
    return false;
}

void PrintArray (int[,,] arr)
{
    //Console.WriteLine();
    //Console.WriteLine($"m = {arr.GetLength(0)}, n = {arr.GetLength(1)}");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                Console.WriteLine($"{arr[i, j, k]} ({i}, {j}, {k})");
            }
        }
    }
}
