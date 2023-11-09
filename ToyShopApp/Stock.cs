namespace ToyShopApp;

public class Stock
{
    private readonly List<Toy> _toys = new();
    private int _id;
    
    
    /// <summary>
    /// Добавление игрушки на слкад
    /// </summary>
    /// <param name="name">Имя игрушки</param>
    /// <param name="quantity">Количество</param>
    public void Add(string name, int quantity = 1)
    {
        for (var i = 0; i < quantity; i++) _toys.Add(new Toy(_id++, name));
    }
    
    /// <summary>
    /// Взятие со склада игрушку.
    /// </summary>
    /// <param name="name">Имя игрушки</param>
    /// <returns>Игрушка</returns>
    public Toy? Get(string name)
    {
        var toy = _toys.Find(t => t.Name == name);
        if (toy != null) _toys.Remove(toy);
        return toy;
    }
    
    /// <summary>
    /// Количество игрушек на складе
    /// </summary>
    public int Count => _toys.Count;
    
    /// <summary>
    /// Уникальные игрушки на складе
    /// </summary>
    public IEnumerable<string> AvailableToys => _toys.Select(t => t.Name).Distinct();
    
    public override string ToString() => string.Join("\n", _toys);
}