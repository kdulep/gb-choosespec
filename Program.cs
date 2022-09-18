using System.Text;
Console.OutputEncoding = Encoding.UTF8;

int InputNumber(in string prompt)
{
    bool result;
    do
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        result = int.TryParse(input, out var number);
        if (result == true)
        {
            //Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
            return number;
        }
        else
            Console.WriteLine("Преобразование завершилось неудачно");
    } while (result);
    return 0;
}

string[]? GetStrings(int numStrings)
{
    if (numStrings == 0) return null;
    string[] stringStrings = new string[numStrings];
    string? input = null;
    for (int i = 0; i < numStrings; i++)
    {
        do
        {
            Console.WriteLine("Введите строку #" + i + " : ");
            input = Console.ReadLine();
        } while (input == null);
        stringStrings[i] = input;

    }
    return stringStrings;
}

string[]? GetShortStrings(string[] arr)
{
    string[] stringStrings = new string[arr.Length];
    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= 3) { stringStrings[count] = arr[i]; count++; }
    }
    if (count == 0) return null;
    return stringStrings[0..count];
}

int numStrings = InputNumber("Введите число строк");
string[]? strings = GetStrings(numStrings);
if (strings == null)
{
    Console.WriteLine("Неправильный ввод");
    throw new ArgumentOutOfRangeException();
}

string[]? shortStrings = GetShortStrings(strings);
if (shortStrings == null)
{
    Console.WriteLine("условие не найдено");
    System.Environment.Exit(0);
}
Console.WriteLine(string.Join(", ", shortStrings));
