namespace ToyShopApp;

public class Toy(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;

    public override string ToString() => $"ID: {Id} Name: {Name}";
}