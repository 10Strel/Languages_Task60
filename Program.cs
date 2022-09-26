/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int dimension0 = 0, dimension1 = 0, dimension2 = 0;
Random random = new Random();
List<int> existsNumbers = new List<int>();

if (!InputControl("Задайте размерность трехмерного массива (l m n)", ref dimension0, ref dimension1, ref dimension2))
    return;

int[,,] array = InitArray(dimension0, dimension1, dimension2);

PrintArray(array);


# region methods

bool InputControl(string caption, ref int l, ref int m, ref int n)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck =
            inputStringArray.Length == 3 &&
            int.TryParse(inputStringArray[0], out l) &&
            l > 0 &&
            int.TryParse(inputStringArray[1], out m) &&
            m > 0 &&
            int.TryParse(inputStringArray[2], out n) &&
            n > 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,,] InitArray(int l, int m, int n)
{
    int[,,] array = new int[l, m, n];

    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                array[i, j, k] = GetRandom();
            }
        }
    }

    return array;
}

void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]} ({i},{j},{k})\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int GetRandom()
{
    int newNumber = 0;
    bool isExists = true;

    while (isExists)
    {
        newNumber = random.Next(10, 100);

        isExists = existsNumbers.IndexOf(newNumber) > 0;

        if (!isExists)
        {
            existsNumbers.Add(newNumber);
            continue;
        }
    }

    return newNumber;
}

# endregion




