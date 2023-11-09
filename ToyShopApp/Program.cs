using ToyShopApp;

var toyShop = new ToyShop();

Console.WriteLine("Команды : Add, SetDropRate, DropRate, Stock, Pickup, AwaitingToys, Help");
while (true)
{
    Console.WriteLine("Введите команду");
    var command = Console.ReadLine();
    if (string.IsNullOrEmpty(command)) continue;
    switch (command.ToLower())
    {
        case "add":
            while (true)
            {
                Console.Write("Введите название игрушки: ");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) continue;
                
                Console.Write("Введите количество если нужно: ");
                var quantityStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(quantityStr))
                {
                    if (!int.TryParse(quantityStr, out var quantity)) continue;
                    toyShop.Stock.Add(name, quantity);
                    break;
                }
                toyShop.Stock.Add(name);
                break;
            }
            break;
        case "setdroprate":
            break;
        case "droprate":
            Console.WriteLine(toyShop.Victorina.DropRateData);
            break;
        case "stock":
            Console.WriteLine(toyShop.Stock);
            break;
        case "pickup":
            break;
        case "awaitingtoys":
            Console.WriteLine(toyShop.Victorina.AwaitingPickupToys);
            break;
        case "help":
            Console.WriteLine("Команды : Add, SetDropRate, DropRate, Stock, Pickup, AwaitingToys, Help");
            break;
        case "exit":
            return ;
        default:
            Console.WriteLine("Некорректная команда");
            break;
    }


}


toyShop.Stock.Add("Робот", 5);
toyShop.Stock.Add("Кукла", 8);
toyShop.Stock.Add("Машина", 3);

toyShop.Victorina.SetDropRate("Робот", 2);
toyShop.Victorina.SetDropRate("Кукла", 4);
toyShop.Victorina.SetDropRate("Машина", 4);

toyShop.Victorina.SetDropRate("Самолет", 4);


Console.WriteLine(toyShop.Stock);

toyShop.Stock.Get("Робот");
Console.WriteLine(toyShop.Stock);


toyShop.Victorina.Play();

Console.WriteLine(toyShop.Victorina.DropRateData);
Console.WriteLine(toyShop.Victorina.AwaitingPickupToys);
Console.WriteLine(toyShop.Stock);


