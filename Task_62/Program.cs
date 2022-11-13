/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

System.Console.Clear();
// ввод значений с клавиатуры
string ToInputVar(string input_text)
{
    Console.Write($"Введите {input_text} и нажмите Enter: ");
    return Console.ReadLine(); ;
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
string input_text = "количество строк таблицы";
int downbound = int.Parse(ToInputVar(input_text));
input_text = "количество столбцов таблицы";
int rightbound = int.Parse(ToInputVar(input_text));
int[,] table = new int[downbound, rightbound];

int i = 0;
int j = 0;
string direction = "right";
int leftbound = -1;
int upperbound = 0;

for (int count = 1; count < table.Length + 1; count++) // заполнить двумерный массив числами от 1 до (length + 1) 
{
    table[i, j] = count;
    //выбор направления
    if (direction == "right") j++;  
    else if (direction == "left") j--;   
    else if (direction == "down") i++;   
    else i--;                       
    //проверка углов
    if (direction == "right" && j == rightbound) //если дошли слева направо, то строка+1 и идем вниз
    {
        j--;
        i++;
        direction = "down";
        rightbound--;
    }
    else if (direction == "left" && leftbound == j) //если дошли справа налево, то строка-1 и идем вверх
    {
        j++;
        i--;
        direction = "up";
        leftbound++;
    }
    else if (direction == "down" && i == downbound) //если дошли сверху вниз, то столбец -1 и идем влево
    {
        i--;
        j--;
        direction = "left";
        downbound--;
    }
    else if (direction == "up" && upperbound == i)//если дошли снизу вверх, то столбец+1 и идем вправо
    {
        i++;
        j++;
        direction = "right";
        upperbound++;
    }
}
ToPrintTable(table);