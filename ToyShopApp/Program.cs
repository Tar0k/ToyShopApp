using System.Text.Json;
using ToyShopApp;

var toyShop = new ToyShop();

Console.WriteLine("Команды : Add, Play, SetDropRate, DropRate, Stock, Pickup, AwaitingToys, Help, Exit");
while (true)
{
    Console.Write("Введите команду: ");
    var command = Console.ReadLine();
    if (string.IsNullOrEmpty(command)) continue;
    switch (command.ToLower())
    {
        case "add":
            while (true)
            {
                Console.Write("Введите название игрушки: ");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Не введено имя");
                    continue;
                }

                Console.Write("Введите количество если нужно: ");
                var quantityStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(quantityStr))
                {
                    if (!int.TryParse(quantityStr, out var quantity))
                    {
                        Console.WriteLine("Не корректный формат ввода");
                        continue;
                    }
                    toyShop.Stock.Add(name, quantity);
                    break;
                }

                toyShop.Stock.Add(name);
                break;
            }
            break;
        case "play":
            try
            {
                var awardToy = toyShop.Victorina.Play();
                Console.WriteLine($"Выбрана награда: {awardToy.Name} с id {awardToy.Id}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        
        case "setdroprate":
            while (true)
            {
                Console.Write("Введите название игрушки: ");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Не введено имя");
                    continue;
                }

                Console.Write("Введите шанс выпадение (1-100): ");
                var dropRateStr = Console.ReadLine();
                if (string.IsNullOrEmpty(dropRateStr))
                {
                    Console.WriteLine("Не введено значение.");
                    continue;
                }

                if (!int.TryParse(dropRateStr, out var dropRate))
                {
                    Console.WriteLine("Не корректный ввод.");
                    continue;
                }

                if (dropRate is > 100 or < 1)
                {
                    Console.WriteLine("Значение вне допустимого диапазона");
                    continue;
                }

                toyShop.Victorina.SetDropRate(name, dropRate);
                break;
            }
            break;
        case "droprate":
            Console.WriteLine(toyShop.Victorina.DropRateData);
            break;
        case "stock":
            Console.WriteLine(toyShop.Stock);
            break;
        case "pickup":
            var toy = toyShop.Victorina.GetAwaitingToy();
            if (toy == null)
            {
                Console.WriteLine("Нет игрушек в очереди на выдачу");
                break;
            }
            Console.WriteLine($"Забрана игрушка: {toy.Name} c id {toy.Id}");
            var text = $"Id: {toy.Id}, Name: {toy.Name}";
            using (var file = new StreamWriter("Awards.txt", true)) file.WriteLine(text);
            break;
        case "awaitingtoys":
            Console.WriteLine(toyShop.Victorina.AwaitingPickupToys);
            break;
        case "help":
            Console.WriteLine("Команды : Add, SetDropRate, DropRate, Stock, Pickup, AwaitingToys, Help");
            break;
        case "exit":
            return;
        default:
            Console.WriteLine("Некорректная команда");
            break;
    }
}



