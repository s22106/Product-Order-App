// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using APN_Promise_app;

bool isRunning = true;

Order order = new Order();



while (isRunning)
{
    Console.WriteLine("Wybierz operację za pomocą liczby od 1 do 4:\n");
    Console.WriteLine("1.Dodaj produkt do zamówienia\n2.Usuń produkt z zamównenia\n3.Wyświetl wartość zamównienia\n4.Zakończ program");

    string? operation = Console.ReadLine().Trim();

    if (!Regex.IsMatch(operation, "[1-4]"))
    {
        Console.Clear();
        Console.WriteLine("Niepoprawna wartość");
        continue;
    }
    if (operation == "4")
    {
        Environment.Exit(1);
    }
    if (operation == "1")
    {
        AddProduct();
        continue;
    }

    if (operation == "2")
    {
        RemoveProduct();
        continue;
    }

    if (operation == "3")
    {
        Console.Clear();
        Console.WriteLine("Zawartość zamówienia:");
        Console.WriteLine(order);
        Console.Write("Cena: ");
        Console.WriteLine(order.OrderTotal);
        Console.WriteLine("\n-------------------------\n");
        continue;
    }
}

void RemoveProduct()
{
    bool isRemoved = false;
    while (!isRemoved)
    {
        Console.WriteLine("Wybierz produkt (za pomocą liczby od 1 do 5) do usuniecia:\n");
        Console.WriteLine("1.Laptop: 2500 PLN");
        Console.WriteLine("2.Klawiatura: 120 PLN");
        Console.WriteLine("3.Mysz: 90 PLN");
        Console.WriteLine("4.Monitor: 1000 PLN");
        Console.WriteLine("5.Kaczka debugująca: 66 PLN");
        Console.WriteLine("6.Anuluj operację");
        Console.WriteLine("\nAktualny stan zamówienia:");
        Console.WriteLine(order);

        string? product = Console.ReadLine().Trim();
        if (!Regex.IsMatch(product, "[1-6]"))
        {
            Console.Clear();
            Console.WriteLine("Niepoprawna wartość");
            continue;
        }

        if (product == "6")
        {
            Console.Clear();
            Console.WriteLine("Anulowano usuwanie produktu");
            break;
        }

        Console.WriteLine("Podal ilość danego produktu do usunięcia:");
        string? amount = Console.ReadLine().Trim();
        if (amount.All(char.IsDigit) == false)
        {
            Console.Clear();
            Console.WriteLine("Niepoprawna ilość");
            continue;
        }

        int index = 0;
        int amountParsed = 0;
        Int32.TryParse(product, out index);
        Int32.TryParse(amount, out amountParsed);
        index -= 1;

        if (!order.CheckItemAmountToRemove(index, amountParsed))
        {
            Console.Clear();
            Console.WriteLine("Nie można usunąć tych produktów z zamówienia ponieważ znajduje się ich niewystarczająca ilość");
            break;
        }

        order.RemoveItemFromOrder(index, amountParsed);
        isRemoved = true;
        Console.Clear();
        Console.WriteLine($"Usunięto {amountParsed} {order.Items[index].Product.Name}");
    }
}

void AddProduct()
{
    Console.Clear();
    bool isAdded = false;
    while (!isAdded)
    {
        Console.WriteLine("Wybierz produkt (za pomocą liczby od 1 do 5) do dodania:\n");
        Console.WriteLine("1.Laptop: 2500 PLN");
        Console.WriteLine("2.Klawiatura: 120 PLN");
        Console.WriteLine("3.Mysz: 90 PLN");
        Console.WriteLine("4.Monitor: 1000 PLN");
        Console.WriteLine("5.Kaczka debugująca: 66 PLN");
        Console.WriteLine("6.Anuluj operację");

        string? product = Console.ReadLine().Trim();
        if (!Regex.IsMatch(product, "[1-6]"))
        {
            Console.Clear();
            Console.WriteLine("Niepoprawna wartość");
            continue;
        }

        if (product == "6")
        {
            Console.Clear();
            Console.WriteLine("Anulowano dodawanie produktu");
            break;
        }

        Console.WriteLine("Podaj ilość danego produktu do dodania:");
        string? amount = Console.ReadLine().Trim();
        if (amount.All(char.IsDigit) == false)
        {
            Console.Clear();
            Console.WriteLine("Niepoprawna ilość");
            continue;
        }

        int index = 0;
        int amountParsed = 0;
        Int32.TryParse(product, out index);
        Int32.TryParse(amount, out amountParsed);
        index -= 1;

        order.AddItemToOrder(index, amountParsed);
        isAdded = true;
        Console.Clear();
        Console.WriteLine($"Dodano {amountParsed} {order.Items[index].Product.Name}");
    }
}
