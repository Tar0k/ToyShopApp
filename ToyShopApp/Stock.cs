namespace ToyShopApp;

public class Stock
{
    private readonly List<Toy> _toys = new();
    private int _id;

    public void Add(string name, int quantity = 1)
    {
        for (var i = 0; i < quantity; i++) _toys.Add(new Toy(_id++, name));
    }

    public Toy? Get(string name)
    {
        var toy = _toys.Find(t => t.Name == name);
        if (toy != null) _toys.Remove(toy);
        return toy;
    }

    public int Count => _toys.Count;

    public IEnumerable<string> AvailableToys => _toys.Select(t => t.Name).Distinct();
    
    public override string ToString() => string.Join("\n", _toys);
}