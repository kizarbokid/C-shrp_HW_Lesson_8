/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7 */

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
            Console.Write($"{table[i, j]}  ");
        }
        Console.WriteLine();
    }
}
//подсчет суммы строк и запись их в одномерный массив
int[] ToCountSums(int[,] table)
{
    int rows = table.GetLength(0);
    int columns = table.GetLength(1);
    int[] sums = new int[rows];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sums[i] = sums[i] + table[i, j];
        }
    }
    return sums;
}
// поиск минимального элемента в массиве
int TofindMinInArray(int[] array)
{
    int min = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[min] > array[i]) min = i;
    }
    return min;
}
string input_text = "количество строк таблицы";
int n = int.Parse(ToInputVar(input_text));
input_text = "количество столбцов таблицы";
int m = int.Parse(ToInputVar(input_text));
int[,] table = ToFillTable(n, m);
ToPrintTable(table);
int[] sums = ToCountSums(table);
int minnum=TofindMinInArray(sums);
Console.WriteLine("Строка с наименьшей суммой элементов: " + (minnum+1)+"-я;");
Console.WriteLine("Сумма элементов строки: "+(sums[minnum])+";");