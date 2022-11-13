/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
 */
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
    int rows = table.GetLength(0);    // количество строк
    int columns = table.GetLength(1);        // количество столбцов
    for (int i = 0; i < rows; i++)
    {
        //Console.Write($"{i + 1}-я:  ");
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"{table[i, j]}  ");
        }
        Console.WriteLine();
    }
}
int[] ToFindIRowFromMatrixA(int[,] matrix, int i) //найти i-ую строку в матрице А
{
    int columns = matrix.GetLength(1);
    int[] array = new int[columns];
    for (int j = 0; j < columns; j++)
    {
        array[j] = matrix[i, j];//записать в одномерный массив i-ую строку матрицы
    }
    return array;
}
int[] ToFindJColumnFromMatrixB(int[,] matrix, int j) //найти j-ый столбец в матрице B
{
    int rows = matrix.GetLength(0);
    int[] array = new int[rows];
    for (int i = 0; i < rows; i++)
    {
        array[i] = matrix[i, j];//записать в одномерный массив j-ый столбец матрицы
    }
    return array;
}
//найти произведение векторов 
int ToMultiplyVectors(int[] array1, int[] array2)
{
    int product;
    int sum=0;
    for (int i = 0; i < array1.Length; i++)
    {
        product = array1[i] * array2[i];
        sum = sum + product;
    }
    return sum;
}
//найти произведение матриц
int[,] ToMultiplyMatrix(int[,] matrixA,int[,] matrixB)
{
int rows1 = matrixA.GetLength(0);
int rows2 = matrixB.GetLength(0);
int columns1 = matrixA.GetLength(1);
int columns2 = matrixB.GetLength(1);
if (columns1 == rows2)
{
    int[,] matrixC = new int[rows1, columns2]; // размерность результирующей матрицы
    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < columns2; j++)
        {
            matrixC[i, j] = ToMultiplyVectors(ToFindIRowFromMatrixA(matrixA,i),ToFindJColumnFromMatrixB(matrixB,j));
        }
    }
        return matrixC;
}
else
{
    Console.WriteLine("Матрицы несовместимы, количество столбцов матрицы А должно быть равным количеству строк матрицы В!");
    return null;
}
}
string input_text = "количество строк матрицы A";
int n1 = int.Parse(ToInputVar(input_text));
input_text = "количество столбцов матрицы A";
int m1 = int.Parse(ToInputVar(input_text));
int[,] matrixA = ToFillTable(n1, m1);
ToPrintTable(matrixA);

input_text = "количество строк матрицы B";
int n2 = int.Parse(ToInputVar(input_text));
input_text = "количество столбцов матрицы B";
int m2 = int.Parse(ToInputVar(input_text));
int[,] matrixB = ToFillTable(n2, m2);
ToPrintTable(matrixB);
int[,] matrixC=ToMultiplyMatrix(matrixA,matrixB);
Console.WriteLine("Произведение матриц А и В");
ToPrintTable(matrixC);
