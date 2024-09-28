using System.Collections;
using System.Diagnostics;

int arrayOfNumber = 1000000;
int numberOfElement = 496753;
int divValue = 777;
int numberOfElementForFind = numberOfElement - 1;

string findElementText = $"Значение {numberOfElement} элемента: ";
string timeForFindElement = $"Длительность поиска составила (в милисекундах): ";
string timeForFillUp = $"Время создания и заполнения коллекции (в милисекундах): ";
string divText = $"Элементы, делящиеся на {divValue}: ";
string timeForDiv = $"Время поиска элементов, делящихся на {divValue} (в милисекундах): ";

Random rnd = new Random();

List<int> listInt = new List<int>();
ArrayList arrayList = new ArrayList();
LinkedList<int> linkedList = new LinkedList<int>();

for (int i = 0; i < 3; i++)
{
    DoFillUpCollection(i);
    DoFindElement(i);
    DoMathOperation(i);

    Console.WriteLine("Работа с коллекцией завершена");
    Console.WriteLine();
}

/// <summary>
/// Заполнение коллекций и вывод на консоль время выполнения
/// </summary>
void DoFillUpCollection(int i)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    switch (i)
    {
        case 0:
            Console.WriteLine("Старт работы с коллекцией List<int>");

            FillUpCollectListInt(listInt);
            break;
        case 1:
            Console.WriteLine("Старт работы с коллекцией ArrayList");

            FillUpCollectArrayList(arrayList);
            break;
        case 2:
            Console.WriteLine("Старт работы с коллекцией LinkedList<int>");

            FillUpCollectLinkedList(linkedList);
            break;
    }

    stopwatch.Stop();

    Console.WriteLine(timeForFillUp + stopwatch.ElapsedMilliseconds);

    stopwatch.Reset();
}

/// <summary>
/// Поиск элемента по номеру и вывод на консоль
/// </summary>
void DoFindElement(int i)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    switch (i)
    {
        case 0:
            Console.WriteLine(findElementText + listInt[numberOfElementForFind]);
            break;
        case 1:
            Console.WriteLine(findElementText + arrayList[numberOfElementForFind]);
            break;
        case 2:
            Console.WriteLine(findElementText + linkedList.ElementAt(numberOfElementForFind));
            break;
    }

    stopwatch.Stop();

    Console.WriteLine(timeForFindElement + stopwatch.ElapsedMilliseconds);

    stopwatch.Reset();
}

/// <summary>
/// Поиск элементов с делением без остатка и вывод их на консоль
/// </summary>
void DoMathOperation(int i)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    switch (i)
    {
        case 0:
            listInt.RemoveAll(x => x % divValue != 0);
            Console.WriteLine(divText + PrintList(listInt));
            break;
        case 1:
            ArrayList arrayListDiv = new ArrayList();

            foreach (var row in arrayList)
            {
                if (Int32.Parse(row.ToString()) % divValue == 0)
                    arrayListDiv.Add(row);
            }

            Console.WriteLine(divText + PrintArray<ArrayList>(arrayListDiv));
            break;
        case 2:
            LinkedList<int> linkedListDiv = new LinkedList<int>();

            foreach (var row in linkedList)
            {
                if (Int32.Parse(row.ToString()) % divValue == 0)
                    linkedListDiv.AddLast(row);
            }
            Console.WriteLine(divText + PrintLinkedList<LinkedList<int>>(linkedListDiv));
            break;
    }

    stopwatch.Stop();

    Console.WriteLine(timeForDiv + stopwatch.ElapsedMilliseconds);

    stopwatch.Reset();
}

/// <summary>
/// Создание коллекции List<int>
/// </summary>
List<int> FillUpCollectListInt(List<int> listInt)
{
    for (int i = 0; i < arrayOfNumber; i++)
    {
        listInt.Add(rnd.Next(0, arrayOfNumber));
    }
    return listInt;
}

/// <summary>
/// Создание коллекции ArrayList
/// </summary>
ArrayList FillUpCollectArrayList(ArrayList arrayList)
{
    for (int i = 0; i < arrayOfNumber; i++)
    {
        arrayList.Add(rnd.Next(0, arrayOfNumber));
    }
    return arrayList;
}

/// <summary>
/// Создание коллекции LinkedList<int>
/// </summary>
LinkedList<int> FillUpCollectLinkedList(LinkedList<int> linkedList)
{
    for (int i = 0; i < arrayOfNumber; i++)
    {
        linkedList.AddLast(rnd.Next(0, arrayOfNumber));
    }
    return linkedList;
}

/// <summary>
/// Вывод на консоль List<T>
/// </summary>
static string PrintList<T>(List<T> list)
{
    return $"{{{string.Join(", ", list)}}}";
}

/// <summary>
/// Вывод на консоль ArrayList
/// </summary>
static string PrintArray<T>(ArrayList array)
{
    return $"{{{string.Join(", ", array.ToArray())}}}";
}

/// <summary>
/// Вывод на консоль LinkedList<int>
/// </summary>
static string PrintLinkedList<T>(LinkedList<int> array)
{
    return $"{{{string.Join(", ", array.ToArray())}}}";
}
