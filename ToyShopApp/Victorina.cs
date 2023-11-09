namespace ToyShopApp;

public class Victorina(Stock stock)
{
    private readonly Dictionary<string, int> _dropRateData = new();
    private readonly Queue<Toy> _awaitingPickupToys = new();
    private readonly Random _random = new Random();

    public string AwaitingPickupToys => string.Join("\n", _awaitingPickupToys);

    public string DropRateData
    {
        get
        {
            var temp = _dropRateData.Select(r => $"Name: {r.Key}, dropRate: {r.Value}");
            return string.Join("\n", temp);
        }
    }
    
    public void SetDropRate(string name, int dropRate) => _dropRateData[name] = dropRate;
    
    public Toy Play()
    {
        var toy = SelectAwardToy();
        AddToAwaitingPickup(toy);
        return toy;
    }
    
    
    private Toy? SelectAwardToy()
    {
        if (stock.Count == 0) throw new InvalidOperationException("На складе пусто");
        var availableToys = stock.AvailableToys;
        
        // Берем шансы только для тех игрушек, которые есть на складе
        var availableDrops = _dropRateData.Where(r => availableToys.Contains(r.Key)).ToList();
        if (availableDrops.Count == 0) throw new InvalidOperationException("Не указаны шансы выпадения для игрушек на складе");

        // Создаем список имен игрушек в соотствии с шансом выпадения
        List<string> choiceList = new();
        foreach (var (name, dropRate) in availableDrops)
        {
            choiceList.AddRange(Enumerable.Repeat(name, dropRate));
        }
        
        // Выбираем случайную игрушку из списка и возвращаем
        return stock.Get(choiceList[_random.Next(choiceList.Count)]);
    }

    private void AddToAwaitingPickup(Toy toy) => _awaitingPickupToys.Enqueue(toy);

    public Toy? GetAwaitingToy() => _awaitingPickupToys.Count != 0 ? _awaitingPickupToys.Dequeue(): null;

}