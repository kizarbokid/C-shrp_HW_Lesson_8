/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

System.Console.Clear();
// ввод значений с клавиатуры
string ToInputVar(string input_text)
{
    Console.Write($"Введите {input_text} и нажмите Enter: ");
    string result = Console.ReadLine();
    return result;
}
// заполнение двумерной таблицы рандомными целыми числами
int[,] ToFillTable(int n, int m)
{
    int[,] table = new int[n, m];
    var rand = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        { table[i, j] = rand.Next(0, 10); }
    }
    return table;
}

// вывод на печать таблицы
void ToPrintTable(int[,] table)
{
    int rows = table.GetUpperBound(0) + 1;    // количество строк
    int columns = table.Length / rows;        // количество столбцов
    for (int i = 0; i < rows; i++)
    {
        Console.Write($"{i + 1}-я:  ");
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"{table[i, j]}    ");
        }
        Console.WriteLine();
    }
}

//сортировка пузырьком
int[] ToBubbleSort(int[] array)
{
    var len = array.Length;
    for (var i = 1; i < len; i++)
    {
        for (var j = 0; j < len - i; j++)
        {
            if (array[j] < array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }

    return array;
}
// записать заданную строку таблицы в одномерный массив
int[] ToPutRowInArray(int[,] table, int rownum)
{
    int columns = table.GetLength(1);      // количество столбцов
    int[] array = new int[columns];
    for (int j = 0; j < columns; j++)
    {
        array[j] = table[rownum, j];
    }
    return array;
}
// совершить обратную операцию, заменить определенную строку таблицы элементами одномерного массива
int[,] ToPutArrayInRow(int[,] table, int rownum, int[] array)
{
    int columns = table.GetLength(1);
    for (int j = 0; j < columns; j++)
    {
        table[rownum, j] = array[j];
    }
    return table;
}


string input_text = "количество строк таблицы";
int n = int.Parse(ToInputVar(input_text));
input_text = "количество столбцов таблицы";
int m = int.Parse(ToInputVar(input_text));
int[,] table = ToFillTable(n, m);
ToPrintTable(table);

for (int i = 0; i < n; i++)
{
    int[] temparray = ToPutRowInArray(table, i);
    ToBubbleSort(temparray);
    table = ToPutArrayInRow(table, i, temparray);
}
Console.WriteLine("Сортировка пузырьком:");
ToPrintTable(table);