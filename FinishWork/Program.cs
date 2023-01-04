/* Задача. Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа.
   Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
   При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
   Примеры:
   ["hello", "2", "world", ":-)"] -> ["2", ":-)"]
   ["1234", "1567", "-2", "computer science"] -> ["-2"]
   ["Russia", "Denmark", "Kazan"] -> []
*/
string[] array = GetRandomStringArray(new Random().Next(5, 11), 7);
PrintArray("Сгенерированный массив:", array);

// Метод генерации массива - автоматизировал, чтоб не тратить время на ввод.
string[] GetRandomStringArray(int count = 5, int wordLengthMax = 7)
{
    string[] array = new string[count];
    for (int i = 0; i < array.Length; i++)
    {
        (int begin, int finish) range = (48, 57);   // По умолчанию задаем диапазон кодов символов цифр 0..9
        switch (new Random().Next(0, 5))            // случайный выбор типа слова: цифры, заглавные или прописные, английские или русские
        {
            case (0): break;                        // Слово будет из символов цифр 0..9 // дипазон кодов задан выше (по умолчанию), но удалять эту строку нельзя
            case (1): range = (65, 90); break;      // Слово будет из символов заглавных english A..Z
            case (2): range = (97, 122); break;     // Слово будет из символов прописных english a..z
            case (3): range = (1040, 1071); break;  // Слово будет из символов заглавных русских А..Я
            case (4): range = (1072, 1103); break;  // Слово будет из символов прописных русских а..я
            default: System.Console.WriteLine("Что-то пошло не так. Метод генерации массива."); break;
        }
        int wordLength = new Random().Next(1, wordLengthMax+1); // длина слова в массиве
        array[i] = "";
        for (int j = 0; j < wordLength; j++)
        {
            array[i] += (char)(new Random().Next(range.begin, range.finish));
        }
    }
    return array;
}

// Метод вывода массива
void PrintArray(string message, string[] array)
{
    System.Console.WriteLine(message);
    System.Console.Write("[");
    for (int j = 0; j < array.Length; j++)
    {
        System.Console.Write($"\"{array[j]}\"");
        if (j < array.Length-1) System.Console.Write(", ");
    }
    System.Console.WriteLine("]");
}