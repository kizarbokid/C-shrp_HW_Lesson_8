/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента. */

System.Console.Clear();
// ввод значений с клавиатуры
string ToInputVar(string input_text)
{
    Console.Write($"Введите {input_text} и нажмите Enter: ");
    string result = Console.ReadLine();
    return result;
}
// заполнение трехмерного массива рандомными целыми числами
int[,,] ToFill3DArray(int l, int m, int n)
{
    int[,,] array = new int[l, m, n];
    var rand = new Random();
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                array[i, j, k] = rand.Next(10, 100);
            }
        }
    }
    return array;
}
// вывод на печать 3D массива
void ToPrint3DArray(int[,,] array)
{
    int dim1 = array.GetLength(0);
    int dim2 = array.GetLength(1);
    int dim3 = array.GetLength(2);
    Console.WriteLine();
    for (int i = 0; i < dim1; i++)
    {
        for (int j = 0; j < dim2; j++)
        {
            for (int k = 0; k < dim3; k++)
            {
                Console.Write($"{array[i, j, k]}({i + 1},{j + 1},{k + 1})   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
string input_text = "количество элементов 1 измерения массива";
int l = int.Parse(ToInputVar(input_text));
input_text = "количество элементов 2 измерения массива";
int m = int.Parse(ToInputVar(input_text));
input_text = "количество элементов 3 измерения массива";
int n = int.Parse(ToInputVar(input_text));
int[,,] array = ToFill3DArray(l, m, n);
ToPrint3DArray(array);